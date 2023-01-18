using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodBullet : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Enermy1") {
			DestroyObject(gameObject);
		}
		if (other.tag == "Enermy2") {
			DestroyObject (gameObject);
		}
		if (other.tag == "Enermy3") {
			DestroyObject(gameObject);
		}
	}
}
