using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

	// A static field visible from anywhere
	public static bool goalMet = false;
	public AudioSource Victory;
	//public GameObject Congratulations;



	
	void Awake(){
		AudioSource Victory = GetComponent<AudioSource>();
		//GameObject Congratulations = GetComponent<Congratulations> ();
		Victory.Pause();

		//Congratulations.RectTransform.Width = 0.0f;
		//Congratulations.RectTransform.Height = 0.0f;
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
			//Congratulations.transform.localScale.x = 3.5f;
			//Congratulations.transform.localScale.y = 3.5f;
			
			


		}
	}
}
