using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class victoryGameOver : MonoBehaviour {

    //gameOver & victory load:
    private GameObject _gameOver;
    private GameObject _victory;
    private GameObject player;
    private playerControl playerController;
	private AudioSource winSound;
	private AudioSource loseSound;
	private AudioSource buttonSound;
    private bool toggled;

    void Awake()
    {
        this.player = GameObject.Find("Player");
        this.playerController = this.player.GetComponent<playerControl>();

        this._gameOver = GameObject.Find("GameOver");
        this._victory = GameObject.Find("Victory");

        this.buttonSound = GameObject.Find("Button Sound").GetComponent<AudioSource>();
        this.winSound = GameObject.Find("Victory Sound").GetComponent<AudioSource>();
        this.loseSound = GameObject.Find("Game Over Sound").GetComponent<AudioSource>();

    }

    // Use this for initialization
    void Start () {
        //_gameOver.SetActive(false);
        //_victory.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {

	    if (!sceneControl.paused && !this.toggled)
	    {
            if (this.playerController.dead)
	        {
                playLoseSound();
                Invoke("gameLose", 0.5f);
                this.toggled = true;

	        }

            else if (((this.playerController.currentPoint == (this.playerController.walkPoints.Count - 1)) && this.playerController.move && this.playerController.stopMove) || Input.GetKeyDown(KeyCode.K))
            {
                playWinSound();
                Invoke("gameWin", 0.5f);
                this.toggled = true;
            }

          
	    }

	}

    private void gameWin()
    {
        _victory.SetActive(true);
        if (levelButton.levelCount == Convert.ToInt32(SceneManager.GetActiveScene().name.Substring(5)))
        {
            levelButton.levelCount++;
            PlayerPrefs.SetInt("levelCount", levelButton.levelCount);
            PlayerPrefs.Save();
        }
    }

    private void gameLose()
    {
        _gameOver.SetActive(true);
        Debug.Log(_gameOver.activeSelf);
    }

    public void load(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
		playSound ();
		
	}

    public void exit()
    {
        SceneManager.LoadScene("Main Menu");
		playSound ();
    }

	private void playWinSound()
	{
        this.winSound.Play();
	}

	private void playLoseSound()
	{
        this.loseSound.Play();
	}

	private void playSound()
	{
        this.buttonSound.Play();
	}
}
