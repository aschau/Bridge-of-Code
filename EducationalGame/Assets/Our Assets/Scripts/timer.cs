using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour {
	public float maxTime = 180f; //Max Time for Game
	public float _currentTime; //Current Time
	private string textTime; //Getting the time
	public Text textTimer; //The string time
	public bool paused = false;


	// Use this for initialization
	void Start () {
		textTimer = this.GetComponent<Text>();
		_currentTime = maxTime;
	}

	// Update is called once per frame
	void Update () {
		if (!paused) {
			if (_currentTime >= 0) {
				_currentTime -= Time.deltaTime;
				textTimer.text = parsingTime (_currentTime);
			} else {
				SceneManager.LoadScene ("gameOver");
			}

		}
	}

	public string parsingTime(float time)
	{
		return string.Format("{0}:{1:00}", (int)time / 60, (int)time % 60);
	}
}