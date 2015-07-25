using UnityEngine;
using System.Collections;

public class SmoothCamera : MonoBehaviour {
    
//    public Transform target;
    public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;
	Camera _camera;
	public Vector3 offset = new Vector3(-1f, -1f, -.05f);
	public Vector3 initialPos = new Vector3(2f,-2f,-2f);
	
	float speed = 1f;
	
	void Awake() 
	{
		transform.position = initialPos;
		//_camera = Camera.main;
	}

	// Update is called once per frame
	void Update () 
	{

	}
	
	void FixedUpdate() {
		this.transform.position = new Vector3(this.transform.position.x + (5f* speed * Time.fixedDeltaTime), this.transform.position.y, -2f);
        speed += Time.fixedDeltaTime * 0.01f;
    }
}