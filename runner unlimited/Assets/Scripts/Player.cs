using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {

	bool jumping;
	bool doubleJumping;
	bool initialized = false;
	Rigidbody2D rigid;
	public Text distanceDisplay;
	public Shake shake;
	public SmoothCamera smooth;
	Animator anim;
	ParticleSystem death;

    public AudioSource explosion;
    public AudioSource jump;

    float speed = 1f;

    Camera mainz;

    bool gameOver = false;


	// Use this for initialization
	void Start () {
		mainz = Camera.main;
		rigid = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		death = transform.FindChild ("DeathParticles").GetComponent<ParticleSystem> ();
		initialized = true;
    }
	
	// Update is called once per frame
	void Update () {
		if (!initialized)
			return;
		if (Input.anyKeyDown && !doubleJumping)
        {
            jump.Play();
            if (jumping)
            {
                doubleJumping = true;
                rigid.velocity = new Vector2(0, 0);
            }
            rigid.AddForce(Vector3.up * 11, ForceMode2D.Impulse);
			jumping = true;
		}

		distanceDisplay.text = (int)transform.position.x + "m";
		distanceDisplay.fontSize = (int) (14 + (transform.position.x * 0.03f));
		if (transform.position.x < 100) {
			distanceDisplay.color = Color.Lerp (Color.gray, Color.yellow, transform.position.x * 0.01f);
		} else {
			distanceDisplay.color = Color.Lerp (Color.yellow, Color.red, (transform.position.x-100) * 0.01f);
		}
		shake.maximumShake = Mathf.Min(transform.position.x * 0.01f, 5f);
		shake.shakeSpeed = Mathf.Min (transform.position.x * 0.7f, 300);
	}

	void OnCollisionEnter2D(Collision2D coll){
		jumping = false;
		doubleJumping = false;
    }

    void FixedUpdate() {
		if (!initialized)
			return;
		transform.position = new Vector3(transform.position.x + (5.2f * speed * Time.fixedDeltaTime * (gameOver ? 0 : 1)), transform.position.y, 0);
        speed += Time.fixedDeltaTime * 0.01f;
		anim.speed = speed;
        
        if(gameOver)
        {
            if (!explosion.isPlaying)
            {
				enabled = false;
                Application.LoadLevel("level");
            }

        }
        else
        {
            if (transform.position.x < mainz.transform.position.x - 8.5 || transform.position.y < mainz.transform.position.y - 6)
            {
                print("You lose");
                explosion.Play();
                gameOver = true;
				if (smooth != null)
					smooth.enabled = false;
				if (anim != null)
					anim.SetTrigger("Dead");
				if (death != null)
				death.Play();
				shake.enabled = false;
				PlayerPrefs.SetInt("topScore", Mathf.Max(PlayerPrefs.GetInt("topScore"),(int)transform.position.x));
            }
        }

    }

	//void OnBecameInvisible() {
	//	print ("You lose");
 //       explosion.Play();
 //       //Application.LoadLevel(0);
	//}
}
