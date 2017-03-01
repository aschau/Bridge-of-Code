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
		this.GetComponent<Slider> ().value = volumeAmount;
	}
	
	// Update is called once per frame
	void Update () {
		volumeAmount = this.GetComponent<Slider> ().value;
	}

	public void setVolume(){
		this.bgMusic.volume = this.ogVolume * this.GetComponent<Slider> ().value;
	}
}
