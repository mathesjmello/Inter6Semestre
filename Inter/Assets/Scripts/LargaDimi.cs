using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargaDimi : MonoBehaviour
{

    public GameObject player;
    public GameObject dimitri;
    public Animator dimiAnim;

    public Animator sergueiAnim;
    public bool comDimi;


    public AudioSource randomSound;
 
     public AudioClip[] audioSources;

     public bool comCalca = false;
    // Start is called before the first frame update
    void Start()
    {
         CallSound();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        void CallSound(){
        Invoke("RandomSound",10);
    }


    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player") & Input.GetKey(KeyCode.E) && comDimi == false && player.GetComponent<TesteCharDrunk>().carregando == true)
        {
            StartCoroutine(LargaDimitri());
        }

        else if (other.CompareTag("Player") & Input.GetKey(KeyCode.E) && comDimi == true  && player.GetComponent<TesteCharDrunk>().carregando == false && comCalca == true)
        {
            StartCoroutine(LevantaDimitri());
        }

    }

    IEnumerator LargaDimitri()
    {
            player.GetComponent<TesteCharDrunk>().carregando = false;
            dimitri.SetActive(true);
            yield return new WaitForSeconds(3.0f);
            comDimi = true;
    }

    IEnumerator LevantaDimitri(){
        dimiAnim.SetTrigger("Levanta");
        sergueiAnim.SetTrigger("LevantaDimi");
         yield return new WaitForSeconds(3.0f);
        player.GetComponent<TesteCharDrunk>().carregando = true;
         comDimi = false; 
         dimitri.SetActive(false);
    }
}
