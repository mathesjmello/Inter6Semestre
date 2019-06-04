using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Elevador : MonoBehaviour
{

    public Respawn acabou;

    public AudioSource bell;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Dimitri") && acabou.fase >= 4){
            SceneManager.LoadScene("Fase02");
            bell.Play(0);
        }
    }
}
