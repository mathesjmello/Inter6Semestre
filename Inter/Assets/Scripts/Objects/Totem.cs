using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totem : MonoBehaviour
{

    public GameObject player;





    void OnTriggerStay(Collider other)
    {
     if (other.CompareTag("Player") && Input.GetKey(KeyCode.E))
     {
         this.transform.parent = player.transform;
        
     }   
    }
}

