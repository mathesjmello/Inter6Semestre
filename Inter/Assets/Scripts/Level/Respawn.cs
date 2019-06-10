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

    public GameObject fala01;
    public GameObject fala02;
    public GameObject fala03;
    public GameObject fala04;
    public GameObject fala05;
    public GameObject fala06;
    public GameObject fala07;

    public bool ativaSave;

    public LargaDimi off;



    // Start is called before the first frame update
    void Start()
    {
		playerController = player.GetComponent<CharacterController>();
        saveMemory = PlayerPrefs.GetInt("VoltouDoGameOver");

        if (saveMemory >= 1)
        {
            fase = PlayerPrefs.GetInt("Level");
            StartCoroutine(SpawnSave());
            //Debug.Log(fase);
        }
        
    }
    

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

            save.saveGame = false;
            ativaSave = true;
        }

        if (fase == 1)
        {
			//Antes da Sra Dimitri
            
            respawnPos = checkpoint02.transform.position;


            check.disable = 1;

            save.saveGame = true;  
            ativaSave = true; 
   
        }

        if (fase == 2)
        {
            //No bar, Antes do guarda do corredor
            
            respawnPos = checkpoint03.transform.position;

            check.disable = 2;

            save.saveGame = true;
            ativaSave = true;
            
        }

        if (fase == 3)
        {
            //Antes da bomba
            
            respawnPos = checkpoint04.transform.position;

            check.disable = 3;

            save.saveGame = true;
            ativaSave = true;

            
        }

        if (fase == 4)
        {
            //Antes do Salão
            
            respawnPos = checkpoint05.transform.position;


            check.disable = 4;

            save.saveGame = true;
            ativaSave = true;
   
            
        }

       
    }



    IEnumerator SpawnSave(){
        
        playerController.enabled = false;

        if (fase == 1)
        {
            respawnPos = checkpoint02.transform.position;

            QuestLog.currentLine = 3;

            fala01.SetActive(false);
            fala02.SetActive(false);
            fala03.SetActive(false);
            fala04.SetActive(true);
            fala05.SetActive(true);
            fala06.SetActive(true);
            fala07.SetActive(true);

            player.transform.position = respawnPos;
            save.saveGame = true; 

            check.disable = 1;
            Debug.Log("fase01");
        }

        if (fase == 2)
        {

            respawnPos = checkpoint03.transform.position;

            QuestLog.currentLine = 2;

            fala01.SetActive(false);
            fala02.SetActive(false);
            fala03.SetActive(false);
            fala04.SetActive(false);
            fala05.SetActive(true);
            fala06.SetActive(true);
            fala07.SetActive(true);

            player.transform.position = respawnPos;

            dimi.carregando = true;
            save.saveGame = true; 
            off.comDimi = false;

            check.disable = 2;
            Debug.Log("fase02");
        }

        if (fase == 3)
        {

            respawnPos = checkpoint04.transform.position;

            QuestLog.currentLine = 3;

            fala01.SetActive(false);
            fala02.SetActive(false);
            fala03.SetActive(false);
            fala04.SetActive(false);
            fala05.SetActive(true);
            fala06.SetActive(true);
            fala07.SetActive(true);

            player.transform.position = respawnPos;
            
            dimi.carregando = true;
            save.saveGame = true;

            off.comDimi = false; 

            check.disable = 3;
            Debug.Log("fase03");
        }

        if (fase == 4)
        {

            respawnPos = checkpoint05.transform.position;

            QuestLog.currentLine = 2;

            fala01.SetActive(false);
            fala02.SetActive(false);
            fala03.SetActive(false);
            fala04.SetActive(false);
            fala05.SetActive(true);
            fala06.SetActive(true);
            fala07.SetActive(true);

            player.transform.position = respawnPos;
            
            dimi.carregando = true;
            save.saveGame = true; 

            off.comDimi = false;

            check.disable = 4;
            //Debug.Log("fase04");

        }

        yield return new WaitForSeconds(1.0f);

        spawnSave.spawn = false;

        playerController.enabled = true;
    }
}
