using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class codePlacement : MonoBehaviour {
    public bool activated, correct, triggered;
	// Use this for initialization
	void Start () {
        this.activated = false;
        this.correct = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        this.triggered = true;
        if (this.activated && !this.correct)
        {
            other.gameObject.GetComponent<playerControl>().dead = true;
            this.GetComponent<Collider2D>().enabled = false;
            this.gameObject.SetActive(false);
        }
    }
}
