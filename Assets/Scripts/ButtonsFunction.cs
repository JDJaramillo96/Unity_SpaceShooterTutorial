using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonsFunction : MonoBehaviour {

	public bool menuActive;
	[SerializeField]
	private GameObject menu;

	void Start ()
	{
		menu.SetActive (true);
		menuActive = true;
		Time.timeScale = 0f;
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.P))
		{
			menu.SetActive (true);
			menuActive = true;
			Time.timeScale = 0f;
		}
	}

	public void Play()
	{
		if (menuActive == true)
		{
			menu.SetActive (false);
			menuActive = false;
			Time.timeScale = 1f;
		}
	}

	public void Exit()
	{
		Application.Quit ();
	}
}