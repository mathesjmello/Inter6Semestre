using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_NavMesh : MonoBehaviour
{

    /* <summary>
     Caso esse código esteja em algum NPC e 
     as configurações de NavMesh forem feitas
     corretamente (https://www.youtube.com/watch?v=KU2CKBlCAxQ)
     ao clicar com o mouse em alguma superfície
     em que raycast colida (ou seja alguma
     superfície que esteja no layer "ground")
     o NPC irá de mover até lá
     </summary>*/




    public LayerMask whatCanBeClickedOn;

    private NavMeshAgent myAgent;

    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if(Physics.Raycast (myRay, out hitInfo, 100, whatCanBeClickedOn))
            {
                myAgent.SetDestination(hitInfo.point);
            }
        }
    }
}
