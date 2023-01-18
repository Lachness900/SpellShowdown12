using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShoot : MonoBehaviour {
	[SerializeField]private Transform Player;
	public float bulletSpeed;
	public float bulletTime;
	public float interval;
	public GameObject bullet;
	public float distance;
	[SerializeField]private Transform magicTurret1B;
	[SerializeField]private Transform magicTurretB;
	[SerializeField]private Transform magicTurret1;
	[SerializeField]private Transform magicTurret;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance (transform.position, Player.transform.position);

	}
	public void Attack (){
			bulletTime += Time.deltaTime;
			if (bulletTime >= interval && (magicTurret)) {

				GameObject lightningbullet;
				lightningbullet = Instantiate (bullet, magicTurretB.transform.position, magicTurretB.transform.rotation)as GameObject;
				lightningbullet.GetComponent<Rigidbody2D> ().velocity = Vector2.left * bulletSpeed;
				bulletTime = 0;
			}
			if (bulletTime >= interval && (magicTurret1)) {

				GameObject lightningbullet1;
				lightningbullet1 = Instantiate (bullet, magicTurret1B.transform.position, magicTurret1B.transform.rotation)as GameObject; 
				lightningbullet1.GetComponent<Rigidbody2D> ().velocity = Vector2.left * bulletSpeed;
				bulletTime = 0;
			}

	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "goodBullet") {
			Destroy (other);
			Destroy (gameObject);

		}
	}
}


