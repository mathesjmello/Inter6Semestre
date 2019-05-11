using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta_A : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            anim.SetTrigger("AbriPorta");
        }
    }
}
