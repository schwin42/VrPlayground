using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

public static class AudioManager {

	public enum SoundEffect {
		BellRing = 0,
		LightSwitch = 1,
	}

	public enum SoundLoop
	{
		AirConditioner = 0
	}

	static Dictionary<SoundEffect, AudioClip> soundClips;

	// Use this for initialization
	public static void Initialize () {
		//Acquire clips
		Object[] clips = Resources.LoadAll("Sounds");
		soundClips = new Dictionary<SoundEffect, AudioClip>();
		foreach (Object clip in clips) {
			AudioClip audioClip = ((AudioClip)clip);
			string fileName = audioClip.name;
			SoundEffect effect = (SoundEffect)Enum.Parse(typeof(SoundEffect), fileName);
			soundClips.Add(effect, audioClip);
		}
	}

	public static void SpawnSoundAtPoint(Vector3 position, SoundEffect effect) {
		GameObject soundGo = new GameObject(effect.ToString());
		soundGo.transform.position = position;
		AudioSource audioSource = soundGo.AddComponent<AudioSource>();
		audioSource.playOnAwake = false;
		audioSource.clip = soundClips[effect];
		audioSource.Play();
	}
}
