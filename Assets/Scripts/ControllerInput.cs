using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInput : MonoBehaviour {

	public SteamVR_TrackedController controller;

	// Use this for initialization
	void Start () {
		controller = GetComponent<SteamVR_TrackedController>();
		controller.TriggerClicked += HandleTriggerClicked;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void HandleTriggerClicked (object sender, ClickedEventArgs e) {
		DojoGameMaster.Instance.ShootPigeon();
	}
}
