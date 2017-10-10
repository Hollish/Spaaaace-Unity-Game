using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialObject : MonoBehaviour {
	static float GRAV_CONST = 0.01f;
	private Rigidbody2D rb;
	public float initialSpeed;
	//public GameObject gravTarget;
	public float SOIRadius;
	
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		rb.velocity = transform.TransformDirection(transform.up * initialSpeed);
	}

	public void InfluenceObject(Rigidbody2D obj){
		Vector2 acc = Vector3.zero;
		Vector2 direction = (rb.position - obj.position);
		obj.AddForce(GRAV_CONST * (direction.normalized * obj.mass * rb.mass) / direction.sqrMagnitude); 
	}

	void Update(){
		//Find all objects within radius.
		Collider2D[] hitColliders = Physics2D.OverlapCircleAll(rb.position, SOIRadius);
		foreach (Collider2D obj in hitColliders){
			//Loop through all objects and apply influence to appropriate ones.
			if (obj != rb.GetComponent<Collider2D>()){
				InfluenceObject(obj.gameObject.GetComponent<Rigidbody2D>());
			}
		}
	}
}
