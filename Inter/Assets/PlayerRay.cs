using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRay : MonoBehaviour
{
    public GameObject cartazObj;

    public TesteCharDrunk comCartazOn;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RayOn();
    }

    
	 void RayOn()
    {


        RaycastHit hit;

         if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward) , out hit, 5.0f))
        {

            if (hit.collider.CompareTag("Parede"))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward)* 5.0f, Color.red);
                Debug.Log("Hit");

                if (Vector3.Distance(transform.position, hit.point) < 5.0f)
                {

                    if (Input.GetKeyDown(KeyCode.E)){
                    var cartaz = GameObject.Instantiate(cartazObj);
                    cartaz.transform.position = hit.point;
                    cartaz.transform.rotation = hit.transform.rotation;
                    comCartazOn.comCartaz = false;
                    }
                }
            }
        
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 5.0f, Color.blue);
        }
        }
    }
}
