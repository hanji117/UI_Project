using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;//needed for reference

public class settingsScript : MonoBehaviour {

	//we need a reference to our audio mixer
	public AudioMixer audioMixer;

	public void SetVolume(float volume)//public to trigger it from our slider. Void returns nothing
	{
		//Debug.Log (volume);
		audioMixer.SetFloat("volume", volume);//"volume" is the name given in the parameter under audio 
									 //mixer tab
	}
}
