using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundControl : MonoBehaviour {
	private GameObject[] sound;
	private float[] soundVolume;
	static float volumeAmount = 1f;

	void Awake(){
		this.sound = GameObject.FindGameObjectsWithTag ("sound");
		this.soundVolume = new float[this.sound.Length];
		for (int i = 0; i < sound.Length; i++) {
			this.soundVolume [i] = this.sound [i].GetComponent<AudioSource> ().volume;
		}
		for (int i = 0; i < this.sound.Length; i++){
			this.sound [i].GetComponent<AudioSource> ().volume = this.soundVolume [i] * volumeAmount;
		}
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
		for (int i = 0; i < this.sound.Length; i++) {
			this.sound [i].GetComponent<AudioSource> ().volume = this.soundVolume [i] * this.GetComponent<Slider> ().value;
		}
	}
}
