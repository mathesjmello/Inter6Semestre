using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calça : MonoBehaviour
{

    public GameObject texto_03;
    public GameObject texto_04;

    public GameObject dimitri;
    public GameObject esposa;

    public GameObject parte02;

    public GameObject bomba;

    public Animator portaGrandeAnim;

	public GameObject tutoriais;

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
			portaGrandeAnim.SetBool("Aberto", true);
            texto_03.SetActive(true);
            texto_04.SetActive(true);
            parte02.SetActive(true);
            bomba.SetActive(true);
            dimitri.GetComponent<Dimitri>().comCalca = true;
			tutoriais.SetActive(false);
        }
    }
}
