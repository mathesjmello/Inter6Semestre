using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movel : MonoBehaviour
{
    public float speed = 3.0f; 
 
    private Transform target; 
 
    public GameObject player; 
 
    public bool canArrasta; 
 
    public bool arrastaMov = true; 
 
 
 
    void Awake() 
    { 
        target = player.transform; 
 
    } 
 
     void Update() 
    { 
 
 
     
        if (canArrasta == true) 
        { 
 
        float step =  speed * Time.deltaTime; 
        transform.position = Vector3.MoveTowards(transform.position, target.position, step); 
        } 
 
 
        //if (Vector3.Distance(transform.position, target.position) < 0.001f) 
        //{ 
             
             
        //} 
 
 
 
        if(Input.GetKeyUp(KeyCode.LeftShift)) 
        { 
            canArrasta = false; 
        } 
         
 
    } 
 
 
 
    void OnTriggerStay(Collider other) 
    { 
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.LeftShift) && arrastaMov == true) 
		{ 
			canArrasta = true; 
		} 
 
    } 
 
}
