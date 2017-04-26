using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverView : MonoBehaviour
{
	private const string PlayerLostGame = "Game over!";
	private const string PlayerWinGame = "You win!";

	public Text GameOverText;

	private void Awake()
	{
		if (GameOverText == null)
		{
			GameOverText = GetComponentInChildren<Text>(true);
		}

		gameObject.SetActive(false);
	}

	// Näyttää pelin päätösnäkymän ja asettaa tekstin sen perusteella,
	// voittiko vai hävisikö pelaaja pelin.
	public void Show(bool isActive, bool didWin)
	{
		gameObject.SetActive(isActive);

		if(didWin)
		{
			GameOverText.text = PlayerWinGame;
		}
		else
		{
			GameOverText.text = PlayerLostGame;
		}
	}
}
