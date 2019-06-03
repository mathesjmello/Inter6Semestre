using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGame : MonoBehaviour
{
    
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

    public NPCAtivos check;

    public Calça save;
    
	private CharacterController playerController;

    public SaveControl autoSave; 

    public MenuPrincipal spawnSave;

    public bool acabouRespawn;

    public GameObject fala04;
    public GameObject fala05;
    public GameObject fala06;
    public GameObject fala07;

    // Start is called before the first frame update
    void Start()
    {
        fala04 = GameObject.FindGameObjectWithTag("Fala04");
        fala05 = GameObject.FindGameObjectWithTag("Fala05");
        fala06 = GameObject.FindGameObjectWithTag("Fala06");
        fala07 = GameObject.FindGameObjectWithTag("Fala07");

		playerController = player.GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(fase == 0)
        {
            //Antes do guarda do correrdor pela 1° vez
            respawnPos = checkpoint01.transform.position;
        }

        if (fase == 1)
        {
			//Antes da Sra Dimitri
            respawnPos = checkpoint02.transform.position;

            check.disable = 1;

            dimi.carregando = false;

            fala04.SetActive(true);
            fala05.SetActive(true);
            fala06.SetActive(true);
            fala07.SetActive(true);
           
        }

        if (fase == 2)
        {
            //No bar, Antes do guarda do corredor

            respawnPos = checkpoint03.transform.position;

            check.disable = 2;

            dimi.carregando = true;

            fala05.SetActive(true);
            fala06.SetActive(true);
            fala07.SetActive(true);

            
        }

        if (fase == 3)
        {
            //Antes da bomba
            respawnPos = checkpoint04.transform.position;

            check.disable = 3;

            dimi.carregando = true;

            fala05.SetActive(true);
            fala06.SetActive(true);
            fala07.SetActive(true);

            
        }

        if (fase == 4)
        {
            //Antes do Salão
            respawnPos = checkpoint05.transform.position;

            check.disable = 4;
            dimi.carregando = true;

            fala06.SetActive(true);
            fala07.SetActive(true);
  
            
        }
    }

    IEnumerator Load(){

        fase = PlayerPrefs.GetInt("Level");
        playerController.enabled = false;
        player.transform.position = respawnPos;

        yield return new WaitForSeconds(2.0f);

        playerController.enabled = true;


    }
}
