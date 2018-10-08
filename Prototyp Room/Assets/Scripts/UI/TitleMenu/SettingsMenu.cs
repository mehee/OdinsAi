using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour {

	public AudioMixer audioMixer;

	// [SerializeField]
	// private float volume;

	// public float MyVolume
	// {
	// 	get{return volume;}
	// }

	public void SetVolume(float volume)
	{
		audioMixer.SetFloat("volume", volume);
	}

	// public float GetVolume()
	// {
	// 	return audioMixer.GetFloat("volume",out volume);
	// }
	
	
}
