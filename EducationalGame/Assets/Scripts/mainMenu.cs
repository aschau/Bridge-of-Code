using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour {
    private GameObject settingsMenu, levelMenu;

    void Awake()
    {
        this.settingsMenu = GameObject.Find("Settings Menu");
        this.levelMenu = GameObject.Find("Level Select Menu");
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
    }

    public void settingsButton()
    {
        this.settingsMenu.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void exitButton()
    {
        Application.Quit();
    }

    public void demoButton()
    {
        SceneManager.LoadScene("Help Menu");
    }
}
