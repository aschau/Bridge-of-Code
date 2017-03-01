using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bgMusicControl : MonoBehaviour {
	private AudioSource bgMusic;
	static float volumeAmount = 1f;
	private float ogVolume;

	void Awake(){
		this.bgMusic = GameObject.Find ("Background Music").GetComponent<AudioSource> ();
		this.ogVolume = this.bgMusic.volume;
		this.bgMusic.volume = this.ogVolume * volumeAmount;
	}

	// Use this for initialization
	void Start () {
		GameObject.Find("Background Music").GetComponent<AudioSource> ().volume = PlayerPrefs.GetFloat ("volume");
		this.GetComponent<Slider> ().value = PlayerPrefs.GetFloat ("slider");
		//this.GetComponent<Slider> ().value = volumeAmount;
	}

	// Update is called once per frame
	void Update () {

	}

	public void setVolume(){
		this.bgMusic.volume = this.ogVolume * this.GetComponent<Slider> ().value;
		volumeAmount = this.GetComponent<Slider> ().value;
		PlayerPrefs.SetFloat ("slider", volumeAmount);
		PlayerPrefs.SetFloat ("volume", this.bgMusic.volume);
		PlayerPrefs.Save ();
	}
}
