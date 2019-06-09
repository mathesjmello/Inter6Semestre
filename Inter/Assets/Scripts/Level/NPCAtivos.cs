using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAtivos : MonoBehaviour
{

    [Range(0,4)]
    public int disable;
    public GameObject npcParte01;
    public GameObject npcParte02; 

    public GameObject npcParte03;
    public GameObject npcParte04;


    public GameObject npc02A;

    public GameObject npc02B;

    public GameObject npc04;

    public GameObject npc05;

    public GameObject npc06;

    public GameObject npc07;

    public GameObject npc08;

    public GameObject npc09;



    

    // Start is called before the first frame update
    void Start()
    {

        /*/npc02A = GameObject.FindGameObjectWithTag("NPC02A");
        npc02B = GameObject.FindGameObjectWithTag("NPC02B");

        npc04 = GameObject.FindGameObjectWithTag("NPC04");
        npc05 = GameObject.FindGameObjectWithTag("NPC05");
        npc06 = GameObject.FindGameObjectWithTag("NPC06");
        npc07 = GameObject.FindGameObjectWithTag("NPC07");
        npc08 = GameObject.FindGameObjectWithTag("NPC08");
        npc09 = GameObject.FindGameObjectWithTag("NPC09");*/
        
    }

    // Update is called once per frame
    void Update()
    {
        if (disable == 0)
        {
            npcParte01.SetActive(true);
           // npc02.SetActive(false);
            npcParte03.SetActive(false);
            npcParte04.SetActive(false);
        }

        if (disable == 1)
        {
			//Antes da Sra Dimitri
            npcParte01.SetActive(false);
            npcParte02.SetActive(true);
            npcParte03.SetActive(false);
            npcParte04.SetActive(false);
        }


        if (disable == 2)
        {
            //No bar, Antes do guarda do corredor
            npcParte01.SetActive(true);
            npcParte03.SetActive(false);
            npcParte04.SetActive(false);


            //sraDimi.GetComponent<FieldOfView>().enabled = false;
        }

        if (disable == 3)
        {
            //Antes da bomba
            npcParte01.SetActive(false);
            npcParte03.SetActive(true);
            npcParte04.SetActive(false);
            
            npc02A.GetComponent<FieldOfView>().enabled = true;

            npc02B.GetComponent<FieldOfView>().enabled = true;

            npc04.GetComponent<FieldOfView>().enabled = true;
        }

        if (disable == 4)
        {
            //Antes do Salão
            npcParte01.SetActive(false);
            npcParte03.SetActive(true);
            npcParte04.SetActive(true);

            npc02A.GetComponent<FieldOfView>().enabled = true;

            npc02B.GetComponent<FieldOfView>().enabled = true;

            npc04.GetComponent<FieldOfView>().enabled = true;

            npc05.GetComponent<FieldOfView>().enabled = true;

            npc06.GetComponent<FieldOfView>().enabled = true;

            npc07.GetComponent<FieldOfView>().enabled = true;

            npc08.GetComponent<FieldOfView>().enabled = true;

            npc09.GetComponent<FieldOfView>().enabled = true;
        }        
        
    }
    
}
