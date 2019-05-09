using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mulher : MonoBehaviour
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

    void OnTriggerStay( Collider other){
        if(other.CompareTag("Player")){
            anim.speed = 1.5f;
        }
    }
}
