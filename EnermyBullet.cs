using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyBullet : MonoBehaviour {
	public TurretShoot shoot;
	public bool isfirst = true;

	void Awake(){
		shoot = gameObject.GetComponentInParent<TurretShoot> ();
	
	}
	void OnTriggerStay2D(Collider2D col){
		if (col.CompareTag ("Player")) {
			shoot.Attack ();
		}
	
	}
}
