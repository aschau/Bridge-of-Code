using UnityEngine;
using UnityEngine.SceneManagement;

public class victoryGameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
		
	}
}
