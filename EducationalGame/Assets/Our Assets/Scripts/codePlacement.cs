using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class codePlacement : MonoBehaviour {
    public bool activated, correct;
	// Use this for initialization
	void Start () {
        this.activated = false;
        this.correct = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (this.activated && !this.correct)
        {
            other.gameObject.GetComponent<playerControl>().dead = true;
            this.GetComponent<Collider2D>().enabled = false;
            this.gameObject.SetActive(false);
        }
    }
}
