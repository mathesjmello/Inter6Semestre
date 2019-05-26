using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint05 : MonoBehaviour
{

    public Respawn check;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player"))
        {
            check.fase = 4;
        }
    }    
}
