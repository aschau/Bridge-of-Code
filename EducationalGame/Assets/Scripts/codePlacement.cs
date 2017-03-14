using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class codePlacement : MonoBehaviour {
    public bool activated, correct, triggered;
    public int variableAdjustment = 0;
    private AudioSource deathSound;
    private currentVariable variable;

    void Awake()
    {
        this.deathSound = GameObject.Find("Death Sound").GetComponent<AudioSource>();
        this.variable = GameObject.Find("Variable Panel").GetComponent<currentVariable>();
        this.GetComponent<Collider2D>().enabled = false;
    }

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
            this.playdeathSound();
        }

        if (this.variableAdjustment != 0)
        {
            this.variable.updateCurrentVariable(this.variableAdjustment);
        }
    }

    private void playdeathSound()
    {
        this.deathSound.Play();
    }
}
