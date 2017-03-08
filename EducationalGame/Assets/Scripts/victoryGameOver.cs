﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class victoryGameOver : MonoBehaviour {

    //gameOver & victory load:
    private GameObject _gameOver;
    private GameObject _victory;
    private GameObject player;
    private playerControl playerController;


    void Awake()
    {
        this.player = GameObject.Find("Player");
        this.playerController = this.player.GetComponent<playerControl>();

        this._gameOver = GameObject.Find("GameOver");
        this._victory = GameObject.Find("Victory");

    }

    // Use this for initialization
    void Start () {
        _gameOver.SetActive(false);
        _victory.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {

	    if (!sceneControl.paused)
	    {
	        if (this.playerController.dead)
	        {
	            StartCoroutine(DeadCoroutine());

	        }

            else if ((this.playerController.currentPoint == this.playerController.walkPoints.Count - 1) && this.playerController.move) 
            {
                StartCoroutine(WinCoroutine());
            }

          
	    }

	}

    IEnumerator WinCoroutine()
    {

        //This is a coroutine

        yield return new WaitForSeconds(2.5f); //Wait....
        sceneControl.togglePause();
        _victory.SetActive(true);

    }

    IEnumerator DeadCoroutine()
    {
        //This is a coroutine

        yield return new WaitForSeconds(0.85f); //Wait...
        sceneControl.togglePause();
        //do something else
        _gameOver.SetActive(true);
    }

    public void loadVictory()
    {



    }


    public void loadGameOver()
    {
        
    }

    public void load(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
		
	}

    public void exit()
    {
        SceneManager.LoadScene("Main Menu");
    }

}
