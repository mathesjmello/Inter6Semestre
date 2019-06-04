using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public bool ativaRespawn;

    public GameObject player;

    public TesteCharDrunk dimi;

    [Range(0,4)]
    public int fase;

    public Vector3 respawnPos;

    public GameObject checkpoint01;

    public GameObject checkpoint02;

    public GameObject checkpoint03;

    public GameObject checkpoint04;

    public GameObject checkpoint05;

    public NPCAtivos check;

    public Calça save;
    
	private CharacterController playerController;

    public SaveControl autoSave; 

    public MenuPrincipal spawnSave;

    //public SaveData on;

    public int saveMemory;

    public bool acabouRespawn;

    public GameObject fala04;
    public GameObject fala05;
    public GameObject fala06;
    public GameObject fala07;

    public bool ativaSave;



    // Start is called before the first frame update
    void Start()
    {
        //fala01 = GameObject.FindGameObjectWithTag("Fala01");
        //fala02 = GameObject.FindGameObjectWithTag("Fala02");
        //fala03 = GameObject.FindGameObjectWithTag("Fala03");
        fala04 = GameObject.FindGameObjectWithTag("Fala04");
        fala05 = GameObject.FindGameObjectWithTag("Fala05");
        fala06 = GameObject.FindGameObjectWithTag("Fala06");
        fala07 = GameObject.FindGameObjectWithTag("Fala07");

		playerController = player.GetComponent<CharacterController>();
        saveMemory = PlayerPrefs.GetInt("VoltouDoGameOver");

        if (saveMemory >= 1)
        {
            fase = PlayerPrefs.GetInt("Level");
            StartCoroutine(SpawnSave());
            Debug.Log(fase);
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        if (ativaSave)
        {
            autoSave.salvar = true;
        }


        if(fase == 0)
        {
            respawnPos = checkpoint01.transform.position;

            check.disable = 0;

            fala04.SetActive(true);
            fala05.SetActive(true);
            fala06.SetActive(true);
            fala07.SetActive(true);

            save.saveGame = false;
        }

        if (fase == 1)
        {
			//Antes da Sra Dimitri
            
            respawnPos = checkpoint02.transform.position;


            check.disable = 1;

            fala04.SetActive(true);
            fala05.SetActive(true);
            fala06.SetActive(true);
            fala07.SetActive(true);

            save.saveGame = true;   
   
        }

        if (fase == 2)
        {
            //No bar, Antes do guarda do corredor
            
            respawnPos = checkpoint03.transform.position;

            check.disable = 2;

            fala05.SetActive(true);
            fala06.SetActive(true);
            fala07.SetActive(true);

            save.saveGame = true;
            
        }

        if (fase == 3)
        {
            //Antes da bomba
            
            respawnPos = checkpoint04.transform.position;

            check.disable = 3;

            fala05.SetActive(true);
            fala06.SetActive(true);
            fala07.SetActive(true);

            save.saveGame = true;

            
        }

        if (fase == 4)
        {
            //Antes do Salão
            
            respawnPos = checkpoint05.transform.position;


            check.disable = 4;

            fala06.SetActive(true);
            fala07.SetActive(true);

            save.saveGame = true;
   
            
        }

       
    }



    IEnumerator SpawnSave(){
        
        playerController.enabled = false;

        if (fase == 1)
        {
            respawnPos = checkpoint02.transform.position;

            player.transform.position = respawnPos;
            save.saveGame = true; 

            check.disable = 1;
        }

        if (fase == 2)
        {

            respawnPos = checkpoint03.transform.position;

            player.transform.position = respawnPos;

            dimi.carregando = true;
            save.saveGame = true; 

            check.disable = 2;
        }

        if (fase == 3)
        {

            respawnPos = checkpoint04.transform.position;

            player.transform.position = respawnPos;
            
            dimi.carregando = true;
            save.saveGame = true; 

            check.disable = 3;
        }

        if (fase == 4)
        {

            respawnPos = checkpoint05.transform.position;

            player.transform.position = respawnPos;
            
            dimi.carregando = true;
            save.saveGame = true; 

            check.disable = 4;
        }

        yield return new WaitForSeconds(2.0f);

        spawnSave.spawn = false;

        playerController.enabled = true;
    }
}
