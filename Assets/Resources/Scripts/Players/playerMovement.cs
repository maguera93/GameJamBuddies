using UnityEngine;
using System.Collections;



public class playerMovement : MonoBehaviour {
	public enum PlayerColor {RED, BLUE, GREEN, YELLOW}

	public float speed;
	public GameObject dustRun;
	public GameObject splash;
	private AnimationCharacter anim;
    public DestroyPlayer destroyer;
	public int jump;
	public float stunTimer;
	public float stunDuration;
	public bool grounded;
    public TextMesh winner;
	public PlayerColor color;
	public bool stunned;
    public bool playing;
	public int gravity;
    private CameraMove camer;
    private LoadingScreen loadingScreen;
    private DataLogic dataLogic;


	// Use this for initialization
	void Start () {
		stunTimer = 0;
		stunDuration = 1.5f;
		speed = 5f;
		jump = 4000;
		grounded = true;
		stunned = false;
        playing = true;
		//player = PLAYER.BLUE;
		anim = transform.GetComponent<AnimationCharacter> ();
        loadingScreen = GameObject.FindGameObjectWithTag("LoadingScreen").
            GetComponent<LoadingScreen>();
        destroyer = GameObject.FindGameObjectWithTag("Destroyer").
            GetComponent<DestroyPlayer>();
        camer = GameObject.FindGameObjectWithTag("MainCamera").
            GetComponent<CameraMove>();
        winner = GameObject.FindGameObjectWithTag("Title").
            GetComponent<TextMesh>();
        dataLogic = GameObject.FindGameObjectWithTag("DataLogic").
            GetComponent<DataLogic>();

	}
	
	// Update is called once per frame
	void Update () {

        if (playing)
        {
            if (grounded) dustRun.SetActive(true);
            else
            {
                dustRun.SetActive(false);

            }

            switch (color)
            {
                case PlayerColor.RED:
                    {
                        if (!stunned)
                        {
                            float translationV = Input.GetAxis("P1_Vertical") * 0.05f;
                            float translationH = Input.GetAxis("P1_Horizontal") * 0.1f;

                            if (Input.GetKey(KeyCode.DownArrow)) transform.Translate(0, 0, -speed * Time.deltaTime * 0.5f);
                            if (Input.GetKey(KeyCode.UpArrow)) transform.Translate(0, 0, speed * Time.deltaTime * 0.5f);
                            if (Input.GetKey(KeyCode.LeftArrow)) transform.Translate(-speed * Time.deltaTime, 0, 0);
                            if (Input.GetKey(KeyCode.RightArrow)) transform.Translate(speed * Time.deltaTime, 0, 0);
                            if (Input.GetKey(KeyCode.KeypadEnter) || Input.GetKey(KeyCode.Joystick1Button0))
                            {
                                Jump(jump);
                                anim.setJump();
                            }

                            transform.Translate(translationH, 0, translationV);
                            translationV *= Time.deltaTime;
                            translationH *= Time.deltaTime;

                            if ((translationV == 0 && translationH == 0) && grounded) anim.setIdle();
                            else if ((translationV != 0 || translationH != 0) && grounded) anim.setRunRight();
                        }

                        break;
                    }

                case PlayerColor.BLUE:
                    {
                        if (!stunned)
                        {
                            float translationV2 = Input.GetAxis("P2_Vertical") * 0.05f;
                            float translationH2 = Input.GetAxis("P2_Horizontal") * 0.1f;

                            if (Input.GetKey(KeyCode.S)) transform.Translate(0, 0, -speed * Time.deltaTime * 0.5f);
                            if (Input.GetKey(KeyCode.W)) transform.Translate(0, 0, speed * Time.deltaTime * 0.5f);
                            if (Input.GetKey(KeyCode.A)) transform.Translate(-speed * Time.deltaTime, 0, 0);
                            if (Input.GetKey(KeyCode.D)) transform.Translate(speed * Time.deltaTime, 0, 0);
                            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Joystick2Button0))
                            {
                                Jump(jump);
                                anim.setJump();

                            }
                            transform.Translate(translationH2, 0, translationV2);
                            translationV2 *= Time.deltaTime;
                            translationH2 *= Time.deltaTime;

                            if ((translationV2 == 0 && translationH2 == 0) && grounded) anim.setIdle();
                            else if ((translationV2 != 0 || translationH2 != 0) && grounded) anim.setRunRight();
                        }

                        break;
                    }
                case PlayerColor.GREEN:
                    {
                        if (!stunned)
                        {
                            float translationV2 = Input.GetAxis("P3_Vertical") * 0.05f;
                            float translationH2 = Input.GetAxis("P3_Horizontal") * 0.1f;

                            if (Input.GetKey(KeyCode.S)) transform.Translate(0, 0, -speed * Time.deltaTime * 0.5f);
                            if (Input.GetKey(KeyCode.W)) transform.Translate(0, 0, speed * Time.deltaTime * 0.5f);
                            if (Input.GetKey(KeyCode.A)) transform.Translate(-speed * Time.deltaTime, 0, 0);
                            if (Input.GetKey(KeyCode.D)) transform.Translate(speed * Time.deltaTime, 0, 0);
                            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Joystick3Button0))
                            {
                                Jump(jump);
                                anim.setJump();

                            }
                            transform.Translate(translationH2, 0, translationV2);
                            translationV2 *= Time.deltaTime;
                            translationH2 *= Time.deltaTime;

                            if ((translationV2 == 0 && translationH2 == 0) && grounded) anim.setIdle();
                            else if ((translationV2 != 0 || translationH2 != 0) && grounded) anim.setRunRight();
                        }

