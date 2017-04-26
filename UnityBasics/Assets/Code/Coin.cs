using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
	public float TurnSpeed;
	public int Score = 100;

	private CapsuleCollider _collider;

	public float Radius
	{
		get { return _collider.radius; }
	}

	public float Height
	{
		get { return Radius * 2; }
	}

	private void Awake()
	{
		_collider = GetComponent<CapsuleCollider>();
	}

	private void Update()
	{
		Vector3 rotation = transform.eulerAngles;
		rotation.y += TurnSpeed * Time.deltaTime;
		transform.eulerAngles = rotation;
	}

	// Kutsutaan, kun kaksi Collideria törmää toisiinsa
	private void OnTriggerEnter(Collider other)
	{
		// Haetaan viittaus ICharacter-rajapinnan toteuttavaan
		// komponenttiin. Koska rajapinnan toteuttajan on pakko
		// toteuttaa metodi CollectCoin, voimme kutsua kyseistä metodia
		// riippumatta ICharacter-rajapinnan toteuttavan olion
		// todellisesta tyypistä.
		ICharacter character =
			other.gameObject.GetComponent<ICharacter>();

		if ( character != null )
		{
			character.CollectCoin(Score);
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
