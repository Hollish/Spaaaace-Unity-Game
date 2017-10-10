using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCannon : MonoBehaviour {
	public LineRenderer line;
	public int damage;
	private bool shootLaser;

	void Start(){
		line.enabled = false;
	}

	public IEnumerator FireLaser(){
		line.enabled = true;
		shootLaser = true;
			while (shootLaser){
				Ray2D ray = new Ray2D(transform.position, transform.forward);
				RaycastHit2D hit;

				Vector3[] laserPoints = new Vector3[2];

				laserPoints[0] = ray.origin;
		
				hit = Physics2D.Raycast(transform.position, transform.forward);
	
				if (hit.collider){
					laserPoints[1] = hit.point;
					SpaceShip hitObject = hit.rigidbody.gameObject.GetComponent<SpaceShip>();
					if (hitObject != null){
						hitObject.ApplyDamage(damage);
					}
				}else{
					laserPoints[1] = ray.GetPoint(25);
				}
				line.SetPositions(laserPoints);
				yield return null;
			}
        line.enabled = false;
	}

	public void StopFiring(){
		shootLaser = false;
	}
}
