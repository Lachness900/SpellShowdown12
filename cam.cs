using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class cam : MonoBehaviour {

	private Vector2 velocity;

	public float smoothTimeY;
	public float smoothTimeX;
	[SerializeField]private Transform level2Camera;
	[SerializeField]private Transform level3Camera;
	[SerializeField]private Transform bossCamera;
	public GameObject target;
	public bool bounds;

	public Vector3 minCam;
	public Vector3 maxCam;

	void start() {
		target = GameObject.FindGameObjectWithTag("Player"); 	

	}
	void FixedUpdate ()
	{
		

		
		if (bounds) {
			float posX = Mathf.SmoothDamp (transform.position.x, target.transform.position.x, ref velocity.x, smoothTimeX);
			float posY = Mathf.SmoothDamp (transform.position.y, target.transform.position.y, ref velocity.y, smoothTimeY);
			transform.position = new Vector3(posX, posY, transform.position.z);
			transform.position = new Vector3 (Mathf.Clamp (transform.position.x, minCam.x, maxCam.x),
									Mathf.Clamp(transform.position.y, minCam.y, maxCam.y),
									Mathf.Clamp(transform.position.z, minCam.z, maxCam.z));
			
		}
		if (target.transform.position.y >= 6) {
			transform.position = level2Camera.transform.position;
			float posX = Mathf.SmoothDamp (transform.position.x, target.transform.position.x, ref velocity.x, smoothTimeX);
			float posY = Mathf.SmoothDamp (transform.position.y, target.transform.position.y, ref velocity.y, smoothTimeY);
			transform.position = new Vector3(posX, posY, transform.position.z);
			transform.position = new Vector3 (Mathf.Clamp (transform.position.x, minCam.x, maxCam.x),
				Mathf.Clamp (transform.position.y, minCam.y + 12, maxCam.y + 12),
				Mathf.Clamp (transform.position.z, minCam.z, maxCam.z));
		
		}	
		if (target.transform.position.y >= 18) {
			transform.position = level2Camera.transform.position;
			float posX = Mathf.SmoothDamp (transform.position.x, target.transform.position.x, ref velocity.x, smoothTimeX);
			float posY = Mathf.SmoothDamp (transform.position.y, target.transform.position.y, ref velocity.y, smoothTimeY);
			transform.position = new Vector3(posX, posY, transform.position.z);
			transform.position = new Vector3 (Mathf.Clamp (transform.position.x, minCam.x, maxCam.x),
				Mathf.Clamp (transform.position.y, minCam.y + 24, maxCam.y + 24),
				Mathf.Clamp (transform.position.z, minCam.z, maxCam.z));
			
		
		}	
		if (target.transform.position.y >= 32) {
			
			transform.position = bossCamera.transform.position;
			float posX = Mathf.SmoothDamp (transform.position.x, target.transform.position.x, ref velocity.x, smoothTimeX);
			float posY = Mathf.SmoothDamp (transform.position.y, target.transform.position.y, ref velocity.y, smoothTimeY);
			transform.position = new Vector3 (posX, posY, transform.position.z);
			transform.position = new Vector3 (Mathf.Clamp (transform.position.x, minCam.x, 2.75f),
				Mathf.Clamp (transform.position.y, minCam.y + 36, maxCam.y + 36),
				Mathf.Clamp (transform.position.z, minCam.z, maxCam.z));
		}
	}




}
