using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcRay : MonoBehaviour
{

    RaycastHit hit;
    Ray ray;
 

void OnTriggerEnter(Collider other)
	{

        

        if (other.CompareTag("Player")){

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
        }

        }
    }
}

