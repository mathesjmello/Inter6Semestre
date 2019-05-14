using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vodka : MonoBehaviour
{

    public GameObject player;

    public TesteCharDrunk shots;

	public GameObject tutorial;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay(Collider other){
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            player.GetComponent<TesteCharDrunk>().vodka = true;
            shots.doses = 3;
            Destroy(this.gameObject);
			if (tutorial)
			{
				tutorial.SetActive(false);
			}
        }
    }
}
