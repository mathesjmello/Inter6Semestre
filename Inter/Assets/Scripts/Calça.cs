using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calça : MonoBehaviour
{

    public GameObject texto_03;
    public GameObject texto_04;

    public GameObject dimitri;
    public GameObject esposa;

    public Animator portaGrandeAnim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            esposa.SetActive(true);
			Destroy(this.gameObject);
			portaGrandeAnim.SetInteger("ComCalça", 1);
            texto_03.SetActive(true);
            texto_04.SetActive(true);
            dimitri.GetComponent<Dimitri>().comCalca = true;
        }
    }
}
