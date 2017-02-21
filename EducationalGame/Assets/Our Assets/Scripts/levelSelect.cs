using UnityEngine;
using UnityEngine.SceneManagement;

public class levelSelect : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void backButton()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
