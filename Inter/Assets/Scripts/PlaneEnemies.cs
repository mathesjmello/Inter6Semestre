using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class PlaneEnemies : MonoBehaviour
{
	public Transform focalPoint;
	private Vector3 direction;
	public float speed = .75f;
    public PlaneController planeController;

	private Animator anim;
	private int explodeIndex;

	public bool lastPlane;

	public static bool freezer;

    public GameObject falaFinal;
    public GameObject noise;

    public AudioSource planeDestroySound;

	public AudioSource feedFim;

	public AudioSource feedFim2;

    public Scoremanager scoremanager;

	public GameObject tiros;

	public AudioSource fala;

  


    void Start()
	{
        falaFinal.SetActive(false);
        anim = GetComponent<Animator>();
		explodeIndex = Animator.StringToHash("Explode");
		direction = focalPoint.transform.position - transform.position;  
		direction.Normalize();
        if (lastPlane) 
        StartCoroutine(fimdejogo(60));
    }

	void Update()
	{
		if (freezer) return;
		float deltaSpeed = speed * Time.deltaTime;
		transform.Translate(direction.x * deltaSpeed, direction.y * deltaSpeed, direction.z * deltaSpeed, Space.World);

        
	}

    IEnumerator fimdejogo(float tempo)
    {

        
        yield return new WaitForSeconds(tempo);
        planeController.freeze = true;
        freezer = true;
        falaFinal.SetActive(true);
        noise.SetActive(true);
        feedFim.Play(0);
		feedFim2.Play(0);
		fala.Play();
		tiros.SetActive(false);

        yield return new WaitForSeconds(9);
        SceneManager.LoadScene("Final");

	}



	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Tiro2D"))
		{
            if(!lastPlane)
            {
                anim.SetTrigger(explodeIndex);
                scoremanager.score++;
            }
			planeDestroySound.Play(0);
			if (lastPlane)
			{
                
                
                StartCoroutine(fimdejogo(0));
				
			}
		}
		
	}
}
