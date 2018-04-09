using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DojoGameMaster : MonoBehaviour {

	public GameObject[] trackers;

	// Use this for initialization
	void Awake () {
		//HACK Something is disabling the trackers, reenable them manually
		trackers = GameObject.FindGameObjectsWithTag("Tracker");
		StartCoroutine(EnableTrackers());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator EnableTrackers() {
		print("start");
		yield return new WaitForSeconds(0.1F);
		print("enabling trackers");
		foreach (GameObject go in trackers) {
			print("enable");
			go.SetActive(true);
		}
	}
}
