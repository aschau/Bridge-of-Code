using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void playButton()
    {
        SceneManager.LoadScene("Level Select");
    }

    public void settingsButton()
    {

    }
    public void exitButton()
    {
        Application.Quit();
    }
}
