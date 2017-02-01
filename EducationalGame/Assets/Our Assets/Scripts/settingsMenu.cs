using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settingsMenu : MonoBehaviour {
    private GameObject mainMenu;
    void Awake()
    {
        this.mainMenu = GameObject.Find("Main Menu");
    }

	// Use this for initialization
	void Start () {
        this.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void exitSettings()
    {
        this.mainMenu.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
