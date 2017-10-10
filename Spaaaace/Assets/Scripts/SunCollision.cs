using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunCollision : MonoBehaviour {
	public AudioClip KillSound;
	public float KillSoundVolume;
	private AudioSource sfx;

	void Start(){
		sfx = gameObject.AddComponent<AudioSource>();
		sfx.clip = KillSound;
		sfx.volume = KillSoundVolume;
	}

	void OnCollisionEnter2D(Collision2D col){
		sfx.Play();
		Destroy(col.gameObject);
	}
}
