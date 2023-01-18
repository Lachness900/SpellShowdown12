using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reswanSystem3 : MonoBehaviour {

	[SerializeField]private Transform level3Respawn;
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
		other.transform.position = level3Respawn.position;
	
		}
	}
}
