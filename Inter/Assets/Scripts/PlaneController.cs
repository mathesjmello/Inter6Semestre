using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
	

	private Vector3 movement;
	private Rigidbody rb;
	private GameObject tiros;
	public GameObject player;
	public bool freeze = true;

	private Vector3 positionOld;

	public float velocidade = 15f;

    public Transform analogico;
    public float giranalogico = 20;


	private bool parede;
    // Start is called before the first frame update
    void Start()
    {
		Time.timeScale = 1;
		rb = GetComponent<Rigidbody>();
		tiros = GameObject.FindGameObjectWithTag("Tiro2D");
		tiros.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

		if (freeze) return;

		if (Input.GetKey(KeyCode.A))
		{
			movement.z += velocidade;
            analogico.localRotation = Quaternion.Slerp(analogico.localRotation, Quaternion.Euler(giranalogico, 0, 0), .1f);

        }
		if (Input.GetKey(KeyCode.D))
		{
			movement.z += -velocidade;
            analogico.localRotation = Quaternion.Slerp(analogico.localRotation, Quaternion.Euler(-giranalogico, 0, 0), .1f);
        }
		if (Input.GetKey(KeyCode.W))
		{
			movement.y += velocidade;
            analogico.localRotation = Quaternion.Slerp(analogico.localRotation, Quaternion.Euler(0, 0, -giranalogico), .1f);
        }
		if (Input.GetKey(KeyCode.S))
		{
			movement.y += -velocidade;
            analogico.localRotation = Quaternion.Slerp(analogico.localRotation, Quaternion.Euler(0, 0, giranalogico), .1f);
        }

        analogico.localRotation = Quaternion.Slerp(analogico.localRotation, Quaternion.Euler(0, 0, 0), .1f);


        rb.velocity = movement * Time.deltaTime;
		movement /= 2;


		if (Input.GetKey(KeyCode.Space) && Time.timeScale != 0)
		{
			tiros.SetActive(true);
			tiros.transform.localScale = new Vector3(tiros.transform.localScale.x * - 1, tiros.transform.localScale.y, tiros.transform.localScale.z);
		}

		if (Input.GetKeyUp(KeyCode.Space) && Time.timeScale != 0)
		{
			tiros.SetActive(false);
		}


	}

	

}
