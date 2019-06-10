using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totem : MonoBehaviour
{

    public GameObject player;

    public bool segurando;


    public GameObject posterText; 



    void Update(){
        if (segurando == true)
        {
             this.transform.parent = player.transform;
        }

        else
        {
            segurando = false;
        }

    }

    void OnTriggerStay(Collider other)
    {
    if ( other.CompareTag("Player") && Input.GetKeyDown(KeyCode.LeftShift)) 
     { 
         
         segurando = true; 
         posterText.SetActive(false); 
         
     }    
 
     if ( other.CompareTag("Player") && Input.GetKeyUp(KeyCode.LeftShift)) 
     { 
         
         segurando = false; 
         
     }  
 
 
    } 
}

