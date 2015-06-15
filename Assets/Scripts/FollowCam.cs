using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour {

	public static FollowCam S;

	public GameObject poi; //poi=Point of Interest, thing camera has to follow

	private float camZ;

	void Awake() {
		S = this;
		camZ = this.transform.position.z;
	}

	void Update() {
		if (poi == null) { //null in inspector shown as "none" (because you can't set an object to zero)
			return;
		}

		Vector3 destination = poi.transform.position; //.transform.position because you only want the destination to have the 
		//coordinates as poi. with transform.position it only grabs the coordinates

		destination.z = camZ;

		transform.position = destination;
	}

}