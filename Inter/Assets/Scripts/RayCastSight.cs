using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastSight : MonoBehaviour
{
    public bool rayOn;


    void Update()
    {        

        if (rayOn == true)
        {
            RayOn();
        }

    }

    void RayOn()
    {
        int layerMask = 1 << 10;

        layerMask = ~layerMask;

        RaycastHit hit;

         if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {

            if (hit.collider.CompareTag("Player"))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
                Debug.Log("Hit");
            }
        
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.blue);
        }
        }
    }

  
}

