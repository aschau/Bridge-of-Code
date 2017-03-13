using UnityEngine;
using UnityEngine.SceneManagement;

public class levelSelect : MonoBehaviour {
	private AudioSource buttonSound;

	void Awake()
	{
		this.buttonSound = GameObject.Find("Button Sound").GetComponent<AudioSource>();
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void backButton()
    {
        SceneManager.LoadScene("Main Menu");
		playSound ();
    }

	private void playSound()
	{
		this.buttonSound.Play();
	}
}
