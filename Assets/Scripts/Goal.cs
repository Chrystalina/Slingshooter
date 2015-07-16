using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

	// A static field visible from anywhere
	public static bool goalMet = false;
	public AudioSource Victory;

	
	void Awake(){
		AudioSource Victory = GetComponent<AudioSource>();
		Victory.Pause();
	}
	

	void OnTriggerEnter(Collider other) {
	//void OnCollisionEnter(Collision other){
		// Check if the hit comes from a projectile
		if(other.gameObject.tag == "Projectile") {
			goalMet = true;
			// Set alpha to higher opacity
			Color c = GetComponent<Renderer>().material.color;
			c.a = 1.0f;
			GetComponent<Renderer>().material.color = c;
			Victory.Play();




		}
	}
}
