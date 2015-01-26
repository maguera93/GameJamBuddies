using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour {

    public float tempIni;
    public float temp;
	public float cooldown;
    public GameObject bullet;

	// Use this for initialization
	void Start ()
    {
        temp = tempIni;
	}
	
	// Update is called once per frame
	void Update () 
    {
        temp -= Time.deltaTime;
        if (temp <= 0)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            temp = cooldown;
        }
	}
}
