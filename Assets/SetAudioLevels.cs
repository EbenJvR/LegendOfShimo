using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetAudioLevels : MonoBehaviour {

	public AudioMixer mainMixer;

	public void SetMasterSound(float masterLvl)
	{
		mainMixer.SetFloat ("MasterVol", masterLvl);
	}
	
	public void SetMusicSound(float musicLvl)
	{
		mainMixer.SetFloat ("MusicVol", musicLvl);
	}
}
