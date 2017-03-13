using UnityEngine;

public class sceneControl : MonoBehaviour {
    public static bool paused, locked;
    void Awake()
    {
        paused = false;
    }


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () 
    {
	}

    public static void togglePause(bool state)
    {
        if (!locked)
            paused = state;
        Debug.Log("Paused: " + paused);
    }

    public static void toggleLock(bool state)
    {
        locked = state;
        Debug.Log("Locked: " + locked);
    }
}
