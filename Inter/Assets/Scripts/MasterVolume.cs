using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MasterVolume : MonoBehaviour
{
	public AudioMixer AM;

	[Range(-80f, 20f)]
	[SerializeField]
	public float masterVolume = 0f;
	[Range(-80f, 20f)]
	[SerializeField]
	public float musicVolume = 0f;
	[Range(-80f, 20f)]
	[SerializeField]
	public float sfxVolume = 0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

	    AM.SetFloat("masterVolume", masterVolume);
	    AM.SetFloat("musicsVolume", musicVolume);
	    AM.SetFloat("sfxVolume", sfxVolume);
    }
}
