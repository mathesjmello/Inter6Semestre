using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame2D : MonoBehaviour
{
	public PlaneController player2D;
	public GameObject player3D;
	public GameObject inimigos;

	public AudioSource jogoSom;

	public GameObject oldCam;

    public GameObject instrucoes;

    private void Awake()
    {
        if(instrucoes != null)
        {
            instrucoes.SetActive(false);
        }
    }


    private void OnTriggerStay(Collider other)
	{
		if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
		{
			player2D.freeze = false;
			oldCam.SetActive(false);
			player3D.SetActive(false);
			inimigos.SetActive(true);

            if(instrucoes != null)
            {
                StartCoroutine(instrucoesAviao());
            }

			jogoSom.Play(0);
		}
	}

    IEnumerator instrucoesAviao()
    {
        instrucoes.SetActive(true);
        yield return new WaitForSeconds(10);
        instrucoes.SetActive(false);
    }
}
