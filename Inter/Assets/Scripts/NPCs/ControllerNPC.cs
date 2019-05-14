using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControllerNPC : MonoBehaviour
{

    //NavMesh
    public NavMeshAgent myAgent;


    //Pontos de Movimento
    
    public GameObject targetGM_01;
    private Vector3 target_01;

    public GameObject targetGM_02;
    private Vector3 target_02;

    public GameObject targetGM_Reset;
    private Vector3 target_Reset;

    public GameObject targetGM_ResetSemRota;
    private Vector3 target_ResetSemRota;

    public GameObject targetGM_ObjetoEncontrado;
    private Vector3 target_ObjetoEncontrado;

    public GameObject targetGM_PosicaoParadoSemRota;
    private Vector3 target_PosicaoParadoSemRota;


    //Scripts
    public FieldOfView campoDeVisao;


    //Floats
    public float tempoDeConfusao;


    //Booleans
    private bool switchBettween;
    public bool andando = true;
    public bool encontrou = false;
    public bool buscandoTotem = true;

    public bool fazRota;

    void Start()
    {
        campoDeVisao = GetComponent<FieldOfView>();
        
        myAgent = GetComponent<NavMeshAgent>();
        if(fazRota == true)
        {
            targetGM_Reset.SetActive(false);
        }
        else
        {
            targetGM_ResetSemRota.SetActive(false);
            targetGM_PosicaoParadoSemRota.SetActive(false);
        }
    }



    private void Update()
    {
        if (fazRota == false)
        {
            targetGM_01 = null;
            targetGM_02 = null;
            targetGM_Reset = null;
        }

        if (andando == true && fazRota == true)
        {
            MovimentoBasico();
        }
        if (encontrou == true)
        {
            EncontrouPoster();
        }
    }


    void MovimentoBasico()
    {
        if (switchBettween == true)
        {
            target_01 = targetGM_01.transform.position;
            myAgent.SetDestination(target_01);
        }
        else
        {
            target_02 = targetGM_02.transform.position;
            myAgent.SetDestination(target_02);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Change") && fazRota == true)
        {
            if (switchBettween == true)
            {
                switchBettween = false;
            }
            else
            {
                switchBettween = true;
            }
        }
        
        if (other.CompareTag("Totem"))
        {
            buscandoTotem = false;
            myAgent.isStopped = true;
            StartCoroutine(ColidiuComPoster());
        }
        
        if (other.CompareTag("Reset") && fazRota == true)
        { 
            targetGM_Reset.SetActive(false);
            andando = true;
            buscandoTotem = true;
        }
        if (other.CompareTag("Reset") && fazRota == false)
        {
            targetGM_ResetSemRota.SetActive(false);
            buscandoTotem = true;
            target_Reset = targetGM_PosicaoParadoSemRota.transform.position;
            myAgent.SetDestination(target_Reset);
        }
    }

    void EncontrouPoster()
    {
        andando = false;
        target_ObjetoEncontrado = campoDeVisao.localizacaoDoPoster;
        myAgent.SetDestination(target_ObjetoEncontrado);
        encontrou = false;
    }



    IEnumerator ColidiuComPoster()
    {
        //Roda Animação de Confusão
        Debug.Log("Poster");
        yield return new WaitForSeconds(tempoDeConfusao);
        myAgent.isStopped = false;
        if (fazRota == true)
        { 
            targetGM_Reset.SetActive(true);
            target_Reset = targetGM_Reset.transform.position;
            myAgent.SetDestination(target_Reset);
        }
        else
        {
            targetGM_ResetSemRota.SetActive(true);
            target_Reset = targetGM_ResetSemRota.transform.position;
            myAgent.SetDestination(target_Reset);
        }
    }
}
