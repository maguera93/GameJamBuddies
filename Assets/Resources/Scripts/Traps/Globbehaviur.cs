using UnityEngine;
using System.Collections;

public class Globbehaviur : MonoBehaviour {

    public enum GlobState { IDLE, HIT, FORWARD }

    public float temp;
    public float tempHit;
    public float tempFoward;
    public float hitSpeed;
    public float fowardSpeed;

    public GlobState state;

	// Use this for initialization
	void Start () {
        state = GlobState.IDLE;
	}
	
	// Update is called once per frame
	void Update () 
    {

        switch (state)
        {
            case GlobState.HIT:

                temp -= Time.deltaTime;
                transform.Translate(-hitSpeed*Time.deltaTime, 0, 0);

                if (temp <= 0)
                {
                    state = GlobState.FORWARD;
                    temp = tempFoward;
                }
                break;

            case GlobState.FORWARD:

                temp -= Time.deltaTime;
                transform.Translate(fowardSpeed*Time.deltaTime, 0, 0);

                if (temp <= 0)
                {
                    state = GlobState.IDLE;
                    temp = tempHit;
                }

                break;
        }
	}
    void OnTriggerEnter(Collider other)
    {
        switch (state)
        {
            case GlobState.IDLE:
                if(other.tag == "RedPlayer" || other.tag == "BluePlayer")
                state = GlobState.HIT;
                break;
        }
    }
}
