using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bunnyMovement : MonoBehaviour {
	[SerializeField]private Transform Cylinder;
	public float jumpforce = 2f;
	public float Speed;
	private bool faceingRight = false;
	private Rigidbody2D rb;
	private bool Grounded;
	public Transform groundCheck;
	public float checkRadius;
	public LayerMask WIGround;
	public float waitTime;
	private float nextTime = 0;
	public float FSpeed;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update ()
	{
		Grounded = Physics2D.OverlapCircle (groundCheck.position, checkRadius, WIGround);
		nextTime += Time.deltaTime;
		if (Cylinder.transform.position.x - transform.position.x > 0 && Cylinder.transform.position.x - transform.position.x < 10) {
	
			if (Grounded && nextTime >= waitTime) {
				Debug.Log ("Yeeh");
				rb.AddForce (new Vector2 (Speed, jumpforce), ForceMode2D.Impulse);
				Grounded = false;
				nextTime = 0;
			} 

		}
		if (Cylinder.transform.position.x - transform.position.x < 0 && Cylinder.transform.position.x - transform.position.x > -10) {

			if (Grounded && nextTime >= waitTime) {
				Debug.Log ("Yee");
				rb.AddForce (new Vector2 (FSpeed, jumpforce), ForceMode2D.Impulse);
				Grounded = false;
				nextTime = 0;


			}
		}
			if (faceingRight == false && Cylinder.transform.position.x - transform.position.x > 0) {
				Flip ();
			} else if (faceingRight == true && Cylinder.transform.position.x - transform.position.x < 0) {
				Flip ();
			}
	}

	void Flip(){
		Vector3 Scaler = transform.localScale;
		Vector3 position = transform.position;
		Scaler.x *= -1;
		if (faceingRight == true) {
			position.x -= -3f;
		}
		if (faceingRight == false) {
			position.x -= 3f;
		}
		transform.position = position;
		transform.localScale = Scaler;
		faceingRight = !faceingRight;
	}
	IEnumerator wait(){
		yield return new WaitForSeconds (waitTime); 
		rb.velocity = Vector2.zero;
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "goodBullet") {
			Destroy (other);
			Destroy (gameObject);

		}
	}
}


