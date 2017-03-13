using UnityEngine;
using UnityEngine.SceneManagement;

public class helpMenu : MonoBehaviour
{
    private GameObject level1;
    private GameObject level2;
	private AudioSource buttonSound;

    void Awake()
    {
        this.level1 = GameObject.Find("Level 1");
        this.level2 = GameObject.Find("Level 2");
		this.buttonSound = GameObject.Find("Button Sound").GetComponent<AudioSource>();
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
        this.level1.SetActive(true);
        this.gameObject.SetActive(false);
		playSound ();
    }

    public void backToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
		playSound ();
    }

    public void loadHelpMenu(GameObject ob)
    {
        ob.SetActive(true);
		playSound ();
    }

    public void inscene_exitHelpMenu(GameObject ob)
    {
        ob.SetActive(false);
		playSound ();
    }

	private void playSound()
	{
		this.buttonSound.Play();
	}
}
