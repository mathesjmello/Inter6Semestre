using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class QuestLog : MonoBehaviour
{ 
    [HideInInspector]
    public static int currentLine = 0;

    public TextMeshProUGUI theTextMeshPro;

    public TextAsset textFile;
    public string[] textLines;

    private void Start()
    {
        AssimilaTexto();
    }

    private void Update()
    {
        Quests();
    }
    
    void AssimilaTexto()
    {
        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }
    }

    public void Quests()
    {
        theTextMeshPro.text = textLines[currentLine];
    }

    public void ProximaQuest()
    {
        currentLine++;
    }
}