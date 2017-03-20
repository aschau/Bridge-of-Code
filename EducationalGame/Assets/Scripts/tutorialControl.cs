using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class tutorialControl : MonoBehaviour {
    public Sprite blob, blobDead;

	private TextAsset tutorial, failure, victory;
	private GameObject chatBox, player;
	private playerControl playerController;
	private dialogueControl dControl;
	private int index = 0; //which part of the tutorial that the user has to interact with, in order
    private bool endToggle = false;

	void Awake()
	{
		this.player = GameObject.Find("Player");
		this.playerController = this.player.GetComponent<playerControl>();
		this.chatBox = GameObject.Find("Chat Box");
		this.dControl = this.chatBox.GetComponent<dialogueControl>();
		this.tutorial = (TextAsset)Resources.Load(SceneManager.GetActiveScene().name);
		this.failure = (TextAsset)Resources.Load(SceneManager.GetActiveScene().name + " Fail");
        this.victory = (TextAsset)Resources.Load(SceneManager.GetActiveScene().name + " Victory");
	}

	// Use this for initialization
	void Start ()
	{
		sceneControl.paused = true;
		sceneControl.locked = true;
        //Invoke("toggleChatBox", 1f);
		this.dControl.startDialogue(this.tutorial, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (dControl.locked)
		{
            if (this.playerController.walkPoints[index].triggered)
            {
                if (this.playerController.walkPoints[index].correct)
                {
                    this.dControl.advanceIndex();
                    this.index++;


                }
            }
		}

        if (this.playerController.dead && !this.endToggle)
        {
            this.dControl.startDialogue(this.failure, this.index);
            this.endToggle = true;
            if (SceneManager.GetActiveScene().name == "Level 4")
            {
                this.dControl.transform.GetChild(0).GetComponent<Image>().sprite = this.blobDead;
            }
        }

        else if (((this.playerController.currentPoint == (this.playerController.walkPoints.Count - 1) && this.playerController.move && this.playerController.stopMove)) || Input.GetKeyDown(KeyCode.K))
        {
            this.dControl.startDialogue(this.victory, 0);
            Debug.Log("VICTORY");
            this.endToggle = true;
            this.dControl.transform.GetChild(0).GetComponent<Image>().sprite = this.blob;
        }
	}

	private void toggleChatBox()
	{
		this.chatBox.SetActive(!this.chatBox.activeSelf);
	}

	



	



 }
