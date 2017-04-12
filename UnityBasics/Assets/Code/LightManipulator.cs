using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManipulator : MonoBehaviour
{
	// Tämä muuttuja viittaa scenen valoon.
	public Light SceneLight;

	// Väri, jonka asetamme valolle.
	public Color LightColor;

	// Suoritetaan välittömästi, kun olio luodaan
	void Awake()
	{
		Debug.Log( "Awake" );

		if ( SceneLight == null )
		{
			// Jos SceneLight muuttujaan ei ole alustettu arvoa,
			// haetaan GameObjectista, johon LightManipulator on
			// liitetty Light-tyyppinen komponentti ja tallennetaan
			// viittaus muuttujaan SceneLight.
			SceneLight = GetComponent< Light >();
		}
	}

	// Suoritetaan joka kerta, kun olio aktivoidaan.
	void OnEnable()
	{
		Debug.Log( "OnEnable" );
		SceneLight.color = LightColor;
	}

	void OnDisable()
	{
		Debug.Log( "OnDisable" );
	}

	// Use this for initialization
	void Start ()
	{
		Debug.Log( "Start" );
	}
	
	// Update is called once per frame
	void Update ()
	{
		bool isUpPressed = Input.GetKeyDown( KeyCode.UpArrow );
		bool isDownPressed = Input.GetKeyDown( KeyCode.DownArrow );
		float userInput = 0;

		if ( isUpPressed == true )
		{
			userInput = 0.5f;
		}
		else if ( isDownPressed == true )
		{
			userInput = -0.5f;
		}

		// float userInput = Input.GetAxis( "Vertical" );
		// SceneLight.intensity = SceneLight.intensity + userInput;
		SceneLight.intensity += userInput;
		SceneLight.intensity = Mathf.Clamp( SceneLight.intensity, 1, 5 );
		//Debug.Log( "Update" );
	}
}
