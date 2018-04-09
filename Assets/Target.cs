using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

	int weaponLayer;

	// Use this for initialization
	void Start () {
		weaponLayer = LayerMask.NameToLayer("Weapon");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.layer == weaponLayer) {
			print("Collision enter");
			//		Destroy (gameObject);
			Destroy(gameObject);
		}
	}
}
