using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{


    public GameObject PauseScreen;
	public GameObject OptionScreen;

	public bool Paused;

	

	private float originalFixedTimeScale;

	public AudioSource menuSound;

	public AudioSource clickSom;

	public AudioSource continuarSom;


	private void Start()
	{
		Time.timeScale = 1.0f;
		originalFixedTimeScale = Time.fixedDeltaTime;
	}
	void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&& !OptionScreen.activeSelf)
        {
            PauseScreen.SetActive(!PauseScreen.activeSelf);
            Cursor.lockState = PauseScreen.activeSelf ? CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = PauseScreen.activeSelf;
            PauseTime();

        }

    }


    void PauseTime()
    {
        if (PauseScreen.activeSelf)
        {
	        Paused = true;
            Time.timeScale = 0f;
			Time.fixedDeltaTime = 0;
			AudioListener.pause = true;
			menuSound.Play();
			menuSound.ignoreListenerPause = true;
        }
        else
        {
	        Paused = false;
            Time.timeScale = 1.0f;
			Time.fixedDeltaTime = originalFixedTimeScale;
			AudioListener.pause = false;
			menuSound.Stop();
			menuSound.ignoreListenerPause = false;
		}
    }


	public void Continue()
	{
		PauseScreen.SetActive(!PauseScreen.activeSelf);
		Cursor.lockState = PauseScreen.activeSelf ? CursorLockMode.None : CursorLockMode.Locked;
		Cursor.visible = PauseScreen.activeSelf;
		PauseTime();
		continuarSom.Play();
	}

	public void Opções()
	{
		clickSom.Play();
		PauseScreen.SetActive(!PauseScreen.activeSelf);
		OptionScreen.SetActive(true);
		


	}

	public void VoltaOpções()
	{
		clickSom.Play();
		OptionScreen.SetActive(false);
		PauseScreen.SetActive(true);
		
		
	}


	public void VaiPraMenuPrincipal()
	{
		clickSom.Play();
		Time.timeScale = 1.0f;
		Time.fixedDeltaTime = originalFixedTimeScale;
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		SceneManager.LoadScene("Fase01");
		PlayerPrefs.SetInt("VoltouDoGameOver",0);
		

	}

}
