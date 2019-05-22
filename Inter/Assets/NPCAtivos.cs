using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAtivos : MonoBehaviour
{

    [Range(0,4)]
    public int disable;
    public GameObject npc01;

    public GameObject sraDimi;
    public GameObject npc02;

    public GameObject npc03;

    public GameObject npc03A;

    public GameObject npc03B;

    public GameObject npc03C;

    public GameObject npc04;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (disable == 0)
        {
            npc01.SetActive(true);
           // npc02.SetActive(false);
            npc03.SetActive(false);
            npc04.SetActive(false);
        }

        if (disable == 1)
        {
			//Antes da Sra Dimitri
            npc01.SetActive(false);
            npc02.SetActive(true);
            npc03.SetActive(false);
            npc04.SetActive(false);
        }


        if (disable == 2)
        {
            //No bar, Antes do guarda do corredor
            npc01.SetActive(true);
            npc03.SetActive(false);
            npc04.SetActive(false);

            sraDimi = GameObject.FindWithTag("NPC02");
            sraDimi.GetComponent<FieldOfView>().enabled = false;
        }

        if (disable == 3)
        {
            //Antes da bomba
            npc01.SetActive(false);
            npc03.SetActive(true);
            npc04.SetActive(false);
        }

        if (disable == 4)
        {
            //Antes do Salão
            npc04.SetActive(true);

            npc03A = GameObject.FindWithTag("NPC03");
            npc03A.GetComponent<FieldOfView>().enabled = false;

            npc03B.GetComponent<FieldOfView>().enabled = false;

            npc03C.GetComponent<FieldOfView>().enabled = false;

        }        
        
    }
}
