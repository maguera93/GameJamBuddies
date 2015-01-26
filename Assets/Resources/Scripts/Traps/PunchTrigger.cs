using UnityEngine;
using System.Collections;

public class PunchTrigger : MonoBehaviour {

	public Globbehaviur punch;
	// Use this for initialization
	void Start () {
		punch = transform.GetComponentInParent<Globbehaviur> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		switch (punch.state)
		{
		case Globbehaviur.GlobState.IDLE:
			if(other.tag == "RedPlayer" || other.tag == "BluePlayer")
				punch.state = Globbehaviur.GlobState.HIT;
			break;
		}
	}
}
