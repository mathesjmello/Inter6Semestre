using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MesaCai : MonoBehaviour
{
    public float Speed = 0.1f; 
    public AudioSource mesaSound;
    public GameObject outraMesa;

    public GameObject posCerta;

    private Transform _target; 

    public Animator objsAnim;

    public string AnimName= "Caiu";

    // Start is called before the first frame update
    void Start()
    {
        _target = posCerta.transform; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MesaCaiu(){
        mesaSound.Play(0);
        float step =  Speed * Time.deltaTime; 
        outraMesa.transform.position = Vector3.MoveTowards(_target.transform.position,_target.position, step);
        objsAnim.SetTrigger(AnimName);
    }
}
