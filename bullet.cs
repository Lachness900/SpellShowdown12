using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col){
	
		if (col.isTrigger != true) {
			if (col.CompareTag ("PLayer")) {
				Destroy (gameObject);
			
			}
			
		}
			
	}}