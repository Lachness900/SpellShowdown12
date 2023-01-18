using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tristanatan : MonoBehaviour {
	[SerializeField]public Transform Tritanatan;
	public float speed;
	public float bulletSpeed;
	public float bulletTime;
	public float interval;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x > 5) {
			Vector3 Temp = transform.position;
			Temp.x += speed;
			transform.position = Temp;
		}
		if (transform.position.x  < 3) {
			Vector3 Temp = transform.position;
			Temp.x -= speed;
			transform.position = Temp;
		}
	}
}