                        break;
                    }

                case PlayerColor.YELLOW:
                    {
                        if (!stunned)
                        {
                            float translationV2 = Input.GetAxis("P4_Vertical") * 0.05f;
                            float translationH2 = Input.GetAxis("P4_Horizontal") * 0.1f;

                            if (Input.GetKey(KeyCode.S)) transform.Translate(0, 0, -speed * Time.deltaTime * 0.5f);
                            if (Input.GetKey(KeyCode.W)) transform.Translate(0, 0, speed * Time.deltaTime * 0.5f);
                            if (Input.GetKey(KeyCode.A)) transform.Translate(-speed * Time.deltaTime, 0, 0);
                            if (Input.GetKey(KeyCode.D)) transform.Translate(speed * Time.deltaTime, 0, 0);
                            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Joystick4Button0))
                            {
                                Jump(jump);
                                anim.setJump();

                            }
                            transform.Translate(translationH2, 0, translationV2);
                            translationV2 *= Time.deltaTime;
                            translationH2 *= Time.deltaTime;

                            if ((translationV2 == 0 && translationH2 == 0) && grounded) anim.setIdle();
                            else if ((translationV2 != 0 || translationH2 != 0) && grounded) anim.setRunRight();
                        }

                        break;
                    }
            }

            if (stunned)
            {
                stunTimer += Time.deltaTime;
                if (stunTimer >= stunDuration)
                {
                    stunned = false;
                    stunTimer = 0;
                }
            }
        }
        else
        {
            switch (dataLogic.players)
            {
                case DataLogic.PlayersNum.PLAYTWOO:
                    if (destroyer.rScore < destroyer.bScore)
                    {
                        winner.text = "PLAYER 1 WINS";
                    }
                    else if (destroyer.rScore > destroyer.bScore)
                    {
                        winner.text = "PLAYER 2 WINS";
                    }
                    else if (destroyer.rScore == destroyer.bScore)
                    {
                        winner.text = "DRAW!";
                    }
                    break;

                case DataLogic.PlayersNum.PLAYTHREE:
                    if (destroyer.rScore < destroyer.bScore && destroyer.rScore < destroyer.gScore)
                    {
                        winner.text = "PLAYER 1 WINS";
                    }
                    else if (destroyer.rScore > destroyer.bScore && destroyer.bScore < destroyer.gScore)
                    {
                        winner.text = "PLAYER 2 WINS";
                    }
                    else if (destroyer.rScore == destroyer.bScore && destroyer.rScore == destroyer.gScore)
                    {
                        winner.text = "DRAW!";
                    }
                    break;
                case DataLogic.PlayersNum.PLAYFOUR:
                    if (destroyer.rScore < destroyer.bScore && destroyer.rScore < destroyer.gScore && destroyer.rScore < destroyer.yScore)
                    {
                        winner.text = "PLAYER 1 WINS";
                    }
                    else if (destroyer.rScore > destroyer.bScore && destroyer.bScore < destroyer.gScore )
                    {
                        winner.text = "PLAYER 2 WINS";
                    }
                    else if (destroyer.rScore == destroyer.bScore && destroyer.rScore == destroyer.gScore)
                    {
                        winner.text = "DRAW!";
                    }
                    break;
            }

            camer.speed = 0;

            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Joystick2Button0) || Input.GetKey(KeyCode.Joystick1Button0))
            {
                loadingScreen.loadCurrentScreen = true;
            }
        }

	}
	

	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Ground")
		{

			//GameObject dust = (GameObject)Instantiate(dustJump.gameObject, transform.position, Quaternion.identity);
			grounded = true;
			//Destroy(dust, 1);
			Debug.Log ("asdasd");
		}

		if (other.tag == "Water") Instantiate (splash, transform.position, Quaternion.identity);

        if (other.tag == "End")
        {
            playing = false;
        }

	}

	void Jump(int force)
	{
		if (grounded)
		{
			rigidbody.AddForce (Vector3.up * force); 
			grounded = false;
		}
	}

	void OnTriggerStay(Collider other)
	{

		switch (color)
		{
		case PlayerColor.RED:
			{	
				if (Input.GetKey (KeyCode.KeypadPlus) || Input.GetKey(KeyCode.Joystick1Button2))
				{
					anim.setPush();
					
					if (!stunned && other.tag == "BluePlayer") 
					{
						other.rigidbody.AddForce (new Vector3(1000, 0, 0));
						
					}

                    if (!stunned && other.tag == "GreenPlayer")
                    {
                        other.rigidbody.AddForce(new Vector3(1000, 0, 0));

                    }

                    if (!stunned && other.tag == "YellowPlayer")
                    {
                        other.rigidbody.AddForce(new Vector3(1000, 0, 0));

                    }
					
				}
				
				break;
			}

        case PlayerColor.BLUE:
            {
                if (Input.GetKey(KeyCode.F) || Input.GetKey(KeyCode.Joystick2Button2))
                {
                    anim.setPush();

                    if (!stunned && other.tag == "RedPlayer")
                    {
                        other.rigidbody.AddForce(new Vector3(1000, 0, 0));

                    }

                    if (!stunned && other.tag == "GreenPlayer")
                    {
                        other.rigidbody.AddForce(new Vector3(1000, 0, 0));

                    }

                    if (!stunned && other.tag == "YellowPlayer")
                    {
                        other.rigidbody.AddForce(new Vector3(1000, 0, 0));

                    }
                }
                break;
            }
                case PlayerColor.GREEN:
			{	
				if (Input.GetKey (KeyCode.F) || Input.GetKey(KeyCode.Joystick2Button2))
				{
					anim.setPush ();
					
			    	if (!stunned && other.tag == "RedPlayer")
					{
						other.rigidbody.AddForce (new Vector3(1000, 0, 0));
						
					}

                    if (!stunned && other.tag == "BluePlayer")
                    {
                        other.rigidbody.AddForce(new Vector3(1000, 0, 0));

                    }

                    if (!stunned && other.tag == "YellowPlayer")
                    {
                        other.rigidbody.AddForce(new Vector3(1000, 0, 0));

                    }
				}
				break;
			}
                case PlayerColor.YELLOW:
            {
                if (Input.GetKey(KeyCode.F) || Input.GetKey(KeyCode.Joystick2Button2))
                {
                    anim.setPush();

                    if (!stunned && other.tag == "RedPlayer")
                    {
                        other.rigidbody.AddForce(new Vector3(1000, 0, 0));

                    }

                    if (!stunned && other.tag == "BluePlayer")
                    {
                        other.rigidbody.AddForce(new Vector3(1000, 0, 0));

                    }

                    if (!stunned && other.tag == "GreenPlayer")
                    {
                        other.rigidbody.AddForce(new Vector3(1000, 0, 0));

                    }
                }
                break;
            }
		}
	}

	/*public void callMOV(Collider other){

		switch (playerState)
		{
		case StatesPlayer.RED:
		{	
			if (other.tag == "BluePlayer")
			{
				other.rigidbody.AddForce(Vector3.up * jumpForce);
				rigidbody.AddForce(Vector3.down * downForce);

			}
			break;
		}
			
		case StatesPlayer.BLUE:
		{	
			if (other.tag == "RedPlayer")
			{
				other.rigidbody.AddForce(Vector3.up * jumpForce);
				rigidbody.AddForce(Vector3.down * downForce);
				break;
			}
			

		}break;
		}
		/*
		switch (playerState)
		{
			case StatesPlayer.RED:
			{

			}
					
			case StatesPlayer.BLUE:
			{
					if (other.tag == "RedPlayer")
					{
						//other.rigidbody.AddForce(Vector3.up * jumpForce);
						//rigidbody.AddForce(Vector3.down * downForce);
						break;
					}
			}
		}

	}*/
}






