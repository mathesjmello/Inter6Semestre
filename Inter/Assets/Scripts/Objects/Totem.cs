using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totem : MonoBehaviour
{

    public GameObject player;

    public GameObject posterText;
    public bool segurando;



    void Update(){
        if (segurando == true)
        {
             this.transform.parent = player.transform;
        }

        else
        {
            this.transform.parent = null;
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

