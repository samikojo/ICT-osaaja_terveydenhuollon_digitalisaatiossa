using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
	public float TurnSpeed;
	public int Score = 100;

	private void Update()
	{
		Vector3 rotation = transform.eulerAngles;
		rotation.y += TurnSpeed * Time.deltaTime;
		transform.eulerAngles = rotation;
	}

	// Kutsutaan, kun kaksi Collideria törmää toisiinsa
	private void OnTriggerEnter(Collider other)
	{
		Character character =
			other.gameObject.GetComponent<Character>();

		if ( character != null )
		{
			GameManager.Current.AddScore(Score);
			Destroy(gameObject);
		}
	}

	// Kutsutaan, kun Collider poistuu toisen Colliderin sisästä
	private void OnTriggerExit(Collider other)
	{

	}

	// Kutsutaan kerran framessa niin kauan kuin kaksi Collideria
	// ovat sisäkkäin
	private void OnTriggerStay(Collider other)
	{

	}
}
