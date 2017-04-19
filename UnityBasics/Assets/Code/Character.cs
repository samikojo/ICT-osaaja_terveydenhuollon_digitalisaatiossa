using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
	public float Speed = 1;
	public float JumpForce;
	public float TurnSpeed = 45;

	private Rigidbody _rigidbody;
	private Collider _collider;

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

		// Haetaan
		_rigidbody = GetComponent<Rigidbody>();

		if(_rigidbody == null)
		{
			Debug.LogError("Rigidbody not found!");
		}
	}

	public void Move()
	{

	}

	void Update()
	{
		// MoveCharacterByModifyingPosition();
	}

	private void MoveCharacterByModifyingPosition()
	{
		Vector3 playerPosition = GetNewPosition(Time.deltaTime);
		transform.position = playerPosition;
	}

	private Vector3 GetNewPosition(float deltaTime)
	{
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		// transform.position kuvaa olion sijainnin maailman koordinaatistossa.
		// transform.localPosition kuvaa sijainnin suhteessa olion vanhempaan.
		Vector3 playerPosition = transform.position;

		playerPosition += transform.forward * vertical * deltaTime * Speed;
		playerPosition += transform.right * horizontal * deltaTime * Speed;

		return playerPosition;
	}

	void FixedUpdate()
	{
		Vector3 newPosition = GetNewPosition(Time.fixedDeltaTime);
		_rigidbody.MovePosition(newPosition);

		if( Input.GetKeyDown( KeyCode.Space ) && IsGrounded() )
		{
			_rigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
		}

		float turn = Input.GetAxis("Turn");
		Vector3 rotation = transform.eulerAngles;
		rotation.y += turn * Time.fixedDeltaTime * TurnSpeed;
		Quaternion quaternionRotation = Quaternion.Euler(rotation);
		_rigidbody.MoveRotation(quaternionRotation);
	}

	public bool IsGrounded()
	{
		// Ammutaan säde GameObjectin keskikohdasta alaspäin Ground-layerilla
		// olevia kappaleita vastaan. Jos säde osuu johonkin kappaleeseen,
		// tiedämme GameObjectin olevan maassa.
		bool isGrounded = Physics.Raycast(transform.position, Vector3.down,
			Height / 2 + 0.1f, LayerMask.GetMask("Ground"));
		return isGrounded;
	}
}
