using UnityEngine;
using System.Collections;

public class Bouncingbox : MonoBehaviour {

	public int force;
	// Use this for initialization
	void Start () {
		force = 650;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other) 
	{
		if (other.tag == "Player")
		{
			other.rigidbody.AddForce (Vector3.up * force);

		}
	}
}
