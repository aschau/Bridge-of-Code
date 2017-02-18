using UnityEngine;
using UnityEngine.SceneManagement;

public class level1 : MonoBehaviour
{
    private GameObject helpMenu;
    void Awake()
    {
        this.helpMenu = GameObject.Find("Help Menu");
    }
    // Use this for initialization
    void Start()
    {

    }

    public void helpButton()
    {
        this.helpMenu.SetActive(true);
        //this.gameObject.SetActive(false);
    }

    public void exitFromHelpButton()
    {
        this.helpMenu.SetActive(false);
        SceneManager.LoadScene("Level 1");
    }


    // Update is called once per frame
    void Update()
    {

    }
}
