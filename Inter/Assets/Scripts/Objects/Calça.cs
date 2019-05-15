using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calça : MonoBehaviour
{

    public GameObject texto_03;
    public GameObject texto_04;

    public GameObject dimitri;
    public GameObject esposa;

    public GameObject parte02;

    public GameObject bomba;

    public Animator portaGrandeAnim;

	public GameObject tutoriais;
	public GameObject tutoriais2;

  //  public Transform porta01;
   // public Transform porta02;
    

     private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           // porta01.transform.position = new Vector3(3.757956f, -3.493032f, 14.5f);
          //  porta02.transform.position = new Vector3(3.757956f, -3.493032f, 13.75f);
            esposa.SetActive(true);
			Destroy(this.gameObject);
			portaGrandeAnim.SetBool("Aberto", true);
            texto_03.SetActive(true);
            texto_04.SetActive(true);
            parte02.SetActive(true);
            bomba.SetActive(true);
            dimitri.GetComponent<Dimitri>().comCalca = true;
			tutoriais.SetActive(false);
			tutoriais2.SetActive(true);
        }
    }
}
