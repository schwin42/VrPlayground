using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {


	public static GameController Instance {
		get {
			if (_instance == null) {
				_instance = GameObject.FindObjectOfType<GameController> ();
			}
			return _instance;
		}
	}
	private static GameController _instance = null;

	public static Dictionary<GameObject, Character> activeCharactersByGo = new Dictionary<GameObject, Character> ();

	public static void RegisterCharacter(GameObject go, Character character) {
		print ("registering character: " + character.name);
		character.OnReady ();
		activeCharactersByGo.Add (go, character);
	}

	public static Character GetCharacterByGo(GameObject gameObject) {
		return activeCharactersByGo [gameObject];
	}
}
