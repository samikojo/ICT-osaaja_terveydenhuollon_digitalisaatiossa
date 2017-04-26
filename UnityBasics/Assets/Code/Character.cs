using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, ICharacter
{
	private Rigidbody _rigidbody;
	private Collider _collider;
	private Mover _mover;

	public float Height
	{
		get
		{
			return _collider.bounds.max.y - _collider.bounds.min.y;
		}
	}

	private void Awake()
	{
		// Haetaan viittaus siihen Collideriin, joka on Character-komponentin
		// kanssa samassa GameObjectissa.
		_collider = GetComponent<Collider>();

		// Haetaan viittaus Rigidbody-komponenttiin
		_rigidbody = GetComponent<Rigidbody>();

		if(_rigidbody == null)
		{
			Debug.LogError("Rigidbody not found!");
		}

		// Haetaan viittaus Mover-tyyppiseen komponenttiin, joka
		// huolehtii hahmon liikuttamisesta.
		_mover = GetComponent<Mover>();

		// This viittaa aina tähän olioon (tässä tapauksessa 
		// Character -tyyppiseen olioon).
		_mover.Init(this);
	}

	void FixedUpdate()
	{
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");
		float turn = Input.GetAxis("Turn");
		bool jump = Input.GetKeyDown(KeyCode.Space);

		// Kutsu _mover.Move -metodia liikuttaaksesi hahmoa.
		_mover.Move(horizontal, vertical, Time.fixedDeltaTime);
		_mover.Turn(turn, Time.fixedDeltaTime);

		if ( jump )
		{
			_mover.Jump();
		}
	}	

	// Tätä metodia kutsutaan, kun pelaaja kerää kolikon. Metodi
	// välittää tiedon kolikon keräämisestä GameManager:lle.
	public void CollectCoin(int points)
	{
		GameManager.Current.AddScore(points);
	}
}
