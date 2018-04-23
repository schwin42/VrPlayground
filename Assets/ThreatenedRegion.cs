using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreatenedRegion : MonoBehaviour {

	bool isReady = false;

	Character self = null;

	public bool IsEmpty {
		get {
			return _threatenedGos.Count == 0;
		}
	}
	private List<GameObject> _threatenedGos = new List<GameObject>();
//	public List<GameObject> ThreatenedGos {
//		get {
//			return _threatenedGos;
//		}
//	}

	public void Initialize(Character character) {
		isReady = true;
	}

	void OnTriggerEnter(Collider collider) {
		if (!isReady) return;
//		print ("collided with " + collider.gameObject.name);
//		if (self == null) return;
//		print (self.gameObject.name + "collided with: " + collider.gameObject.name);
//		Character otherChar = GameController.GetCharacterByGo (collider.gameObject);
//		if (self != otherChar) {
		print (gameObject.name + "collided with: " + collider.gameObject.name);
		_threatenedGos.Add (collider.gameObject);
//		}
	}

	void OnTriggerExit(Collider collider) {
		if (!isReady) return;

//		if (self == null) return;

//		Character otherChar = GameController.GetCharacterByGo (collider.gameObject);
//		if (self != otherChar) {
			_threatenedGos.Remove (collider.gameObject);
//		}
	}


}
