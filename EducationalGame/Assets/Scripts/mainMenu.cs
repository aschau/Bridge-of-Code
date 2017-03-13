using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour {
	private GameObject settingsMenu, levelMenu;
	private AudioSource buttonSound;

    void Awake()
    {
        this.settingsMenu = GameObject.Find("Settings Menu");
        this.levelMenu = GameObject.Find("Level Select Menu");
		this.buttonSound = GameObject.Find("Button Sound").GetComponent<AudioSource>();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void playButton()
    {
        this.levelMenu.SetActive(true);
        this.gameObject.SetActive(false);
		playSound ();
    }

    public void settingsButton()
    {
        this.settingsMenu.SetActive(true);
        this.gameObject.SetActive(false);
		playSound ();
    }

    public void exitButton()
    {
        Application.Quit();
		playSound ();
    }

	private void playSound()
	{
		this.buttonSound.Play();
	}
}
