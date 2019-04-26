using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movel : MonoBehaviour
{
    public float Speed = 3.0f; 
 
    private Transform _target; 
 
    public GameObject Player; 
 
    public bool CanArrasta; 
 
    public bool ArrastaMov = true; 

    public AudioSource MovelSound;

    //variaveis para saber se algo acontece depois de mover o movel
    
    public bool AfterMove = false;
    
    public Animator Anim;

    public string AnimName= "Cai";
 
 
    void Awake() 
    { 
        _target = Player.transform; 
 
    } 
 
     void Update() 
    { 
        if (CanArrasta == true) 
        { 

        
        
        float step =  Speed * Time.deltaTime; 
        transform.position = Vector3.MoveTowards(transform.position, new Vector3 (_target.position.x, transform.position.y , _target.position.z), step); 
        
        } 
 
 
        //if (Vector3.Distance(transform.position, target.position) < 0.001f) 
        //{ 
             
             
        //} 
 
 
 
        if(Input.GetKeyUp(KeyCode.LeftShift)) 
        { 
            CanArrasta = false; 
            MovelSound.Stop();
        } 
         
 
    } 
 
 
 
    void OnTriggerStay(Collider other) 
    { 
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.LeftShift) && ArrastaMov == true) 
		{ 
			CanArrasta = true;
		    if (AfterMove)
		    {
		        Anim.SetTrigger(AnimName);
		    }

            MovelSound.Play(0);
		} 

 
    } 
 
}
