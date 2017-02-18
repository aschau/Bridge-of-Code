using UnityEngine;

public class helpMenu : MonoBehaviour
{
    private GameObject level1;

    void Awake()
    {
        this.level1 = GameObject.Find("Level 1");
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
    }
}
