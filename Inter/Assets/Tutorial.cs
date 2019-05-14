using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

	public bool primeiroTut;
	public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
		primeiroTut = true; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player" && primeiroTut)
		{
			canvas.SetActive(true);

		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player" && primeiroTut)
		{
			canvas.SetActive(false);

		}
	}
}
