using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour {
    private GameObject settingsMenu;

    void Awake()
    {
        this.settingsMenu = GameObject.Find("Settings Menu");
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void playButton()
    {
        SceneManager.LoadScene("Level Select");
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
