using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.Audio;

public class AudioOptions : MonoBehaviour {

	public AudioClip Sound_button;
	public AudioSource SFX_Audio,MusicAudio;	
	public Slider SFX_Slider,Music_Slider;

	public void buttonsound() {
	SFX_Audio.clip =Sound_button;
	SFX_Audio.Play();
	}
	public void Sound(AudioClip Clip) {
	SFX_Audio.clip =Clip;
	SFX_Audio.Play();
	}

	void OnDisable(){
		PlayerPrefs.SetFloat ("SFXSound",SFX_Slider.value);
		PlayerPrefs.SetFloat ("MusicSound",Music_Slider.value);
	}
	void Awake(){
		SFX_Slider.value=PlayerPrefs.GetFloat ("SFXSound");
		Music_Slider.value=PlayerPrefs.GetFloat ("MusicSound");
	}

	public void SFXSound(float MValue){ 
		SFX_Audio.volume = MValue;
		}
	public void MusicSound(float MValue){ 
		MusicAudio.volume = MValue;
		}
}