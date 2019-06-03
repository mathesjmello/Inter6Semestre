using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public bool detectado;

    private Behaviour PlayerScript; 

    public GameObject Player;

    public Respawn level;

    // Start is called before the first frame update
    void Start()
    {
    //PlayerPrefs.SetInt("VoltouDoGameOver",1);
    PlayerScript = Player.GetComponent<TesteCharDrunk>();
    }

    // Update is called once per frame
    void Update()
    {
        if (detectado)
        {
        StartCoroutine(FeedBack());
        }
    }

    IEnumerator FeedBack(){

    PlayerScript.enabled = false;
    PlayerPrefs.SetInt("Level",level.fase);
    PlayerPrefs.SetInt("VoltouDoGameOver", level.fase);

    yield return new WaitForSeconds(3.0f);  
     SceneManager.LoadScene("GameOverScene");

    }
}
