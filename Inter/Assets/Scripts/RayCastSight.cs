using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RayCastSight : MonoBehaviour
{
    public bool rayOn;

    public bool soundPlayed = false;
    public int rayCheck = 0;

    public AudioSource npcSound;

    void Update()
    {        

        if (rayOn == true)
        {
            RayOn();
        }

        if (rayCheck == 1 && soundPlayed == false)
        {
            npcSound.Play();
        }
        if (soundPlayed == true)
        {
            SceneManager.LoadScene("J1");
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
                SceneManager.LoadScene("Fase01");
                rayCheck = 1;
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

