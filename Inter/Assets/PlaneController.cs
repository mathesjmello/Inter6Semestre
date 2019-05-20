using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
	

	private Vector3 movement;
	private Rigidbody rb;


	private Vector3 positionOld;

	public float velocidade = 15f;


	private bool parede;
    // Start is called before the first frame update
    void Start()
    {
		Time.timeScale = 1;
		rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

		if (Input.GetKey(KeyCode.A))
		{
			movement.x += -velocidade;
		}
		if (Input.GetKey(KeyCode.D))
		{
			movement.x += velocidade;
		}
		if (Input.GetKey(KeyCode.W))
		{
			movement.y += velocidade;
		}
		if (Input.GetKey(KeyCode.S))
		{
			movement.y += -velocidade;
		}

	
		rb.velocity = movement * Time.deltaTime;
		
		
		movement /= 2;
			

    }


	private void OnCollisionStay(Collision collision)
	{
		
		if (collision.gameObject.tag == "Parede2D") parede = true;
		Debug.Log("colidiu");


	}
}
