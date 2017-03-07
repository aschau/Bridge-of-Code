using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class levelButton : MonoBehaviour {

	public static int levelCount = 1;
	public Button myButton;

	// Use this for initialization
	void Start () {
		myButton = this.GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update () {
		if (levelCount < Convert.ToInt32(this.gameObject.name.Substring(5)))
		{
			myButton.interactable = false;
			PlayerPrefs.SetInt ("levelCount", levelCount);
			PlayerPrefs.Save ();
		}
	}

    public void loadLevel()
    {
        SceneManager.LoadScene(this.name);
    }
}
