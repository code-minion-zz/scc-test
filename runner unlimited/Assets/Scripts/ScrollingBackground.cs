using UnityEngine;
using System.Collections;

public class ScrollingBackground : MonoBehaviour {

	public float speed = 0.005f;

	float pos = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		pos += speed;
		if (pos > 1.0f)
			pos -= 1.13f;
		Renderer sr = GetComponent<Renderer> ();
		sr.material.mainTextureOffset = new Vector2 (pos, 0);
	}
}
