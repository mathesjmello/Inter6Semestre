using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesteCharDrunk : MonoBehaviour
{
	private CharacterController controller;

	public GameObject player;
	public GameObject serguei;
	public GameObject cam;
	public GameObject mark;
	public GameObject canvas;
	public GameObject dimiCaido;
	public GameObject dimiCarregado;
	public GameObject totem;
	public GameObject camUp;
	public GameObject PauseScreen;

	public GameObject garrafa;


	public bool isWalking = false;
	public bool vodka;
	public bool carregando = false;
	public  bool comCalca = false;
	public bool isWalkPlaying;
	public bool isWalkingBack;

	public bool isRunning;
	public bool feedPlay;


	[Range(0, 3)]
	public int doses = 0;


	private float AngularSpeed = 100;
	public float walkSpeed ;
	public float playerSpeed = 1.5f;
	private float gravity = 0.5f;
	public float jumpSpeed = 5;
	public float mouseSensivity = 30;
	private float rotationX = 0;
	public float drunkSpeed;
	public float drunkMax = 1.2f;
	public float drunkMin = -1.2f;
	public float minTime = 2;
	public float maxTime = 5;
	public float time = 0;
	public float changeTime;

	public Animator playerAnim;
	public Animator playerDimiAnim;
	public Animator dimiAnim;

	private Vector3 moveDirection = Vector3.zero;


	public AudioClip walkSound;
	public AudioSource playerSound;
	public AudioSource feedback;









    void Start()
	{
		controller = GetComponent<CharacterController>();
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}


	void FixedUpdate()
	{	

		if (vodka == true && doses >= 1)
		{
			garrafa.SetActive(true);
		}
		if (doses <=0)
		{
			garrafa.SetActive(false);
			vodka = false;
		}


		if (totem.transform.parent == player.transform && Input.GetKey(KeyCode.E))
		{
			totem.transform.parent = null;
		}

	
		if (carregando == true)
		{	
			serguei.SetActive(false);
			dimiCaido.SetActive(false);
			dimiCarregado.SetActive(true);
			time += Time.deltaTime;
		}


		if (Input.GetKey(KeyCode.Z) && carregando == false)
		{
			carregando = true;
		}

		if(time >= changeTime)
		{

             Drunk();
             SetRandomTime();
        }



		if (carregando == false)
		{
			serguei.SetActive(true);
			dimiCaido.SetActive(true);
		    dimiCarregado.SetActive(false);
			drunkSpeed = 0;

		}

		if (isRunning)
		{
			playerSpeed = 5.0f;
		}
		else
		{
			playerSpeed = 1.5f;
		}



		RotateView();



		if (controller.isGrounded)
		{

			moveDirection = Vector3.zero;


			if (Input.GetKey(KeyCode.A))
			{
				//transform.Rotate(Vector3.down * mouseSensivity * 2 * Time.deltaTime);
			   //moveDirection.x = -walkSpeed;  // + drunkSpeed;
			   transform.Rotate(-Vector3.up * AngularSpeed * Time.deltaTime);
			  // isWalking = true;
			}
			else if (Input.GetKey(KeyCode.D))
			{
				//transform.Rotate(Vector3.up * mouseSensivity * 2 * Time.deltaTime);
			   //moveDirection.x = walkSpeed;  // + drunkSpeed;
			   transform.Rotate(Vector3.up * AngularSpeed * Time.deltaTime);
			   //isWalking = true;
			}
			else if (Input.GetKey(KeyCode.W))
			{

				walkSpeed = playerSpeed + drunkSpeed;
				moveDirection.z = walkSpeed ;
				moveDirection.x = drunkSpeed;
				isWalking = true;


			}
			else if (Input.GetKey(KeyCode.S))
			{
				walkSpeed = -playerSpeed + drunkSpeed;
				moveDirection.z = walkSpeed;
				moveDirection.x = drunkSpeed;
				isWalkingBack = true;

			}

			else
			{
				isWalking = false;
				isWalkingBack = false;
			}


			moveDirection = transform.TransformDirection(moveDirection);

			if (Input.GetKey(KeyCode.Space))
			{
				isRunning = true;
				
				
			}

			else
			{
				isRunning = false;
			}

		}

		
		moveDirection.y -= gravity;

		controller.Move(moveDirection * Time.deltaTime);

		if (isWalkingBack == true && carregando == false)
		{

			playerAnim.SetBool("isWalkingBack", true);
		}

			if (isWalkingBack == true && carregando == true )
			{
				playerDimiAnim.SetBool("isWalkingBack", true);
				dimiAnim.SetBool("isWalkingBack", true);
			}			

			if (!playerSound.isPlaying)
			{
				playerSound.Play(0);	
			}
		

		 if (isWalking == true && carregando == false)
		{
			playerAnim.SetBool("isWalking", true);
		}

		 if (isWalking == true && carregando == true)
			{
				playerDimiAnim.SetBool("isWalking", true);
				dimiAnim.SetBool("isWalking", true);
			}

			if (!playerSound.isPlaying)
			{
				playerSound.Play(0);	
			}
			
		

		if (isWalking == false && carregando == false )
		{
			playerAnim.SetBool("isWalking", false);
			
		}

		if (isWalking == false && carregando == true)
		{
			playerDimiAnim.SetBool("isWalking", false);
			dimiAnim.SetBool("isWalking", false);
		}


		if (isWalkingBack == false == carregando == false)
		{

			playerAnim.SetBool("isWalkingBack", false);
		}

		if (isWalkingBack == false == carregando == true)
		{
			playerDimiAnim.SetBool("isWalkingBack", false);
			dimiAnim.SetBool("isWalkingBack", false);
		}

		if (isWalking == false && isWalkingBack == false)
		{
			playerSound.Stop();
			isWalkPlaying = false;
		}


	





	void RotateView()
	{
		//rotaciona a câmera na horizontal
		transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime);

		//rotaciona a câmera na vertical
		rotationX += Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime * -1;
		rotationX = Mathf.Clamp(rotationX, -45, 45);

		cam.transform.localEulerAngles = new Vector3(-rotationX,cam.transform.localEulerAngles.y,cam.transform.localEulerAngles.z);

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



}
}


