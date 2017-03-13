using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelSelectMenu : MonoBehaviour {
    private GameObject mainMenu;
	private AudioSource buttonSound;

    void Awake()
    {
        this.mainMenu = GameObject.Find("Main Menu");
		this.buttonSound = GameObject.Find("Button Sound").GetComponent<AudioSource>();
    }

    // Use this for initialization
	void Start () {
        this.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void exitLevelMenu()
    {
        this.mainMenu.SetActive(true);
        this.gameObject.SetActive(false);
		playSound ();
    }

	private void playSound()
	{
		this.buttonSound.Play();
	}
}
