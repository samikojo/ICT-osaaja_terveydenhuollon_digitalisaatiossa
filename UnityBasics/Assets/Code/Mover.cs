using UnityEngine;

public class Mover : MonoBehaviour
{
	public float Speed = 1;
	public float JumpForce;
	public float TurnSpeed = 45;

	private Rigidbody _rigidbody;
	private Collider _collider;
	private ICharacter _character;

	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
		_collider = GetComponent<Collider>();
	}

	// Kutsutaan tätä metodia, jotta saamme välitettyä Moverille
	// ICharacter-tyyppinen olio, josta tämä komponentti on
	// riippuvainen.
	public void Init(ICharacter character)
	{
		_character = character;
	}

	public bool IsGrounded()
	{
		// Ammutaan säde GameObjectin keskikohdasta alaspäin Ground-layerilla
		// olevia kappaleita vastaan. Jos säde osuu johonkin kappaleeseen,
		// tiedämme GameObjectin olevan maassa.
		bool isGrounded = Physics.Raycast(transform.position,
			Vector3.down, _character.Height / 2 + 0.1f,
			LayerMask.GetMask("Ground"));
		return isGrounded;
	}

	/// <summary>
	/// Liikuttaa hahmoa.
	/// </summary>
	/// <param name="horizontal">-1, jos liikutaan vasemmalle,
	/// 1, jos liikutaan oikealle, 0, jos ei horisontaalista liikettä.
	/// </param>
	/// <param name="vertical">1, jos liikutaan eteenpäin, -1
	/// , jos liikutaan taaksepäin, 0 jos ei vertikaalista liikettä.
	/// </param>
	/// <param name="deltaTime">Time.deltaTime tai Time.fixedDeltaTime</param>
	public void Move( float horizontal, float vertical,
		float deltaTime )
	{
		Vector3 position = GetNewPosition(horizontal, vertical,
			deltaTime);
		_rigidbody.MovePosition(position);
	}

	public void Jump()
	{
		// Hypätään, jos hahmo on maassa.
		if ( IsGrounded() )
		{
			_rigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
		}
	}

	public void Turn( float turn, float deltaTime )
	{
		Vector3 rotation = transform.eulerAngles;
		rotation.y += turn * deltaTime * TurnSpeed;
		Quaternion quaternionRotation = Quaternion.Euler(rotation);
		_rigidbody.MoveRotation(quaternionRotation);
	}

	private Vector3 GetNewPosition(float horizontal, float vertical,
		float deltaTime)
	{
		// transform.position kuvaa olion sijainnin maailman koordinaatistossa.
		// transform.localPosition kuvaa sijainnin suhteessa olion vanhempaan.
		Vector3 playerPosition = transform.position;

		playerPosition += transform.forward * vertical * deltaTime * Speed;
		playerPosition += transform.right * horizontal * deltaTime * Speed;

		return playerPosition;
	}
}
