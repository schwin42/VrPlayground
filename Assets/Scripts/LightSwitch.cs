using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class LightSwitch : MonoBehaviour {

	public List<GameObject> geometryToHide;

	bool isOn = true;

	float onYAngle = 70;
	float offYAngle = 100;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnHandHoverBegin( Hand hand ) {
		isOn = !isOn;

		//Change switch position
		float targetAngle = isOn ? onYAngle : offYAngle;
		print("target angle" + targetAngle.ToString());
		transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, targetAngle, transform.localEulerAngles.z);

		//Make click noise
		AudioManager.SpawnSoundAtPoint(transform.position, AudioManager.SoundEffect.LightSwitch);
	
		//Toggle wall and ceiling visibility
		foreach (GameObject go in geometryToHide) {
			go.SetActive(isOn);
		}
	}

}
