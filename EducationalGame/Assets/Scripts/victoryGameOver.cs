using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class victoryGameOver : MonoBehaviour {

    //gameOver & victory load:
    private GameObject _gameOver;
    private GameObject _victory;
    private GameObject player;
    private playerControl playerController;
	private AudioSource winSound;
	private AudioSource loseSound;
	private AudioSource buttonSound;

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
        _gameOver.SetActive(false);
        _victory.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {

	    if (!sceneControl.paused)
	    {
            print(this.playerController.currentPoint);
            print(this.playerController.walkPoints.Count);
            if (this.playerController.dead)
	        {
                playWinSound();
                StartCoroutine(DeadCoroutine());

	        }

            else if ((this.playerController.currentPoint == (this.playerController.walkPoints.Count - 1)) && this.playerController.move && this.playerController.stopMove) 
            {
                playLoseSound();
                StartCoroutine(WinCoroutine());
            }

          
	    }

	}

    IEnumerator WinCoroutine()
    {

        //This is a coroutine
        
        yield return new WaitForSeconds(0.5f); //Wait....
        //sceneControl.togglePause();

        _victory.SetActive(true);
        

    }

    IEnumerator DeadCoroutine()
    {
        //This is a coroutine
        
        yield return new WaitForSeconds(0.5f); //Wait...
                                                // sceneControl.togglePause();
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
