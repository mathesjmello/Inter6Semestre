using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
	public GameObject Player;
	public bool IsWalking = false;

	public GameObject Cam;
	public GameObject Mark;

	private CharacterController _controller;
	private float _angularSpeed = 100;
	private float _walkSpeed = 5;
	private float _gravity = 0.5f;
	public float JumpSpeed = 5;
	public float MouseSensivity = 30;
	private float _rotationX = 0;
	private Vector3 _moveDirection = Vector3.zero;




	// Variaveis para as mecanicas de bebado//

	/*
	public float drunkSpeed;

	public float drunkMax = 4;

	public float drunkMin = -4;

	public float vodka = 0;
	public bool drunkOn =  false;

	public float minTime = 2;
	public float maxTime = 5;

	public float time = 0;

	public float changeTime;

	public bool jTrue = false;

	public bool hTrue = true;

	public int upTrue = 0;

	public bool carregando = true;

	public bool levantaCaido = false;

	public float timeCaido = 0;

	public float maxTimeCaido = 15;

	public GameObject dimiCaido;

	public GameObject dimiCarregado;*/




	void Start()
	{
		_controller = GetComponent<CharacterController>();
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

		
		
	}

	
	
	/* void ObjGrab()
	 {
		 Vector3 from = cam.transform.position;
		 Vector3 direction = cam.transform.TransformDirection(Vector3.forward);
		 Ray ray = new Ray(cam.transform.position, direction);

		 RaycastHit hit;
		 if (Physics.Raycast(ray, out hit, 5))
		 {
			 if (hit.collider.CompareTag("crate"))
			 {
				 GameObject hitObj = hit.collider.gameObject;
				 hitObj.GetComponent<Renderer>().material.color = Color.red;

				 if (Input.GetKeyDown(KeyCode.E))
				 {
					 hitObj.transform.SetParent(cam.transform);
					 hitObj.GetComponent<Rigidbody>().isKinematic = true;
				 }

				 if (Input.GetKeyUp(KeyCode.E))
				 {
					 hitObj.transform.SetParent(null);
					 hitObj.GetComponent<Rigidbody>().isKinematic = false;
				 }
			 }
		 }
		 Debug.DrawRay(from, direction * 5, Color.blue);
	 }*/


	void FixedUpdate()
	{	
		/*
		// para dar efeito de andar bebado//	
		if (carregando == true)
		{
			dimiCaido.SetActive(false);
			dimiCarregado.SetActive(true);
			SetRandomTime();
         	time = minTime;
			drunkOn = true;
		}

		if (Input.GetKey(KeyCode.N))
		{
			drunkSpeed = 0;
			drunkOn = false;
		}

		if(time >= changeTime)
		{
             Drunk();
             SetRandomTime();
         }

		 if(drunkOn == true)
		 {
			 time += Time.deltaTime;
		 }









		// para levantar o bebado//

		if (carregando == false)
		{
			dimiCaido.SetActive(true);
			dimiCarregado.SetActive(false);
			drunkSpeed = 0;
		}



		Levanta();



		 if (Input.GetKey(KeyCode.E))
		 {
			 levantaCaido = true;

		 }

		 if (levantaCaido == true)
		 {
			 timeCaido += Time.deltaTime;
		 }

		 if (timeCaido >= maxTimeCaido)
		 {
			 levantaCaido = false;
			 timeCaido = 0;
			 upTrue = 0;
			 hTrue = true;
			 jTrue = false;
		 }


		 if (vodka == 3)
		 {
			 carregando = false;
		 }*/


		

		// ObjGrab();
		RotateView();

		if (_controller.isGrounded)
		{

			_moveDirection = Vector3.zero;

			if (Input.GetKey(KeyCode.A))
			{
				//transform.Rotate(Vector3.down * mouseSensivity * 2 * Time.deltaTime);
			   _moveDirection.x = -_walkSpeed; //+ drunkSpeed;
			}
			if (Input.GetKey(KeyCode.D))
			{
				//transform.Rotate(Vector3.up * mouseSensivity * 2 * Time.deltaTime);
			   _moveDirection.x = _walkSpeed;// + drunkSpeed;
			}
			if (Input.GetKey(KeyCode.W))
			{
				_moveDirection.z = _walkSpeed;// + drunkSpeed;

			}
			if (Input.GetKey(KeyCode.S))
			{
				_moveDirection.z = -_walkSpeed;// + drunkSpeed;

			}



			_moveDirection = transform.TransformDirection(_moveDirection);

			if (Input.GetKey(KeyCode.Space))
			{
				_moveDirection.y = JumpSpeed;
				
				
			}

		}

		_moveDirection.y -= _gravity;

		_controller.Move(_moveDirection * Time.deltaTime);
	}



	void RotateView()
	{
		//rotaciona a câmera na horizontal
		transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * MouseSensivity * Time.deltaTime);

		//rotaciona a câmera na vertical
		_rotationX += Input.GetAxis("Mouse Y") * MouseSensivity * Time.deltaTime * -1;
		_rotationX = Mathf.Clamp(_rotationX, -45, 45);

		Cam.transform.localEulerAngles = new Vector3(-_rotationX,
													 Cam.transform.localEulerAngles.y,
													 Cam.transform.localEulerAngles.z);
	} 	
	
	/* 	
	void SetRandomTime() 	
	{ 	
         changeTime = Random.Range(minTime, maxT 	ime);
    }

	void Drunk()
	{	
		time = 0;
		drunkSpeed = Random.Range (drunkMin,drunkMax);
		 
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Vodka"))
		{
		// para aumentar o quao bebado//
		vodka ++;	
		minTime ++;
		drunkMax ++;
		drunkMin --;
		Destroy(other.gameObject);
		}

		if (other.CompareTag("Obstaculo") && carregando == true)
		{
			carregando = false;
		}
	}


	void Levanta()
	{
		// tem que apertar J e o H alternadamente dentro do limite de tempo para conseguir levantar ele//
		if (carregando == false && levantaCaido == true)
		{
			if (hTrue == true && jTrue == false)
			{
				if (Input.GetKeyUp(KeyCode.J))
				{
					hTrue = false;
					jTrue = true;
					upTrue +=1;
				}
			}

			 if (jTrue == true && hTrue == false)
			{
				if (Input.GetKeyUp(KeyCode.H))
				{
					hTrue = true;
					jTrue = false;
					upTrue +=1;
				}
			}
			
			
		}

		if(upTrue == 40)
		{
			levantaCaido = false;
			timeCaido = 0;
			//dimiCaido.SetActive(false);
			//dimiCarregado.SetActive(true);
			vodka = 0;
			carregando = true;
		}

	}*/
}
