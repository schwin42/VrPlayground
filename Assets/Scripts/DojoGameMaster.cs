using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DojoGameMaster : MonoBehaviour {

	private static DojoGameMaster _instance = null;
	public static DojoGameMaster Instance { 
		get {
			if (_instance == null) {
				_instance = GameObject.FindObjectOfType<DojoGameMaster>();
			}
			return _instance;
		}
	}
	

	public GameObject[] trackers;
	public PigeonShooter pigeonShooter;

	// Use this for initialization
	void Awake () {
		//HACK Something is disabling the trackers, reenable them manually
		trackers = GameObject.FindGameObjectsWithTag("Tracker");

		pigeonShooter = GameObject.FindObjectOfType<PigeonShooter>();

		StartCoroutine(EnableTrackers());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ShootPigeon() {
		pigeonShooter.Shoot();
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
