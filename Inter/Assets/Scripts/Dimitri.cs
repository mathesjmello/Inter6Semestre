﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dimitri : MonoBehaviour
{

    public AudioSource randomSound;
 
     public AudioClip[] audioSources;

     public bool comCalça;

     public GameObject player;



    // Start is called before the first frame update
    void Start()
    {
        CallSound();
    }

    // Update is called once per frame
    void CallSound(){
        Invoke("RandomSound",10);
    }

    void RandomSound(){
         randomSound.clip = audioSources[Random.Range(0, audioSources.Length)];
         randomSound.Play ();
         CallSound ();
    }

void OnTriggerEnter(Collider other){
    if (other.CompareTag("Player") && Input.GetKey(KeyCode.E))
    {
        if (comCalça == true)
        {
            player.GetComponent<TesteCharDrunk>().carregando =true;
        }
    }
}

}
