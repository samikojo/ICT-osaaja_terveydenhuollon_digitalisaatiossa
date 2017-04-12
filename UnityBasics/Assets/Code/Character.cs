using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
	public float Speed = 1;

	void Update()
	{
		float horizontal = Input.GetAxis( "Horizontal" );
		float vertical = Input.GetAxis( "Vertical" );

		// transform.position kuvaa olion sijainnin maailman koordinaatistossa.
		// transform.localPosition kuvaa sijainnin suhteessa olion vanhempaan.
		Vector3 playerPosition = transform.position;
		playerPosition.z += vertical * Time.deltaTime * Speed;
		playerPosition.x += horizontal * Time.deltaTime * Speed;
		transform.position = playerPosition;
	}

	void FixedUpdate()
	{
		
	}
}
