using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;


public class MenuPrincipal : MonoBehaviour
{
    public QuestLog questManager;

	public bool menuInicial;

	public GameObject menu;

	public GameObject MainMenuScreen;
	public GameObject OptionScreen;
	public GameObject NewGameScreen;
	public GameObject PauseController;
    public GameObject ConfirmNewGameScreen;

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

	public AudioSource telefoneSound;

	public bool spawn;

	public Respawn novo;

	public bool loadGameTrue;

	public int loadGameFase;


	public GameObject loadButtonOn;

	public GameObject loadButtonOff;

	public int saveGameOver;

    public GameObject questLog;

	public AudioSource clickSound;

	public AudioSource jogarSound;

	public bool ativaNPCview;


	private void Start()
	{
        questLog.SetActive(false);
		PlayerScript = Player.GetComponent<TesteCharDrunk>();

		saveGameOver = PlayerPrefs.GetInt("VoltouDoGameOver");


        if (menuInicial)
		{
            QuestLog.currentLine = 0;
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

		if (saveGameOver >= 1)
		{
			LoadDoGameOver();
			//Debug.Log("LoadDoGameOver");

		}
        


	}

	private void Update()
	{
		PostProcessProfile.TryGetSettings(out colorGrading);
		colorGrading.postExposure.value = brilho;
		//print(colorGrading.postExposure.value);

//		MasterVolume.masterVolume = volume;

		if(TesteCharDrunk)
		TesteCharDrunk.mouseSensivity = sensibilidade;


		/*if (loadGameFase == 0)
		{
			loadButtonOn.SetActive(false);
			loadButtonOff.SetActive(true);
		}

		if (loadGameFase >= 1)
		{
			loadButtonOn.SetActive(true);
			loadButtonOff.SetActive(false);
		}*/
	}

	public void Jogar()
	{
		MainMenuScreen.SetActive(!MainMenuScreen.activeSelf);
		NewGameScreen.SetActive(true);
		loadGameFase = PlayerPrefs.GetInt("Level");
		clickSound.Play();

	}

    public void NewGame(bool forceStart)
    {
        /*if (PlayerPrefs.GetInt("Level") >= 1 && !forceStart)
        {
            ConfirmNewGameScreen.SetActive(true);

        }
        else
        {*/
        questLog.SetActive(true);
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
		telefoneSound.Stop();
        novo.fase = 0;
		Debug.Log("Resetou");
		jogarSound.Play();

        //PlayerPrefs.SetInt("Level", 0);
        //}


    }

	public void LoadDoGameOver(){

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
		telefoneSound.Stop();
		ativaNPCview = true;
		//spawn = true;
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
		telefoneSound.Stop();
		clickSound.Play();
		//spawn = true;

	}
	public void Opções()
	{
		MainMenuScreen.SetActive(!MainMenuScreen.activeSelf);
		OptionScreen.SetActive(true);
		clickSound.Play();


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
		clickSound.Play();

		

	}

	public void Créditos()
	{
		SceneManager.LoadScene("Credits");
		clickSound.Play();

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
