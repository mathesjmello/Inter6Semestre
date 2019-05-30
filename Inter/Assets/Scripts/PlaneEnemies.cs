﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class PlaneEnemies : MonoBehaviour
{
	public Transform focalPoint;
	private Vector3 direction;
	public float speed = .75f;

	private Animator anim;
	private int explodeIndex;

	public bool lastPlane;

	public bool freeze;

    public GameObject falaFinal;

	public AudioSource planeDestroySound;

	void Start()
	{
        falaFinal.SetActive(false);
        anim = GetComponent<Animator>();
		explodeIndex = Animator.StringToHash("Explode");
		direction = focalPoint.transform.position - transform.position;  
		direction.Normalize();
	}

	void Update()
	{
		if (freeze) return;
		float deltaSpeed = speed * Time.deltaTime;
		transform.Translate(direction.x * deltaSpeed, direction.y * deltaSpeed, direction.z * deltaSpeed, Space.World);
	}

	IEnumerator fimdejogo()
	{


		yield return new WaitForSeconds(4);
        SceneManager.LoadScene("Final");

	}



	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Tiro2D"))
		{
            if(!lastPlane)
            {
                anim.SetTrigger(explodeIndex);
            }
			planeDestroySound.Play(0);
			if (lastPlane)
			{
				freeze = true;
                falaFinal.SetActive(true);
				StartCoroutine(fimdejogo());
			}
		}
		
	}
}
