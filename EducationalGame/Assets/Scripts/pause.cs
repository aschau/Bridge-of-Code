﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour {
	void Awake()
	{
	}

	// Use this for initialization
	void Start () {
		this.gameObject.SetActive (false);
	}

	// Update is called once per frame
	void Update () {

	}

	public void toggleMenu()
	{
		this.gameObject.SetActive (!this.gameObject.activeSelf);
        sceneControl.togglePause();
	}

	public void exit(){
		SceneManager.LoadScene ("Main Menu");
	}

	public void restart(){
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

}
