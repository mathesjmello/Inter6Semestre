﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;


public class MenuPrincipal : MonoBehaviour
{
	public bool menuInicial;

	public GameObject MainMenuScreen;
	public GameObject OptionScreen;
	public GameObject NewGameScreen;
	public GameObject PauseController;

	public GameObject Player;
	public GameObject PlayerCam;

	private Behaviour PlayerScript;

	public GameObject MenuCam;


	public GameObject brilhoEAudioObject;
	public GameObject sensibilObject;

	public PostProcessProfile PostProcessProfile;
	private ColorGrading colorGrading;
	private MasterVolume MasterVolume;
	private TesteCharDrunk TesteCharDrunk;



	static private float brilho = 0;
	static private float sensibilidade = 30;
	static private float volume = 1;


	private void Start()
	{
		if (menuInicial)
		{
			PlayerScript = Player.GetComponent<TesteCharDrunk>();
			PlayerScript.enabled = false;
			PlayerCam.SetActive(false);

			MainMenuScreen.SetActive(true);

			MenuCam.SetActive(true);

			PauseController.SetActive(false);


			Time.timeScale = 1.0f;
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
		MasterVolume = brilhoEAudioObject.GetComponent<MasterVolume>();
		TesteCharDrunk = sensibilObject.GetComponent<TesteCharDrunk>();


	}

	private void Update()
	{
		PostProcessProfile.TryGetSettings(out colorGrading);
		colorGrading.postExposure.value = brilho;

		MasterVolume.masterVolume = volume;

		if(TesteCharDrunk)
		TesteCharDrunk.mouseSensivity = sensibilidade;
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

	public void Brilho(float valor)
	{
		brilho = valor;
	}

	public void Sensibilidade(float valor)
	{
		sensibilidade = valor;
	}

	public void Volume(float valor)
	{
		volume = valor;
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
