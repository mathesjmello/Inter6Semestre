using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatManager : MonoBehaviour
{
    public GameObject texto;
    public GameObject textoInfo;
    public bool ativado;

    private void Start()
    {
        textoInfo.SetActive(true);
        texto.SetActive(false);
        FieldOfView.cheatAtivo = false;
        ativado = false;
    }


    public void Update()
    {
        Debug.Log(FieldOfView.cheatAtivo);
        if (Input.GetKeyDown(KeyCode.Y) && ativado == true)
        {
            textoInfo.SetActive(true);
            texto.SetActive(false);
            FieldOfView.cheatAtivo = false;
            ativado = false;

        }
        else if(Input.GetKeyDown(KeyCode.Y) && ativado == false)
        {
            textoInfo.SetActive(false);
            texto.SetActive(true);
            FieldOfView.cheatAtivo = true;
            ativado = true;
        }
    }
}
