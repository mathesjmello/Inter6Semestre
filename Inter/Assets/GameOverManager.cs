using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class GameOverManager : MonoBehaviour
{
    public VideoPlayer VideoClip;
    
    // Start is called before the first frame update
    void Start()
    {
        VideoClip.loopPointReached += EndReached;
        PlayerPrefs.SetInt("VoltouDoGameOver",1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextScene()
    {
        SceneManager.LoadScene("Fase01");
    }
    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene("Fase01");
    }
}