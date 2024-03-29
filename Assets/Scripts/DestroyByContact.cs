﻿using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	public int scoreValue;
	[SerializeField]
	private GameObject explosion;
	[SerializeField]
	private GameObject playerExplosion;
	private GameController gameController;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");

		if (gameControllerObject != null) gameController = gameControllerObject.GetComponent<GameController> ();

		if (gameControllerObject == null) Debug.Log ("Cannot find GameController script");
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Boundary") return;

		Instantiate(explosion, transform.position, transform.rotation);

		if (other.tag == "Player")
		{
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver ();
		}

		if (other.tag == "Bolt") gameController.AddScore (scoreValue);

		Destroy(other.gameObject);
		Destroy(gameObject);
	}
}