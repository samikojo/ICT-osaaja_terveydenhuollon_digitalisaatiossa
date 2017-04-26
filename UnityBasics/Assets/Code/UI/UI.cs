using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
	// Viittaus tekstikomponenttiin, joka piirtää pisteet
	// graafiseen käyttöliittymään.
	public Text ScoreText;

	// Viittaus tekstikomponenttiin, joka piirtää jäljellä olevan
	// ajan.
	public Text TimerText;

	// Viittaus GameOverView tyyppiseen näkymään, joka kertoo, voittiko
	// vai hävisikö pelaaja pelin.
	public GameOverView GameOverView;

	// Tulostaa ScoreText-tekstikomponenttiin pelaajan pisteet.
	public void UpdateScore(int score)
	{
		ScoreText.text = "Score: " + score;
	}

	/// <summary>
	/// Piirtää jäljellä olevan ajan graafiseen käyttöliittymään.
	/// </summary>
	/// <param name="remainingTime">Pelaajan jäljellä oleva aika.</param>
	public void UpdateTimer(float remainingTime)
	{
		TimerText.text = remainingTime.ToString("n2");
	}
}
