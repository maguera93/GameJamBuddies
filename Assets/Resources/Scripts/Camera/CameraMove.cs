using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	public int speed;

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3 (speed*Time.deltaTime, 0, 0));
	}
}
