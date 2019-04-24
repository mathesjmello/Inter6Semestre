using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastSight : MonoBehaviour
{
    public bool rayOn;

    public  bool SoundPlayed = false;
    public int RayCheck = 0;

    public AudioSource FindPlayerSound;

    public GameObject player;

    public GameObject spawnPos;

    private Transform spawnTarget;

    public float Speed = 0.1f;

    void Start() {
        spawnTarget = spawnPos.transform;
    }

    void Update()
    {        

        if (rayOn == true)
        {
            RayOn();
        }

        if (RayCheck == 1 && SoundPlayed == false)
        {
            FindPlayerSound.Play(0);
            SoundPlayed = true;

        }
        if (SoundPlayed == true)
        {
        player.GetComponent<TesteCharDrunk>().respawn = true;
        SoundPlayed = false;
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
                RayCheck = 1;
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

