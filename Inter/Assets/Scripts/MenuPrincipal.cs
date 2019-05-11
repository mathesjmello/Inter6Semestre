using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
	public GameObject MainMenuScreen;
	public GameObject OptionScreen;
	public GameObject NewGameScreen;

	public void Jogar()
	{
		MainMenuScreen.SetActive(!MainMenuScreen.activeSelf);
		NewGameScreen.SetActive(true);

	}

    public void NewGame()
    {
        SceneManager.LoadScene(2);


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
		SceneManager.LoadScene(1);

	}


	public void QuitGame()
	{

#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#endif

		Application.Quit();


	}
}
