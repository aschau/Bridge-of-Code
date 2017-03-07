using UnityEngine;
using UnityEngine.SceneManagement;

public class tutorialControl : MonoBehaviour {
    private TextAsset tutorial, failure;
    private GameObject chatBox, player;
    private playerControl playerController;
    private dialogueControl dControl;
    private int index = 0; //which part of the tutorial that the user has to interact with, in order

    //gameOver & victory load:
    private GameObject _gameOver;
    private GameObject _victory;
    void Awake()
    {
        this.player = GameObject.Find("Player");
        this.playerController = this.player.GetComponent<playerControl>();
        this.chatBox = GameObject.Find("Chat Box");
        this.dControl = this.chatBox.GetComponent<dialogueControl>();
        this.tutorial = (TextAsset)Resources.Load(SceneManager.GetActiveScene().name);
        this.failure = (TextAsset)Resources.Load(SceneManager.GetActiveScene().name + " Fail");

        this._gameOver = GameObject.Find("GameOver");
        this._victory = GameObject.Find("Victory");
       

    }

	// Use this for initialization
	void Start ()
    {
        sceneControl.paused = true;
        sceneControl.locked = true;
        Invoke("toggleChatBox", 1f);
        this.dControl.startDialogue(this.tutorial, 0);

        _gameOver.SetActive(false);
        _victory.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (dControl.locked)
        {
            if (this.playerController.walkPoints[index].correct)
            {
                this.dControl.advanceIndex();
                this.index++;
                sceneControl.toggleLock();
                sceneControl.togglePause();

            }
            else if (this.playerController.dead)
            {
                sceneControl.toggleLock();
                sceneControl.togglePause();
                this.dControl.startDialogue(this.failure, this.index);

                _gameOver.SetActive(true);

                
            }
        }
	}

    private void toggleChatBox()
    {
        this.chatBox.SetActive(!this.chatBox.activeSelf);
    }

  
    
}
