using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextManager : MonoBehaviour
{
    public GameObject textBox;

    public int tempoEntreAsFalas;

    bool ativou = true;
    bool textBoxLigada = false;

    [HideInInspector]
    public int currentLine = 0;
    public int endAtLine;

    public TextMeshProUGUI theText;

    public TextAsset textFile;
    public string[] textLines;

    private void Start()
    {
        theText = GetComponentInChildren<TextMeshProUGUI>();
        textBox.SetActive(false);
        AssimilaTexto();
    }


    void AssimilaTexto()
    {
        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && ativou == true)
        {
            ativou = false;
            StartCoroutine(Teste());
        }
    }


    IEnumerator Teste()
    {
        for (int i = 0; i < endAtLine; i++)
        {
            theText.text = textLines[currentLine];
            if (textBoxLigada == false)
            {
                textBox.SetActive(true);
                textBoxLigada = true;
            }
            yield return new WaitForSeconds(tempoEntreAsFalas);
            currentLine++;
        }
        textBox.SetActive(false);
        Destroy(gameObject);
    }
}