using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewBehaviourScript1 : MonoBehaviour {


	private Rigidbody2D myRigidbody;
	public float Speed;
	public float jumpForce;
	private float moveInput;
	private bool faceingRight = true;
	private bool Grounded;
	public Transform groundCheck;
	public float checkRadius;
	public LayerMask WIGround;
	private int extraJumps;
	public int health=5;
	public int maxHealth = 5;
	public int healthAfterLevel = 2;
	public Text healthText;
	public float bulletSpeed;
	public float interval;
	public GameObject bullet;
	public int magic = 2;
	public Text magicText;
	// Use this for initialization
	void Start () {
		health = maxHealth;
		myRigidbody = GetComponent<Rigidbody2D>();

	}

	// Update is called once per frame
	void FixedUpdate () {
		
		Grounded = Physics2D.OverlapCircle(groundCheck.position,checkRadius, WIGround);
		moveInput = Input.GetAxis("Horizontal");
		myRigidbody.velocity = new Vector2(moveInput * Speed, myRigidbody.velocity.y);

		if (faceingRight == false && moveInput > 0) {
			Flip();
		} else if (faceingRight == true && moveInput < 0) {
			Flip();
		}
	}
	
    void Update(){

		if (Grounded == true) {
			extraJumps = 1;
		}
		if (Input.GetKeyDown (KeyCode.UpArrow) && extraJumps > 0) {
			myRigidbody.velocity = Vector2.up * jumpForce;
			extraJumps--;
		} else if (Input.GetKeyDown (KeyCode.UpArrow) && extraJumps == 0 && Grounded == true) {
			extraJumps = 1;
		}
		if (transform.position.y <= 30) {
			magicText.text = "Magic:" + magic;
		}
		healthText.text = "Lives:" + health;
		if (health == 0) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			health = health + 5;
		}
		if(magic > 0 && Input.GetKeyDown(KeyCode.Space)){

			GameObject lightningbulletG;
			lightningbulletG = Instantiate (bullet, transform.position, transform.rotation)as GameObject;
			lightningbulletG.GetComponent<Rigidbody2D> ().velocity = Vector2.right * bulletSpeed;
			magic--;

		}
	}

	void Flip(){
		
		faceingRight = !faceingRight;
		Vector3 Scaler = transform.localScale;
		Scaler.x *= -1;
		transform.localScale = Scaler;
	}

	[SerializeField]private Transform level3Respawn;
	[SerializeField]private Transform level1Respawn;
	[SerializeField]private Transform level2Respawn;
	[SerializeField]private Transform bossRespawn;
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "death3") {
			health--;
			transform.position = level3Respawn.position;
			Vector3 playerPos = level3Respawn.transform.position;
			playerPos.z = 0f;
			transform.position = playerPos;
		}
		if (other.tag == "death") {
			health--;
			transform.position = level1Respawn.position;
			Vector3 playerPos = level1Respawn.transform.position;
			playerPos.z = 0f;
			transform.position = playerPos;
		}
		if (other.tag == "death2") {
			health--;
			transform.position = level2Respawn.position;
			Vector3 playerPos = level2Respawn.transform.position;
			playerPos.z += 0f;
			transform.position = playerPos;
		}
		if (other.tag == "deathboss") {
			health--;
			transform.position = bossRespawn.position;
			Vector3 playerPos = bossRespawn.transform.position;
			playerPos.z = 0f;
			transform.position = playerPos;
		}
		if (other.tag == "portal1") {
			health++;
			magic++;
			magic++;
			transform.position = level2Respawn.transform.position;
			Vector3 playerPos = level2Respawn.transform.position;
			playerPos.z = 0f;
			transform.position = playerPos;
		}
		if (other.tag == "portal2") {
			health++;
			transform.position = level3Respawn.transform.position;
			Vector3 playerPos = level3Respawn.transform.position;
			playerPos.z = 0f;
			transform.position = playerPos;
		}
		if (other.tag == "portal3") {
			health++;
			magic++;
			magic++;
			transform.position = bossRespawn.transform.position;
			Vector3 playerPos = bossRespawn.transform.position;
			playerPos.z = 0f;
			transform.position = playerPos;
		}
		if (other.tag == "portal4") {
			health++;
			magic++;
			magic++;
			transform.position = bossRespawn.transform.position;
			Vector3 playerPos = bossRespawn.transform.position;
			playerPos.z = 0f;
			transform.position = playerPos;
		}
		if (other.tag == "Enermy1") {
			health--;
			transform.position = level1Respawn.transform.position;
		}
		if (other.tag == "Enermy2") {
			health--;
			transform.position = level2Respawn.transform.position;
		}
		if (other.tag == "Enermy3") {
			health--;
			transform.position = level3Respawn.transform.position;
		}




	}
	
}

