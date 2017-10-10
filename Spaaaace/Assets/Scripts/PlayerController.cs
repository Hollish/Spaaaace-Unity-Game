using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float thrustMultiplier;
	public float turnMultiplier;
	public Vector2 initalForce;
    private Rigidbody2D rb; //The player object's rigidbody.
	public Animator engineAnim;
	public Animator rcsAnim;
	public AudioSource sfx;
	public AudioClip burnStartSound;
	public float audioLoopDelay;
	public LaserCannon cannon1;
	public LaserCannon cannon2;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		rb.AddForce(initalForce);
	}
	
	// Update is called once per frame
	void Update () {
		//Get Thrust changes
		if (Input.GetAxis("Thruster") > 0){
			engineAnim.SetBool("IsBurning",true);
			if (!sfx.isPlaying){
					sfx.PlayOneShot(burnStartSound);
					sfx.PlayDelayed(audioLoopDelay);
			}
			rb.AddForce(transform.up * thrustMultiplier * Input.GetAxis("Thruster"));
		} else {
			engineAnim.SetBool("IsBurning",false);
			if (sfx.isPlaying){
				sfx.Stop();
			}
		}

		//Add spin.
		if (Input.GetAxis("Turning") > 0){
			rcsAnim.SetBool("TurnLeft",true);
			rcsAnim.SetBool("TurnRight",false);
		} else if (Input.GetAxis("Turning") < 0){
			rcsAnim.SetBool("TurnRight",true);
			rcsAnim.SetBool("TurnLeft",false);
		} else {
			rcsAnim.SetBool("TurnLeft",false);
			rcsAnim.SetBool("TurnRight",false);
		}
		rb.AddTorque(Input.GetAxis("Turning") * turnMultiplier);

		if (Input.GetButtonDown("Fire")){
			StartCoroutine(cannon1.FireLaser());
			StartCoroutine(cannon2.FireLaser());
		} else if (Input.GetButtonUp("Fire")){
			cannon1.StopFiring();
			cannon2.StopFiring();
		}
	}
}
