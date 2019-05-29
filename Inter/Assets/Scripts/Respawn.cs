using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public bool ativaRespawn;

    public GameObject player;

    public TesteCharDrunk spawn;

    public TesteCharDrunk dimi;

    [Range(0,4)]
    public int fase;

    public Vector3 respawnPos;

    public GameObject checkpoint01;

    public GameObject checkpoint02;

    public GameObject checkpoint03;

    public GameObject checkpoint04;

    public GameObject checkpoint05;

    public GameObject fadeOut;

    public GameObject npc01;

    public GameObject npc02;

    public GameObject npc03;

    public GameObject npc04;

    public NPCAtivos check;

    public Calça save;


	private CharacterController playerController;

    public GameObject fala03;

    public GameObject fala04;

    public SaveControl autoSave; 

    public MenuPrincipal spawnSave;

    public SaveData on;

    public int saveMemory;



    // Start is called before the first frame update
    void Start()
    {
        //Antes do guarda do correrdor pela 1° vez
        respawnPos = checkpoint01.transform.position;
		playerController = player.GetComponent<CharacterController>();
        saveMemory = autoSave.myVar;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fase == 1)
        {
			//Antes da Sra Dimitri
            autoSave.salvar = true;
            respawnPos = checkpoint02.transform.position;
            check.disable = 1;
            //dimi.carregando = false;
            save.saveGame = false;
            //autoSave.salvar = false;
            
        }

        if (fase == 2)
        {
            //No bar, Antes do guarda do corredor
            autoSave.salvar = true;
            respawnPos = checkpoint03.transform.position;
            check.disable = 2;
            //dimi.carregando = true;
            save.saveGame = true;
            //autoSave.salvar = false;
            
        }

        if (fase == 3)
        {
            //Antes da bomba
            autoSave.salvar = true;
            respawnPos = checkpoint04.transform.position;
            check.disable = 3;
            //dimi.carregando = true;
            save.saveGame = true;
            //autoSave.salvar = false;
            
        }

        if (fase == 4)
        {
            //Antes do Salão
            autoSave.salvar = true;
            respawnPos = checkpoint05.transform.position;
            check.disable = 4;
            //dimi.carregando = true;
            save.saveGame = true;
            //fala03.SetActive(false);
            //autoSave.salvar = false;    
            
        }

        if (ativaRespawn == true)
        {
            ChamouRespawn();
		
        }

        if (spawnSave.spawn)
        {
            SpawnSave();
            spawnSave.spawn = false;
        }


		
        
    }

    void RespawnOn (){
        ativaRespawn = true;
    }

    void ChamouRespawn(){
		playerController.enabled = false;
        player.transform.position = respawnPos;
        spawn.deuSpawn = true;


    }

    void AcabouFadeOut(){

    //fadeOut.SetActive(false);
    playerController.enabled = true;
	ativaRespawn = false;
    }

    void SpawnSave(){
        fase = PlayerPrefs.GetInt("Level");
        playerController.enabled = false;
        player.transform.position = respawnPos;
        playerController.enabled = true;
        if (fase >= 2)
        {
            dimi.carregando = true;
        }
    }
}
