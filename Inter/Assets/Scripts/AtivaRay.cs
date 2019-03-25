using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivaRay : MonoBehaviour
{
    public  bool miraOn;

    public GameObject teste01;
    public GameObject teste02;
    public GameObject teste03;

    public GameObject teste04;

    public GameObject teste05;



    void Update()
    {
        if (miraOn == true)
        {
            teste01.GetComponent<RayCastSight>().rayOn = true;
            teste02.GetComponent<RayCastSight>().rayOn = true;
            teste03.GetComponent<RayCastSight>().rayOn = true;
            teste04.GetComponent<RayCastSight>().rayOn = true;
            teste05.GetComponent<RayCastSight>().rayOn = true;

        }

        else
        {
            teste01.GetComponent<RayCastSight>().rayOn = false;
            teste02.GetComponent<RayCastSight>().rayOn = false;
            teste03.GetComponent<RayCastSight>().rayOn = false;
            teste04.GetComponent<RayCastSight>().rayOn = false;
            teste05.GetComponent<RayCastSight>().rayOn = false;

        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Player")){
            miraOn = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.CompareTag("Player")){
            miraOn = false;
        }
    }
}
