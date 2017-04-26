using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private static GameManager _current;

	// Staattinen (yhteinen luokan kaikille ilmentymille eli
	// olioille) property. Julkinen getteri ja privaatti setteri.
	// Tämä tarkoittaa sitä, että arvoa voi kysyä mistä oliosta
	// tahansa, mutta sen voi asettaa vain GameManager-tyyppisistä
	// olioista.
	public static GameManager Current
	{
		get { return _current; }
		private set { _current = value; }
	}

	private int _score;
	private float _currentTime;
	private bool _isRunning = false;
	private UI _ui;

	// Tavoitepistemäärä
	public int MaxScore;

	// Aikaraja, jonka jälkeen peli päättyy
	public float TimeLimit;

	#region Unity messages

	private void Awake()
	{
		Current = this;
		_ui = FindObjectOfType<UI>();
	}

	private void Start()
	{
		StartGame();
	}

	private void Update()
	{
		if (_isRunning == false)
		{
			return;
		}

		_currentTime -= Time.deltaTime;

		Debug.Log("Current time: " + _currentTime);

		if(_currentTime <= 0)
		{
			_currentTime = 0;
			GameOver ( false );
		}

		_ui.UpdateTimer(_currentTime);
	}

	#endregion

	// Tätä metodia kutsutaan, kun peli päättyy. Parametri 'didWin'
	// kertoo, voittiko pelaaja pelin.
	private void GameOver( bool didWin )
	{
		_isRunning = false;
		_ui.GameOverView.Show(true, didWin);
		Time.timeScale = 0;
	}

	// Tämän metodin kutsuminen käynnistää pelin
	public void StartGame()
	{
		_score = 0;
		_currentTime = TimeLimit;
		_isRunning = true;

		// Päivittää pelaajan pistemäärän UI:lle pelin alussa.
		_ui.UpdateScore(_score);

		// Päivittää jäljellä olevan ajan UI:lle.
		_ui.UpdateTimer(_currentTime);
	}

	public void AddScore(int score)
	{
		_score += score;
		// Päivittää pelaajan pistemäärän UI:lle joka kerta, kun pelaaja
		// kerää kolikon.
		_ui.UpdateScore(_score);

		Debug.Log("Score: " + _score);

		if( _score >= MaxScore )
		{
			GameOver(true);
		}
	}
}
