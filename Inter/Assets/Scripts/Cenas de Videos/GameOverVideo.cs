using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.Experimental.Video;
using UnityEngine.Experimental.Audio;

public class GameOverVideo : MonoBehaviour
{

    public VideoPlayer VideoClip;

    public GameObject gameOver;

    public Respawn ativa;


    // Start is called before the first frame update
    void Start()
    {
        VideoClip.loopPointReached += EndReached;
        //ativa.ativaRespawn = true;
        AudioListener.pause = true;
        Debug.Log("Video01");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PulaVideo(){
        gameOver.SetActive(false);
        ativa.acabouRespawn = true;
        AudioListener.pause = false;
        Debug.Log("Video02");

    }

    void EndReached(UnityEngine.Video.VideoPlayer vp){
        gameOver.SetActive(false);
        ativa.acabouRespawn = true;
        AudioListener.pause = false;
        Debug.Log("Video03");
    }

}
