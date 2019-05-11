using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargaDimi : MonoBehaviour
{

    public GameObject player;
    public GameObject dimitri;
    public bool comDimi;

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
        if(other.CompareTag("Player") & Input.GetKey(KeyCode.E) && comDimi == false && player.GetComponent<TesteCharDrunk>().carregando == true)
        {
            StartCoroutine(LargaDimitri());
        }

        else if (other.CompareTag("Player") & Input.GetKey(KeyCode.E) && comDimi == true)
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
         player.GetComponent<TesteCharDrunk>().carregando = true;
         dimitri.SetActive(false);
         yield return new WaitForSeconds(3.0f);
         comDimi = false;
    }
}
