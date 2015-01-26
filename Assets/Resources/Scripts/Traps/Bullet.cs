using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    int speed;

	// Use this for initialization
	void Start () 
    {
        speed = -10;
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate (speed*Time.deltaTime, 0, 0);
        Destroy(this.gameObject, 3);
        //rigidbody.AddForce(Vector3.up * 300); 
    }

	void OnTriggerEnter(Collider other)
	{

		if (other.tag == "RedPlayer" || other.tag == "BluePlayer") other.rigidbody.AddForce (Vector3.back * 3000);
				
	

	}

}
