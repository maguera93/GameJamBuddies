using UnityEngine;
using System.Collections;

public class Shadow : MonoBehaviour {

	RaycastHit hit;
	public GameObject playerShadow;
	private Vector3 shadPos;


	public float shadowY;
	// Use this for initialization
	void Start () {
		shadPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		Ray ray = new Ray (transform.position, Vector3.down);

		if(Physics.Raycast(ray, out hit, 500)){


			if (hit.collider.tag == "Ground" || hit.collider.tag == "BluePlayer" || hit.collider.tag == "RedPlayer") 
			{
				//shadowPos = new Vector3(playerPos.transform.position.x, hit.point.y + 0.1f , playerPos.transform.position.z);
				shadowY = hit.point.y;
				shadPos = new Vector3 (transform.position.x, shadowY + 0.01f, transform.position.z);


			}
			else if (hit.collider.tag != "Ground") 
			{
				//shadowPos = new Vector3(playerPos.transform.position.x, hit.point.y + 0.1f , playerPos.transform.position.z);
				shadowY = -500;
				shadPos = new Vector3 (transform.position.x, shadowY + 0.01f, transform.position.z);
				
				
			}
		}

		//shadPos = new Vector3 (transform.position.x, shadowY + 0.01f, transform.position.z);
		playerShadow.transform.position = shadPos;
	}
}
