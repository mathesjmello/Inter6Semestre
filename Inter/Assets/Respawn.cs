using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public bool ativaRespawn;

    public GameObject player;

    public TesteCharDrunk spawn;

    [Range(0,2)]
    public int fase;

    public Vector3 respawnPos;

    public GameObject checkpoint01;

    public GameObject checkpoint02;

    public GameObject checkpoint03;

    public GameObject fadeOut;


	private CharacterController playerController;

    // Start is called before the first frame update
    void Start()
    {
        respawnPos = checkpoint01.transform.position;
		playerController = player.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fase == 1)
        {
			
            respawnPos = checkpoint02.transform.position;
        }

        if (fase == 2)
        {
            respawnPos = checkpoint03.transform.position;
        }

        if (ativaRespawn == true)
        {
            ChamouRespawn();
		
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

    fadeOut.SetActive(false);
    playerController.enabled = true;
	ativaRespawn = false;
    }
}
