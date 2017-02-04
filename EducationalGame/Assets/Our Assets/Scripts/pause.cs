using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour {
	private timer timerObject;

	void Awake()
	{
		timerObject = GameObject.Find ("Timer").GetComponent<timer>();
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
		if (this.gameObject.activeSelf) {
			timerObject.paused = true;
		} else {
			timerObject.paused = false;
		}
	}

	public void exit(){
		SceneManager.LoadScene ("Main Menu");
	}

	public void restart(){
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

}

