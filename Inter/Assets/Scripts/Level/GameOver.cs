using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public bool detectado;

    // Start is called before the first frame update
    void Start()
    {
    //PlayerPrefs.SetInt("VoltouDoGameOver",1);
    }

    // Update is called once per frame
    void Update()
    {
        if (detectado)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
