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

	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerStay(Collider other)
	{
		if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
		{
			player2D.freeze = false;
			oldCam.SetActive(false);
			player3D.SetActive(false);
			inimigos.SetActive(true);

			jogoSom.Play(0);
		}
	}
}
