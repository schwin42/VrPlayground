using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

[RequireComponent( typeof( Interactable ) )]
public class BellRing : MonoBehaviour {

	public AudioClip sound;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnHandHoverBegin( Hand hand )
	{
		AudioManager.SpawnSoundAtPoint(transform.position, AudioManager.SoundEffect.BellRing);
	}
}
