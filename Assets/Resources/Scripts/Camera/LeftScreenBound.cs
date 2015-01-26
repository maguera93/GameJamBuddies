using UnityEngine;
using System.Collections;

public class LeftScreenBound : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if ((other.tag == "BluePlayer") || (other.tag == "RedPlayer")) other.transform.Translate (Vector3.right * 1);
	}
}
