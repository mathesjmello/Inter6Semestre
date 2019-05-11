using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{


    public GameObject PauseScreen;
	public GameObject OptionScreen;

	private float originalFixedTimeScale;


	private void Start()
	{
		Time.timeScale = 1.0f;
		originalFixedTimeScale = Time.fixedDeltaTime;
	}
	void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
            Time.timeScale = 0f;
			Time.fixedDeltaTime = 0;
        }
        else
        {
            Time.timeScale = 1.0f;
			Time.fixedDeltaTime = originalFixedTimeScale;
		}
    }


	public void Continue()
	{
		PauseScreen.SetActive(!PauseScreen.activeSelf);
		Cursor.lockState = PauseScreen.activeSelf ? CursorLockMode.None : CursorLockMode.Locked;
		Cursor.visible = PauseScreen.activeSelf;
		PauseTime();
	}

	public void Opções()
	{
		PauseScreen.SetActive(!PauseScreen.activeSelf);
		OptionScreen.SetActive(true);


	}

	public void VoltaOpções()
	{
		OptionScreen.SetActive(false);
		PauseScreen.SetActive(true);
		
	}


	public void VaiPraMenuPrincipal()
	{
		Time.timeScale = 1.0f;
		Time.fixedDeltaTime = originalFixedTimeScale;
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		SceneManager.LoadScene(0);

	}

}
