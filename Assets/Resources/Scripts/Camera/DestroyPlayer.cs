using UnityEngine;
using System.Collections;

public class DestroyPlayer : MonoBehaviour {

	public GameObject redplayer;
	public GameObject blueplayer;
    public GameObject greenplayer;
    public GameObject yellowplayer;
    public TextMesh blueScore;
    public TextMesh redScore;
    public TextMesh greenScore;
    public TextMesh yellowScore;
    public int bScore;
    public int rScore;
    public int gScore;
    public int yScore;
    private DataLogic dataLogic;

	// Use this for initialization
	void Start () {
        dataLogic = GameObject.FindGameObjectWithTag("DataLogic").
            GetComponent<DataLogic>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        switch (dataLogic.players)
        {
            case DataLogic.PlayersNum.PLAYTWOO:
                blueScore.text = bScore.ToString("00");
                redScore.text = rScore.ToString("00");
                break;

            case DataLogic.PlayersNum.PLAYTHREE:
                blueScore.text = bScore.ToString("00");
                redScore.text = rScore.ToString("00");
                greenScore.text = gScore.ToString("00");
                break;
            case DataLogic.PlayersNum.PLAYFOUR:
                blueScore.text = bScore.ToString("00");
                redScore.text = rScore.ToString("00");
                greenScore.text = gScore.ToString("00");
                yellowScore.text = yScore.ToString("00");
                break;
        }
	}

	void OnTriggerEnter(Collider other)
	{
        switch (dataLogic.players)
        {
            case DataLogic.PlayersNum.PLAYTWOO:
                if (other.tag == "RedPlayer")
		        {
			        Destroy (other.gameObject);
			        Instantiate(redplayer, transform.position, Quaternion.identity);
                    rScore++;
		        }

		        if (other.tag == "BluePlayer")
		        {
		        Destroy (other.gameObject);
		        Instantiate(blueplayer, transform.position, Quaternion.identity);
                bScore++;
		        }
                break;

            case DataLogic.PlayersNum.PLAYTHREE:
                if (other.tag == "RedPlayer")
		        {
			        Destroy (other.gameObject);
			        Instantiate(redplayer, transform.position, Quaternion.identity);
                    rScore++;
		        }

		        if (other.tag == "BluePlayer")
		        {
		        Destroy (other.gameObject);
		        Instantiate(blueplayer, transform.position, Quaternion.identity);
                bScore++;
		        }

                if (other.tag == "GreenPlayer")
                {
                    Destroy(other.gameObject);
                    Instantiate(blueplayer, transform.position, Quaternion.identity);
                    gScore++;
                }
                break;
            case DataLogic.PlayersNum.PLAYFOUR:
                if (other.tag == "RedPlayer")
		        {
			        Destroy (other.gameObject);
			        Instantiate(redplayer, transform.position, Quaternion.identity);
                    rScore++;
		        }

		        if (other.tag == "BluePlayer")
		        {
		        Destroy (other.gameObject);
		        Instantiate(blueplayer, transform.position, Quaternion.identity);
                bScore++;
		        }

                if (other.tag == "GreenPlayer")
                {
                    Destroy(other.gameObject);
                    Instantiate(greenplayer, transform.position, Quaternion.identity);
                    gScore++;
                }

                if (other.tag == "YellowPlayer")
                {
                    Destroy(other.gameObject);
                    Instantiate(yellowplayer, transform.position, Quaternion.identity);
                    yScore++;
                }
                break;
        }
	}
}
