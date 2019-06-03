using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesteCharDrunk : MonoBehaviour
{
	private CharacterController controller;

	public Transform camClean;

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

    public bool freeze = false;


	public bool isWalking = false;
	public bool vodka;
	public bool carregando = false;
	public  bool comCalca = false;
	public bool isWalkPlaying;
	public bool isWalkingBack;

	public bool isRunning;
	public bool feedPlay;

	public bool deuSpawn;


	[Range(0, 3)]
	public int doses = 0;


	private float AngularSpeed = 100;
	public float walkSpeed ;
	public float playerSpeed = 3.0f;
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
    private Vector3 lookDirection = Vector3.zero;


    public AudioSource playerSound;

	public AudioSource garrafaSound;


    public GameObject hud;


    public float allowPlayerRotation = 0.1f;

    public float Speed;

    public float InputX;
    public float InputZ;

    void Start()
	{
		controller = GetComponent<CharacterController>();
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}


    void FixedUpdate()
    {
        if (freeze == true) {

            playerAnim.SetBool("Idle",true);
            playerDimiAnim.SetBool("Idle", true);
            dimiAnim.SetBool("Idle", true);
            playerAnim.SetBool("isWalking",false);
            playerDimiAnim.SetBool("isWalking", false);
            dimiAnim.SetBool("isWalking", false);
            playerAnim.SetBool("isWalkingBack",false);
            playerDimiAnim.SetBool("isWalkingBack", false);
            dimiAnim.SetBool("isWalkingBack", false);
            playerAnim.SetBool("isRunning",false);
            //return;
        }

        if (freeze == false)
        {
            playerAnim.SetBool("Idle", false);
            playerDimiAnim.SetBool("Idle", false);
            dimiAnim.SetBool("Idle", false);


            if (vodka == true && doses >= 1)
            {
                garrafa.SetActive(true);
                hud.SetActive(true);
                garrafaSound.Play(0);
            }
            if (doses <= 0)
            {
                garrafa.SetActive(false);
                hud.SetActive(false);
                //vodka = false;
            }

            if (vodka == false)
            {
                hud.SetActive(false);
            }


            /*if (totem.transform.parent == player.transform && Input.GetKey(KeyCode.E))
            {
                totem.transform.parent = null;
            }*/


            if (carregando == true)
            {
                serguei.SetActive(false);
                dimiCaido.SetActive(false);
                dimiCarregado.SetActive(true);
                time += Time.deltaTime;
                controller.radius = 0.5f;
                controller.center = new Vector3(0.250221f, 0.78f, -0.05175333f);
                controller.height = 1.65f;
            }


            if (time >= changeTime)
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
                controller.radius = 0.3f;
                controller.center = new Vector3(0, 0.9f, 0);
                controller.height = 1.8f;

            }

            if (isRunning == true && carregando == false)
            {
                playerSpeed = 5.0f;
                isWalking = false;
                isWalkingBack = false;
                playerAnim.SetBool("isRunning", true);
            }
            else
            {
                playerSpeed = 3.0f;
                playerAnim.SetBool("isRunning", false);
            }



            RotateView();



            if (controller.isGrounded && freeze == false)
            {

                moveDirection = Vector3.zero;


                Vector3 camF = camClean.forward;
                Vector3 camR = camClean.right;

                camF.y = 0;
                camR.y = 0;

                camF = camF.normalized;
                camR = camR.normalized;

                if (Input.GetKey(KeyCode.D))
                {
                    isWalking = true;
                    playerAnim.SetBool("Idle", false);
                    playerDimiAnim.SetBool("Idle", false);
                    dimiAnim.SetBool("Idle", false);
                }


                else if (Input.GetKey(KeyCode.A))
                {
                    isWalking = true;
                    playerAnim.SetBool("Idle", false);
                    playerDimiAnim.SetBool("Idle", false);
                    dimiAnim.SetBool("Idle", false);
                }

                else if (Input.GetKey(KeyCode.W))
                {
                    isWalking = true;
                    playerAnim.SetBool("Idle", false);
                    playerDimiAnim.SetBool("Idle", false);
                    dimiAnim.SetBool("Idle", false);
                }

                else if (Input.GetKey(KeyCode.S))
                {
                    isWalkingBack = true;
                    playerAnim.SetBool("Idle", false);
                    playerDimiAnim.SetBool("Idle", false);
                    dimiAnim.SetBool("Idle", false);
                }

                else
                {
                    isWalking = false;
                    isWalkingBack = false;

                    playerAnim.SetBool("Idle", true);
                    playerDimiAnim.SetBool("Idle", true);
                    dimiAnim.SetBool("Idle", true);
                }

                /*


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
                    if (!isRunning)
                    {
                        isWalking = true;
                    }



                }
                else if (Input.GetKey(KeyCode.S))
                {
                    walkSpeed = -playerSpeed + drunkSpeed;
                    moveDirection.z = walkSpeed;
                    moveDirection.x = drunkSpeed;
                    if (!isRunning)
                    {
                        isWalkingBack = true;
                    }

                }*/

                InputX = Input.GetAxis("Horizontal");
                InputZ = Input.GetAxis("Vertical");

                Speed = new Vector2(InputX, InputZ).sqrMagnitude;

                if (Speed >= allowPlayerRotation)
                {
                    lookDirection = camF * Input.GetAxis("Vertical") + camR * Input.GetAxis("Horizontal");
                }
                moveDirection = camF * Input.GetAxis("Vertical") + camR * Input.GetAxis("Horizontal");
                /*else
                {
                    isWalking = false;
                    isWalkingBack = false;
                }


                moveDirection = transform.TransformDirection(moveDirection);
                */

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

            controller.Move(moveDirection * Time.deltaTime * playerSpeed);

            Quaternion dir = Quaternion.LookRotation(lookDirection, Vector3.up);

            serguei.transform.rotation = Quaternion.Euler(new Vector3(0, Mathf.LerpAngle(serguei.transform.rotation.eulerAngles.y, dir.eulerAngles.y, 0.5f), 0));

            dimiCarregado.transform.rotation = Quaternion.Euler(new Vector3(0, Mathf.LerpAngle(dimiCarregado.transform.rotation.eulerAngles.y, dir.eulerAngles.y, 0.5f), 0));

            if (isWalkingBack == true && carregando == false && isRunning == false)
            {

                playerAnim.SetBool("isWalkingBack", true);
                playerAnim.SetBool("isRunning", false);


            }

            if (isWalkingBack == true && carregando == true)
            {
                playerDimiAnim.SetBool("isWalkingBack", true);
                dimiAnim.SetBool("isWalkingBack", true);
            }

            if (!playerSound.isPlaying)
            {
                playerSound.Play(0);
            }


            if (isWalking == true && carregando == false && isRunning == false)
            {
                playerAnim.SetBool("isWalking", true);
                playerAnim.SetBool("isRunning", false);
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



            if (isWalking == false && carregando == false)
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
        }
    }


	





	void RotateView()
	{
		//rotaciona a câmera na horizontal
		transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime);

		//rotaciona a câmera na vertical
		rotationX += Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime * -1;
		rotationX = Mathf.Clamp(rotationX, -45, 45);

        cam.transform.localEulerAngles = new Vector3(-rotationX, cam.transform.localEulerAngles.y, cam.transform.localEulerAngles.z);
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


