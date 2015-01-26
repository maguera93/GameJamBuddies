using UnityEngine;
using System.Collections;

public class ShadowPos : MonoBehaviour {

	public Shadow shad;
	// Use this for initialization
	void Start () {
		shad = GetComponent<Shadow> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		//shad.transform.position = new Vector3 (shad.transform.position.x, shad.shadowY,shad.transform.position.z);
	}
}
