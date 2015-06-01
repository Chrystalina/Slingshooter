using UnityEngine;
using System.Collections;

public class Slingshot : MonoBehaviour {


	// Fields seen in the Inspector panel
	public GameObject prefabProjectile;


	// Internal variable
	private GameObject launchPoint;
	private Vector3 launchPos;
	private GameObject projectile;

	bool aimingMode;

	void Awake(){
		Transform launchPointTransform = transform.Find ("LaunchPoint");
		launchPoint = launchPointTransform.gameObject;
		launchPoint.SetActive (false);

		launchPos = launchPointTransform.position;
	}

	void OnMouseEnter(){
		launchPoint.SetActive (true);
		//print ("blablablabla");

	}

	void OnMouseExit(){
		launchPoint.SetActive (false);
		//print ("lalalalal");
	}

	void OnMouseDown(){
		aimingMode = true;

		//Instantiate a new projectile
		projectile = Instantiate(prefabProjectile) as GameObject;

		// Start it at the launchpoint
		// Set the projectile's position to the launchPos
		//launchPos is put into the projectile positionat this point
		projectile.transform.position = launchPos;

		// Set isKinematic to true for now
		//Generic type function
		//What the GetComponent gives back is defined in the rectangular brackets (there also could be written SphereCollider, ...)
		projectile.GetComponent<Rigidbody> ().isKinematic = true;

	}

	void Update() {
		//If we're not in aiming mode, do nothing
		if (!aimingMode) {
			return;
		}


		//Get the current mouse position in 2D
		Vector3 mousePos2D = Input.mousePosition;

		//Convert it to 3D world coordinates
		mousePos2D.z = - Camera.main.transform.position.z;
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint (mousePos2D);

	
		//Find the difference between launchPos and mouse position
		Vector3 mouseDelta = mousePos3D - launchPos;

		//Move the projectile to this new position
		projectile.transform.position = mousePos3D;


	}
}
