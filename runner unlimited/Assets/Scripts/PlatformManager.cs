using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlatformManager : MonoBehaviour {

	private List<GameObject> floors;
	public List<GameObject> floorPrefabs;
	public GameObject playerChar;
	public Text topScoreUI;

    public GameObject randomFloor
    {
        get
        {
            if (floorPrefabs.Count == 0) return null;
            int index = Random.Range(0, floorPrefabs.Count);
            return floorPrefabs[index];
        }
    }

	// Use this for initialization
	void Awake () 
	{
		floors = new List<GameObject> ();
		for (int i = 0; i < 4; i++)
        {
            GameObject randFloor = randomFloor;
            if (randFloor == null) return;
            float xPos = -10 + (24 * i);
			GameObject floor = GameObject.Instantiate (randFloor, new Vector3(xPos, -4.5f, 0f), new Quaternion()) as GameObject;
			//Renderer r = floor.GetComponent<Renderer>();
			//r.material.color = Color.Lerp(Color.red,Color.blue, 0.25f * i);// new Color(0.5f,0.5f,0.5f)'i * Color.grey;
			floors.Add(floor);
		}
		playerChar = GameObject.Find ("ZomBunny");
		topScoreUI.text = "Top Score:" + PlayerPrefs.GetInt("topScore") + "m";
	}
	
	// Update is called once per frame
	void Update () {
		if (playerChar == null) return;
		if (playerChar.transform.position.x > (floors [1].transform.position.x +  12)) {
			GameObject tmp = floors[0];
			floors.RemoveAt(0);
			tmp.transform.position = new Vector3(floors[2].transform.position.x + 24, tmp.transform.position.y);
			floors.Add(tmp);
		}
	}


}
