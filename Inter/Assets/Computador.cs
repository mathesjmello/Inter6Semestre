using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computador : MonoBehaviour
{

    public GameObject dimiCaido;

    public TesteCharDrunk player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player"))
        {
            dimiCaido.SetActive(true);
            player.carregando = false;
        }
    }
}
