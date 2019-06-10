using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totem : MonoBehaviour
{

    public GameObject player;

    public bool segurando;



    void Update(){
        if (segurando == true)
        {
             this.transform.parent = player.transform;
        }

        if (segurando == false)
        {
            this.transform.parent = null;
        }

        if (segurando == true && Input.GetKey(KeyCode.E))
        {
            segurando = false;
        }

    }

    void OnTriggerStay(Collider other)
    {
     if (segurando == false && other.CompareTag("Player") && Input.GetKey(KeyCode.E))
     {
        
         segurando = true;
        
     }   
    }
}

