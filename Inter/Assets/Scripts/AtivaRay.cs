using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivaRay : MonoBehaviour
{
    public  bool MiraOn;

    // iniciando uma lista que pega diretamente o componente do raycast evitamos de dar getcomponent o tempotodo que é pouco performatico
    public List<RayCastSight> RayCasts;
   

    private void Start()
    {
        // isso é apenas para se esquecermos de colocar no inspector os ray casts dentro da lista ele pega automaticamente no começo 
        
        if (RayCasts.Capacity == 0)
        {
            foreach (var raycast in gameObject.GetComponentsInChildren(typeof(RayCastSight)))
            {
                RayCasts.Add(raycast.GetComponent<RayCastSight>());
            }
        }
    }


    void Update()
    {
        if (MiraOn == true)
        {
            //roda a lista toda ativando os raycasts
            foreach (var rk in RayCasts)
            {
                rk.rayOn = true;
            }
        }

        else
        {
            //roda a lista toda desativando os raycasts
            foreach (var rk in RayCasts)
            {
                rk.rayOn = false;
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Player")){
            MiraOn = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.CompareTag("Player")){
            MiraOn = false;
        }
    }
}
