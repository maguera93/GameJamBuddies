﻿using UnityEngine;
using System.Collections;

public class LoadingScreen : MonoBehaviour {

    public enum State { FADEIN, LOADING, FADEOUT }
    public State state;
    public float temp;
    public bool loadCurrentScreen;
    public bool loadNextScreen;
    public bool loadNextScreen3P;
    public bool loadNextScreen4P;
    private LevelLogic levelLogic;
    private DataLogic dataLogic;
    public float tempInit = 1f;
    public Color color;

	// Use this for initialization
	void Start () {
        state = State.FADEOUT;        
        temp = tempInit;
        loadCurrentScreen = false;
        loadNextScreen = false;
        loadNextScreen3P = false;
        loadNextScreen4P = false;
        color = renderer.material.color;
        levelLogic = GameObject.FindGameObjectWithTag("LevelLogic").
            GetComponent<LevelLogic>();
        dataLogic = GameObject.FindGameObjectWithTag("DataLogic").
            GetComponent<DataLogic>();

        DontDestroyOnLoad(transform.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
        
        if (loadCurrentScreen) loadingCurrentLevel();
        if (loadNextScreen) loadingNexttLevel();
        if (loadNextScreen3P) loadingNexttLevel3P();
        if (loadNextScreen4P) loadingNexttLevel4P();
	}
    public void loadingCurrentLevel()
    {
        switch (state)
        {

            case State.FADEOUT:
                color.a = Mathf.Lerp(1, 0, temp / tempInit);
                renderer.material.color = color;
                temp -= Time.deltaTime;
                if (temp <= 0)
                {
                    state = State.LOADING;
                    Debug.Log("your level is loading");
                    temp = 0;
                }
                break;

            case State.LOADING:

                levelLogic.loadCurrentLevel();

                break;
            case State.FADEIN:


                color.a = Mathf.Lerp(0, 1, temp / tempInit);
                renderer.material.color = color;
                temp -= Time.deltaTime;

                if (temp < 0)
                {
                    state = State.FADEOUT;
                    loadCurrentScreen = false;
                    temp = tempInit;
                    //Destroy(this.gameObject);
                    
                }
                break;
        }
    }

    public void loadingNexttLevel()
    {
        switch (state){
        
            case State.FADEOUT:
            color.a = Mathf.Lerp(1, 0, temp / tempInit);
            renderer.material.color = color;
            temp -= Time.deltaTime;
			if (temp <= 0) {
                state = State.LOADING;
				temp = 0;
                Debug.Log("your level is loading");
			}
             break;

            case State.LOADING:
            
            levelLogic.loadNextLevel();

             break;
            case State.FADEIN:

            
            color.a = Mathf.Lerp(0, 1, temp / tempInit);
            renderer.material.color = color;
            temp -= Time.deltaTime;  
            if (temp < 0)
            {

                state = State.FADEOUT;
                loadNextScreen = false;
                temp = tempInit;
                //Destroy(this.gameObject);
            }
            break;
        }
    }

    public void loadingNexttLevel3P()
    {
        switch (state)
        {

            case State.FADEOUT:
                color.a = Mathf.Lerp(1, 0, temp / tempInit);
                renderer.material.color = color;
                temp -= Time.deltaTime;
                if (temp <= 0)
                {
                    state = State.LOADING;
                    temp = 0;
                    Debug.Log("your level is loading");
                }
                break;

            case State.LOADING:

                Application.LoadLevel(dataLogic.getNextLevel() + 1);
                state = State.FADEIN;
                 
                break;
            case State.FADEIN:


                color.a = Mathf.Lerp(0, 1, temp / tempInit);
                renderer.material.color = color;
                temp -= Time.deltaTime;
                if (temp < 0)
                {

                    state = State.FADEOUT;
                    loadNextScreen3P = false;
                    temp = tempInit;
                    //Destroy(this.gameObject);
                }
                break;
        }
    }

    public void loadingNexttLevel4P()
    {
        switch (state)
        {

            case State.FADEOUT:
                color.a = Mathf.Lerp(1, 0, temp / tempInit);
                renderer.material.color = color;
                temp -= Time.deltaTime;
                if (temp <= 0)
                {
                    state = State.LOADING;
                    temp = 0;
                    Debug.Log("your level is loading");
                }
                break;

            case State.LOADING:

                Application.LoadLevel(dataLogic.getNextLevel() + 2);
                state = State.FADEIN;

                break;
            case State.FADEIN:


                color.a = Mathf.Lerp(0, 1, temp / tempInit);
                renderer.material.color = color;
                temp -= Time.deltaTime;
                if (temp < 0)
                {

                    state = State.FADEOUT;
                    loadNextScreen4P = false;
                    temp = tempInit;
                    //Destroy(this.gameObject);
                }
                break;
        }
    }

    void OnLevelWasLoaded(int level)
    {

        if ((level == dataLogic.getCurrentLevel()) || (level == dataLogic.getNextLevel()))
        {
            temp = tempInit;
            state = State.FADEIN;
            Debug.Log("your level was loaded!!!");
        }
    }

}
