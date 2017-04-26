using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
	// Viittaus prefabiin, jossa on Coin-tyyppinen komponentti.
	public Coin CoinPrefab;

	// MinSpawnTime ja MaxSpawnTime muodostavat aikavälin, jolta
	// arvotaan aika, jonka välein luomme uuden kolikon.
	public float MinSpawnTime = 1;
	public float MaxSpawnTime = 3;

	// Aika, joka on kulunut siitä, kun viimeksi loimme uuden kolikon.
	private float _elapsedTime;

	// Aika, jonka odotamme ennen kun luomme uuden kolikon.
	private float _spawnTime;

	// Lista sisältää viittaukset niihin Transformeihin, joiden
	// koordinaatteihin voimme luoda kolikon.
	private List<Transform> _spawnPoints;

	private void Start()
	{
		_spawnTime = Random.Range(MinSpawnTime, MaxSpawnTime);
		_elapsedTime = 0;

		_spawnPoints = new List<Transform>();
		Transform[] spawnPoints = GetComponentsInChildren<Transform>();
		foreach(Transform t in spawnPoints)
		{
			// Haetaan _spawnPoints listaan viittaukset kaikkiin
			// CoinSpawnerin lapsitransformeihin, mutta jätetään
			// tallentamatta viittaus CoinSpawnerin omaan Transform-
			// komponenttiin.
			if(t != transform)
			{
				_spawnPoints.Add(t);
			}
		}
	}

	private void Update()
	{
		_elapsedTime += Time.deltaTime;
		if(_elapsedTime >= _spawnTime)
		{
			// Jos on kulunut riittävän kauan aikaa viimeisimmän kolikon
			// luomisesta, luodaan uusi kolikko satunnaiseen pisteeseen.
			int randomIndex = Random.Range(0, _spawnPoints.Count);
			Transform random = _spawnPoints[randomIndex];
			Vector3 position = random.position;
			Coin coin = Instantiate(CoinPrefab);
			position.y += coin.Radius;
			coin.transform.position = position;

			_elapsedTime = 0;
		}
	}
}
