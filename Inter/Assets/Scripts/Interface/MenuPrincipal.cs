using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
	public GameObject MainMenuScreen;
	public GameObject OptionScreen;
	public GameObject NewGameScreen;
	public GameObject PauseController;

	public GameObject Player;
	public GameObject PlayerCam;

	private Behaviour PlayerScript;

	public GameObject MenuCam;


	private void Start()
	{
		PlayerScript = Player.GetComponent<TesteCharDrunk>();
		PlayerScript.enabled = false;
		PlayerCam.SetActive(false);

		MenuCam.SetActive(true);

		PauseController.SetActive(false);


		Time.timeScale = 1.0f;
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	public void Jogar()
	{
		MainMenuScreen.SetActive(!MainMenuScreen.activeSelf);
		NewGameScreen.SetActive(true);

	}

    public void NewGame()
    {
		PlayerScript.enabled = true;
		MenuCam.SetActive(false);
		PlayerCam.SetActive(true);
		PauseController.SetActive(true);

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;


		NewGameScreen.SetActive(false);
		OptionScreen.SetActive(false);
		MainMenuScreen.SetActive(false);


	}
	public void Opções()
	{
		MainMenuScreen.SetActive(!MainMenuScreen.activeSelf);
		OptionScreen.SetActive(true);


	}

	public void VoltaOpções()
	{
		NewGameScreen.SetActive(false);
		OptionScreen.SetActive(false);
		MainMenuScreen.SetActive(true);

	}

	public void Créditos()
	{
		SceneManager.LoadScene(0);

	}


	public void QuitGame()
	{

#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#endif

		Application.Quit();


	}
}
