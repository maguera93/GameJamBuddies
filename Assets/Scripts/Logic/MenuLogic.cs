using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuLogic : MonoBehaviour {

	public enum State {START, MENU, OPTIONS}

	public State screen;
	public GameObject start; 
	public GameObject menu;
    public GameObject keys;
    public GameObject cre;
    bool down;
    public bool controls;
    public bool credits;
    public float temp;
	public Button playButton;
    public Button playButton3P;
    public Button playButton4P;
	//public Button optionsButton;
	public Button exitButton;
    public Button instructionsButton;
    public Button creditsButton;
    //public Button backButton;
    //public GameObject eventSis; 
	//public GameObject options;
	private LoadingScreen loadingScreen;
    private DataLogic dataLogic;

	// Use this for initialization
	void Start () {
		screen = State.START;
		loadingScreen = GameObject.FindGameObjectWithTag("LoadingScreen").
			GetComponent<LoadingScreen>();
        dataLogic = GameObject.FindGameObjectWithTag("DataLogic").
            GetComponent<DataLogic>();
        down = false;
        controls = false;
        credits = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		switch (screen) {
	
		case State.START:

                temp += Time.deltaTime;
                if (!down)
                {
                    start.SetActive(true);

                    if (temp >= 0.5f)
                    {
                        down = true;
                        temp = 0;
                    }
                }
                else
                {
                    start.SetActive(false);

                    if (temp >= 0.5f)
                    {
                        down = false;
                        temp = 0;
                    }
                }
			    menu.SetActive(false);
			    //options.SetActive(false);
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKey(KeyCode.Joystick1Button7))
			    {
				    screen = State.MENU;
			    }
			break;
		case State.MENU:
			    start.SetActive(false);
			    menu.SetActive(true);
			    //options.SetActive(false);
			    playButton.GetComponent<Button>().onClick.AddListener (() => {

				    loadingScreen.loadNextScreen = true;
                    dataLogic.players = DataLogic.PlayersNum.PLAYTWOO;

			    }
			    );

                playButton3P.GetComponent<Button>().onClick.AddListener(() =>
                {

                    loadingScreen.loadNextScreen3P = true;
                    dataLogic.players = DataLogic.PlayersNum.PLAYTHREE;
                }
                );

                playButton4P.GetComponent<Button>().onClick.AddListener(() =>
                {

                    loadingScreen.loadNextScreen4P = true;
                    dataLogic.players = DataLogic.PlayersNum.PLAYFOUR;
                }
                );
                
                creditsButton.GetComponent<Button>().onClick.AddListener (() => {

                    credits = true;

			    }
			    );

                instructionsButton.GetComponent<Button>().onClick.AddListener(() =>
                {

                    controls = true;

                }
                );

			    exitButton.GetComponent<Button>().onClick.AddListener (() => { Application.Quit ();});
			break;
		}

        if (controls)
        {
            keys.SetActive(true);
            if (Input.GetKey(KeyCode.Joystick1Button1) || Input.GetKey(KeyCode.Joystick2Button1) || (Input.GetKeyDown(KeyCode.Return)))
            {
                controls = false;
            }
        }
        else
        {
            keys.SetActive(false);
        }

        if (credits)
        {
            cre.SetActive(true);
            if (Input.GetKey(KeyCode.Joystick1Button1) || Input.GetKey(KeyCode.Joystick2Button1) || (Input.GetKeyDown(KeyCode.Return)))
            {
                credits = false;
            }
        }
        else
        {
            cre.SetActive(false);
        }
	}
}
