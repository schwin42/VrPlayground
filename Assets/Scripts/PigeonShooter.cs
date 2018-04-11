using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonShooter : MonoBehaviour {

	public GameObject pigeonTemplate;
	public float shotForce = 5000;
	public float torqueForce = 100;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Shoot() {
//		print("shoot");
		GameObject go = Instantiate(pigeonTemplate);
		go.transform.position = transform.position;
		Rigidbody rigidbody = go.GetComponent<Rigidbody>();
		print("up: " + go.transform.up.ToString());
		rigidbody.AddForce(gameObject.transform.up * shotForce);
		rigidbody.AddTorque(new Vector3(Random.value, Random.value, Random.value) * torqueForce);
//		rigidbody.AddForce(new Vector3(0, shotForce, 0));
	}
}
