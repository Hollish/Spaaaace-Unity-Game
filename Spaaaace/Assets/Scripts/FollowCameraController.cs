using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCameraController : MonoBehaviour {
	public GameObject target;
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		//Keep pre-game camera offsets.
		offset = transform.position - target.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () 
    {	
		if (target != null){
			transform.position = target.transform.position + offset;
		}
    }
}
