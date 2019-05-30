using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlaneEnemies : MonoBehaviour
{
	public Transform focalPoint;
	private Vector3 direction;
	public float speed = .75f;

	private Animator anim;
	private int explodeIndex;

	public bool lastPlane;

	public bool freeze;

	void Start()
	{
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


		yield return new WaitForSeconds(1);
		// carrega a cena nova

	}



	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Tiro2D"))
		{
			anim.SetTrigger(explodeIndex);
			if (lastPlane)
			{
				freeze = true;

				StartCoroutine(fimdejogo());
			}
		}
		
	}
}
