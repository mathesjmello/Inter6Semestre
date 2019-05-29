using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;


public class MenuPrincipal : MonoBehaviour
{
	public bool menuInicial;

	public GameObject menu;

	public GameObject MainMenuScreen;
	public GameObject OptionScreen;
	public GameObject NewGameScreen;
	public GameObject PauseController;

	public GameObject Player;
	public GameObject PlayerCam;

	private Behaviour PlayerScript;

	public GameObject MenuCam;

    public GameObject primeiraFala;

	public GameObject brilhoEAudioObject;
	public GameObject sensibilObject;

	public PostProcessProfile PostProcessProfile;
	private ColorGrading colorGrading;
	private MasterVolume MasterVolume;
	private TesteCharDrunk TesteCharDrunk;



	static private float brilho = 0;
	static private float sensibilidade = 30;
	static private float volume = 1;

    public GameObject tutorial;

	public AudioSource menuSound;

	public bool spawn;

	public Respawn novo;

	public bool loadGameTrue;

	public int loadGameFase;


	public GameObject loadButtonOn;

	public GameObject loadButtonOff;

	public int saveGameOver;

	


	private void Start()
	{

		saveGameOver = PlayerPrefs.GetInt("VoltouDoGameOver");

		if (saveGameOver >= 1)
		{
			LoadGame();
		}
        primeiraFala.SetActive(false);

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
            tutorial.SetActive(false);
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


		if (loadGameFase == 0)
		{
			loadButtonOn.SetActive(false);
			loadButtonOff.SetActive(true);
		}

		if (loadGameFase >= 1)
		{
			loadButtonOn.SetActive(true);
			loadButtonOff.SetActive(false);
		}
	}

	public void Jogar()
	{
		MainMenuScreen.SetActive(!MainMenuScreen.activeSelf);
		NewGameScreen.SetActive(true);
		loadGameFase = PlayerPrefs.GetInt("Level");

	}

    public void NewGame()
    {
        primeiraFala.SetActive(true);
		PlayerScript.enabled = true;
		MenuCam.SetActive(false);
		PlayerCam.SetActive(true);
		PauseController.SetActive(true);

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;


		NewGameScreen.SetActive(false);
		OptionScreen.SetActive(false);
		MainMenuScreen.SetActive(false);

		menuSound.Stop();
		novo.fase = 0;

		PlayerPrefs.SetInt("Level",0);


	}

	public void LoadGame()
    {
		PlayerScript.enabled = true;
		MenuCam.SetActive(false);
		PlayerCam.SetActive(true);
		PauseController.SetActive(true);

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
        tutorial.SetActive(true);


		NewGameScreen.SetActive(false);
		OptionScreen.SetActive(false);
		MainMenuScreen.SetActive(false);

		menuSound.Stop();
		spawn = true;

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
		PlayerPrefs.SetInt("VoltouDoGameOver",0);


	}
}
