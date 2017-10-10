using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour {
	public int hitPoints;
	public AudioClip KillSound;
	public AudioClip BumpSound;
	
	public void ApplyDamage(int damage){
		hitPoints -= damage;
		if (hitPoints <= 0){
			KillShip();
		}
	}

	void KillShip(){
		AudioSource.PlayClipAtPoint(KillSound, gameObject.transform.position);
		Destroy(this.gameObject);
	}

	void OnCollisionEnter2D(Collision2D col){
		AudioSource.PlayClipAtPoint(BumpSound, gameObject.transform.position);
		ApplyDamage((int)col.rigidbody.mass);
	}
}
