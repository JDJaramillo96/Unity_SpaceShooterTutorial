using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	[SerializeField]
	private GameObject hazard;
	[SerializeField]
	private Vector3 spawnValues;
	[SerializeField]
	private float startWait;
	[SerializeField]
	private float spawnWait;
	[SerializeField]
	private float waveWait;
	[SerializeField]
	private int hazardCount;
	private int score;
	[SerializeField]
	private Text scoreText;
	[SerializeField]
	private Text gameOverText;
	[SerializeField]
	private Text restartText;
	private bool restart;
	private bool gameOver;

	void Start ()
	{
		score = 0;
		restart = false;
		gameOver = false;
		restartText.text = "";
		gameOverText.text = "";

		UpdateScore ();
		StartCoroutine (SpawnWaves());
	}

	void Update()
	{
		if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
				SceneManager.LoadScene ("Main");
		}
	}

	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds (startWait);

		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate(hazard, spawnPosition, spawnRotation);

				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds(waveWait);

			if (gameOver)
			{
				restartText.text = "Press 'R' for restart";
				restart = true;
				break;
			}
		}
	}

	void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}

	public void AddScore(int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	public void GameOver()
	{
		gameOverText.text = "Game Over";
		gameOver = true;
	}
}