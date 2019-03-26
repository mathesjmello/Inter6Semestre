using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesteCharDrunk : MonoBehaviour
{
	public GameObject player;
	public bool isWalking = false;

	public GameObject cam;
	public GameObject mark;

	private CharacterController controller;
	private float AngularSpeed = 100;
	private float walkSpeed = 5;
	private float gravity = 0.5f;
	public float jumpSpeed = 5;
	public float mouseSensivity = 30;
	private float rotationX = 0;
	private Vector3 moveDirection = Vector3.zero;


	public Animator portaAnim;

	public Animator portaAnim2;

	public bool abriArm;

	public bool abriArm2;





	// Variaveis para as mecanicas de bebado//
	public float drunkSpeed;

	public float drunkMax = 4;

	public float drunkMin = -4;

	public float vodka = 0;

	public float minTime = 2;
	public float maxTime = 5;

	public float time = 0;

	public float changeTime;

	public bool jTrue = false;

	public bool hTrue = true;

	public int upTrue = 0;

	public bool carregando = false;

	public bool levantaCaido = false;

	public float timeCaido = 0;

	public float maxTimeCaido = 15;

	public GameObject dimiCaido;

	public GameObject dimiCarregado;




	void Start()
	{
		controller = GetComponent<CharacterController>();
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


		// para dar efeito de andar bebado//	
		if (carregando == true)
		{	
			dimiCaido.SetActive(false);
			dimiCarregado.SetActive(true);
			time += Time.deltaTime;
		}

		if (Input.GetKey(KeyCode.N))
		{
			drunkSpeed = 0;
			carregando = false;
		}

		if(time >= changeTime)
		{

             Drunk();
             SetRandomTime();
        }




		// abrir porta do armario//

		if (abriArm == true)
		{
			portaAnim.SetTrigger("AbriPorta");
			abriArm = false;
		}

		else
		{
			portaAnim.ResetTrigger("AbriPorta");

		}


		if (abriArm2 == true)
		{
			portaAnim2.SetTrigger("AbriPorta");
			abriArm2 = false;
		}

		else
		{
			portaAnim2.ResetTrigger("AbriPorta");

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
		 }


		

		// ObjGrab();
		RotateView();

		if (controller.isGrounded)
		{

			moveDirection = Vector3.zero;

			if (Input.GetKey(KeyCode.A))
			{
				//transform.Rotate(Vector3.down * mouseSensivity * 2 * Time.deltaTime);
			   moveDirection.x = -walkSpeed + drunkSpeed;
			}
			if (Input.GetKey(KeyCode.D))
			{
				//transform.Rotate(Vector3.up * mouseSensivity * 2 * Time.deltaTime);
			   moveDirection.x = walkSpeed + drunkSpeed;
			}
			if (Input.GetKey(KeyCode.W))
			{
				moveDirection.z = walkSpeed + drunkSpeed;

			}
			if (Input.GetKey(KeyCode.S))
			{
				moveDirection.z = -walkSpeed + drunkSpeed;

			}



			moveDirection = transform.TransformDirection(moveDirection);

			if (Input.GetKey(KeyCode.Space))
			{
				moveDirection.y = jumpSpeed;
				
				
			}

		}

		moveDirection.y -= gravity;

		controller.Move(moveDirection * Time.deltaTime);
	}



	void RotateView()
	{
		//rotaciona a câmera na horizontal
		transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime);

		//rotaciona a câmera na vertical
		rotationX += Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime * -1;
		rotationX = Mathf.Clamp(rotationX, -45, 45);

		cam.transform.localEulerAngles = new Vector3(-rotationX,
													 cam.transform.localEulerAngles.y,
													 cam.transform.localEulerAngles.z);
	}

	void SetRandomTime()
	{
         changeTime = Random.Range(minTime, maxTime);
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


	void OnTriggerStay(Collider other)
	{
		if (other.CompareTag("Armario") && Input.GetKey(KeyCode.E))
		{
			abriArm = true;
		}

		if (other.CompareTag("Armario2") && Input.GetKey(KeyCode.E))
		{
			abriArm2 = true;
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

	}


	void EntraArmario()
	{

	}
}
