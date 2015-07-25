using UnityEngine;
using System.Collections;

public class Shake : MonoBehaviour {
	public float maximumShake = 2f;
	public float shakeSpeed = 0.1f;
	Vector3 startPos;
	float offset = 0f;
	public bool left = false;

	// Use this for initialization
	void Start () {
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		var myTransform = transform as RectTransform;
		Vector2 curPos = myTransform.anchoredPosition;
		offset += shakeSpeed * (left ? -1 : 1) * Time.deltaTime;
		myTransform.anchoredPosition = new Vector2 (offset, curPos.y);
		if (offset >= maximumShake) {
			left = true;
		} else if (offset <= -maximumShake){
			left = false;
		}
	}
}
