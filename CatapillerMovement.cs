using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapillerMovement : MonoBehaviour {
	[SerializeField]private Transform Cylinder;
	public float Speed;
	private bool faceingRight = false;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (Cylinder.transform.position.y > 0) {

			if (Cylinder.transform.position.x - transform.position.x > 0 && Cylinder.transform.position.x - transform.position.x < 10) {
				Vector3 temp = transform.position;
				temp.x += Speed;
				transform.position = temp;
			}
			if (Cylinder.transform.position.x - transform.position.x < 0 && Cylinder.transform.position.x - transform.position.x > -10) {
				Vector3 temp = transform.position;
				temp.x -= Speed;
				transform.position = temp; 
		
		}
		if (faceingRight == false && Cylinder.transform.position.x - transform.position.x > 0) {
			Flip();
		} else if (faceingRight == true && Cylinder.transform.position.x - transform.position.x < 0) {
			Flip();
			}
		
		}
	}
	void Flip(){
		Vector3 Scaler = transform.localScale;
		Vector3 position = transform.position;
		Scaler.x *= -1;
		if (faceingRight == true) {
			position.x -= -4f;
		}
		if (faceingRight == false) {
			position.x -= 4f;
		}
		transform.position = position;
		transform.localScale = Scaler;
		faceingRight = !faceingRight;
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "goodBullet") {
			Destroy (other);
			Destroy (gameObject);

		}
		
	}
}
