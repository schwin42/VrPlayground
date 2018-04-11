using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

	int weaponLayer;
//	public AudioClip soundEffect;
	public AudioSource audioSource;

	// Use this for initialization
	void Start () {
		weaponLayer = LayerMask.NameToLayer("Weapon");
//		soundEffect = Resources.Load("Sounds/LightSwitch");
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision other){
		
		if (other.gameObject.layer == weaponLayer) {
			print("Collision enter");
			audioSource.Play();
			//		Destroy (gameObject);
//			Destroy(gameObject);
		}
	}
}
