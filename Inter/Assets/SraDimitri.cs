using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SraDimitri : MonoBehaviour
{

    public FieldOfView detectou;

    public Animator animPorta;

    public Animator animSraDimitri;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (detectou.animMulher >= 1)
        {       
            Debug.Log("Animaçoes");
            animPorta.SetTrigger("Abriu");
            animSraDimitri.SetTrigger("Detectou");
            
            detectou.animMulher = 0;
        }
    }
}
