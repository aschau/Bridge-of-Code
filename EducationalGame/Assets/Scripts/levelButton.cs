using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelButton : MonoBehaviour {

	public static int levelCount = 1;
	public Button myButton;

	// Use this for initialization
	void Start () {
		myButton = this.GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update () {
		if (levelCount == 1)
		{
			myButton.interactable = true;
		}
	}

    public void loadLevel()
    {
        SceneManager.LoadScene(this.name);
    }
}
