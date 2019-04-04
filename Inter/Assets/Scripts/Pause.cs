using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{


    public GameObject PauseScreen;


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
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }
}
