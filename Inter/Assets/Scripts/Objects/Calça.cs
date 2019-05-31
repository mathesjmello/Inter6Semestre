using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calça : MonoBehaviour
{

    public GameObject fala_04;
    public GameObject fala_05;
    public GameObject fala_06;
    public GameObject fala_07;

    public GameObject cameraMulher;
    
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

    public void Start()
    {
        fala_04.SetActive(false);
        fala_05.SetActive(false);
        fala_06.SetActive(false);
        fala_07.SetActive(false);
        cameraMulher.SetActive(false);
    }


    public void Update()
    {
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
        cameraMulher.SetActive(true);
        mesaSalao.SetActive(false);
        carrinhos.SetActive(false);
        esposaFala.SetActive(false);
        song.SetActive(true);
        //Destroy(this.gameObject);
        calca.SetActive(false);
        portaGrandeAnim.SetBool("Aberto", true);
        fala_04.SetActive(true);
        fala_05.SetActive(true);
        fala_06.SetActive(true);
        fala_07.SetActive(true);
        //bomba.SetActive(true);
        dimitri.GetComponent<LargaDimi>().comCalca = true;
        tutoriais.SetActive(false);
        tutoriais2.SetActive(true);
        check.fase = 1;
        checkPoints.SetActive(true);
        canto.Stop();
    }
}
