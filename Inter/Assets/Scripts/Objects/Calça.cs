using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calça : MonoBehaviour
{

    public GameObject texto_03;
    public GameObject texto_04;

    public GameObject dimitri;
    public GameObject esposaFala;

    public GameObject bomba;

    public Animator portaGrandeAnim;

	public GameObject tutoriais;
	public GameObject tutoriais2;

    public Transform porta01;
    public Transform porta02;

    public GameObject song;

    public Respawn check;

    public GameObject checkPoints;

    public AudioSource canto;

    public bool saveGame = false;

    public GameObject calca;

    public GameObject carrinhos;

    public GameObject mesaSalao;
    

    public void Update(){
        if (saveGame)
        {
            PegouCalca();
        }
    }

     private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           // porta01.transform.position = new Vector3(3.757956f, -3.493032f, 14.5f);
           // porta02.transform.position = new Vector3(3.757956f, -3.493032f, 13.75f);
            PegouCalca();
        }
    }

    public void PegouCalca()
    {
            mesaSalao.SetActive(false);
            carrinhos.SetActive(false);
            esposaFala.SetActive(false);
            song.SetActive(true);
			//Destroy(this.gameObject);
            calca.SetActive(false);
			portaGrandeAnim.SetBool("Aberto", true);
            texto_03.SetActive(true);
            texto_04.SetActive(true);
            bomba.SetActive(true);
            dimitri.GetComponent<LargaDimi>().comCalca = true;
			tutoriais.SetActive(false);
			tutoriais2.SetActive(true);
            check.fase = 1;
            checkPoints.SetActive(true);
            canto.Stop();
    }
}
