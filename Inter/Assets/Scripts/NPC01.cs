using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC01 : MonoBehaviour
{

    public float speed = 0.1f;

    public float turnSpeed = 30f;

    public GameObject npc;

    private Transform target;


    public GameObject point1;

    public GameObject point2;
    public Animator npcAnim;

    public int changeDirection = 1;

    public List<RayCastSight> RayCasts;

    // Start is called before the first frame update
    void Start()
    {
        npcAnim.SetBool("isWalking", true);     

       
    }

    // Update is called once per frame
    void Update()
    {

        if (changeDirection == 1)
        {
            target = point1.transform;
            
        }

        if (changeDirection == -1)
        {
            target = point2.transform;
            
        }

        float step =  speed * Time.deltaTime; 
        transform.position = Vector3.MoveTowards(transform.position, target.position, step); 
        npcAnim.SetBool("isWalking", true);

         if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            changeDirection *= -1;
            npc.transform.Rotate(0, 180, 0);
        }
    }
}
