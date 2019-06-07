using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta_A : MonoBehaviour
{
    public Animator anim;

    public AudioSource portaSound;
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            anim.SetTrigger("AbriPorta");
            portaSound.Play();
        }
    }
}
