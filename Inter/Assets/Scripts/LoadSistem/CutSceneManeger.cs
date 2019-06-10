using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class CutSceneManeger : MonoBehaviour
{
    public VideoPlayer VideoClip;
    
    // Start is called before the first frame update
    void Start()
    {
        VideoClip.loopPointReached += EndReached;
        PlayerPrefs.SetInt("VoltouDoGameOver",0);
        PlayerPrefs.SetInt("Level",0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextScene()
    {
        SceneManager.LoadScene("LoadingScene");
    }
    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene("LoadingScene");
    }
}
