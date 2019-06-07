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

    public bool levantando = false;

    public bool largando = false;

    public GameObject somDimitri;

    public LargaDimi areaDimi02;

    public LargaDimi areaDimi03;


    // Start is called before the first frame update
    void Start()
    {
        CallSound();
    }

    // Update is called once per frame
    void Update()
    {
       if (comDimi)
        {
            somDimitri.SetActive(true);
        }
        else
        {
            somDimitri.SetActive(false);
            dimitri.SetActive(false);
        }

        if (comCalca)
        {
            areaDimi02.comCalca = true;
            areaDimi03.comCalca = true;
        }
        
    }

        void CallSound(){
        Invoke("RandomSound",10);
    }


    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player") & Input.GetKey(KeyCode.E) && comDimi == false && player.GetComponent<TesteCharDrunk>().carregando == true && largando == false)
        {
            StartCoroutine(LargaDimitri());
            Debug.Log("AreaLarga");
            
        }

         if (other.CompareTag("Player") & Input.GetKey(KeyCode.E) && comDimi == true  && player.GetComponent<TesteCharDrunk>().carregando == false && comCalca == true && levantando == false)
        {
            StartCoroutine(LevantaDimitri());
            Debug.Log("AreaLeveanta");
            
        }

    }

    IEnumerator LargaDimitri()
    {
            player.GetComponent<TesteCharDrunk>().carregando = false;
            largando = true;
            
            Debug.Log("Larga1");
            yield return new WaitForSeconds(1.0f);
            comDimi = true;
            dimitri.SetActive(true);
            Debug.Log("Larga2");
            largando = false;
            
    }

    IEnumerator LevantaDimitri(){
        dimiAnim.SetTrigger("Levanta");
        sergueiAnim.SetTrigger("LevantaDimi");
        levantando = true;
         yield return new WaitForSeconds(1.0f);
        player.GetComponent<TesteCharDrunk>().carregando = true;
         comDimi = false; 
         dimitri.SetActive(false);
         Debug.Log("Levanta");
         levantando = false;
    }

        void RandomSound(){
         randomSound.clip = audioSources[Random.Range(0, audioSources.Length)];
         randomSound.Play ();
         CallSound ();
    }

}
