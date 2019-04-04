using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dimitri : MonoBehaviour
{

    public AudioSource randomSound;
 
     public AudioClip[] audioSources;

    // Start is called before the first frame update
    void Start()
    {
        CallSound();
    }

    // Update is called once per frame
    void CallSound(){
        Invoke("RandomSound",5);
    }

    void RandomSound(){
         randomSound.clip = audioSources[Random.Range(0, audioSources.Length)];
         randomSound.Play ();
         CallSound ();
    }
}
