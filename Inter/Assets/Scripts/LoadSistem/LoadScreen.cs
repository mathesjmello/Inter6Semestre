using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScreen : MonoBehaviour {

    AsyncOperation operaçao;

    public Slider barraDeLoading;

    // Use this for initialization
    void Start () {

        StartCoroutine(nameof(LevelLoad));
        
    }

    IEnumerator LevelLoad()
    {
        operaçao = SceneManager.LoadSceneAsync("Fase01");
        operaçao.allowSceneActivation = false;

        while (!operaçao.isDone)
        {
            barraDeLoading.value = 1 - operaçao.progress;
            if (operaçao.progress <= 0.9f)
            {
                barraDeLoading.value = 0;
                operaçao.allowSceneActivation = true;
            }
            
            yield return null;
        }
    }
}
