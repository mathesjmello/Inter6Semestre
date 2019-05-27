using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{

    public GameObject textOnTheWall;


    private void Start()
    {
        textOnTheWall.SetActive(false);
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textOnTheWall.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textOnTheWall.SetActive(false);
        }
    }
}
