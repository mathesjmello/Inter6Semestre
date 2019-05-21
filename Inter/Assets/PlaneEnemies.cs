using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneEnemies : MonoBehaviour
{
	public Transform focalPoint;
	private Vector3 direction;
	public float speed = .75f;

	void Start()
	{
		
	
		direction = focalPoint.transform.position - transform.position;  
		direction.Normalize();
	}

	void Update()
	{
		// Move in direction of target.
		float deltaSpeed = speed * Time.deltaTime;
		transform.Translate(direction.x * deltaSpeed, direction.y * deltaSpeed, direction.z * deltaSpeed, Space.World);
	}
}
