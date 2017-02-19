using UnityEngine;

public class level1 : MonoBehaviour
{
    private GameObject _helpMenu;
    void Awake()
    {
        this._helpMenu = GameObject.Find("Help Menu");
    }
    // Use this for initialization
    void Start()
    {

    }

    public void HelpButton()
    {
        _helpMenu.SetActive(true);
        //this.gameObject.SetActive(false);
    }

    public void ExitFromHelpButton()
    {
        _helpMenu.SetActive(false);
        //GameObject.Find("Main Screen").SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {

    }
}
