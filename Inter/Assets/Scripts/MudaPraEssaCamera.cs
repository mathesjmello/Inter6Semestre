using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MudaPraEssaCamera : MonoBehaviour
{
    public CinemachineVirtualCamera cam;
    public bool wait;
    public float waitTime;

    public static float camIndex;
    public float camIndexMin;
    public float camIndexMax;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

IEnumerator WaitToStopLooking()
{

  yield return new WaitForSeconds(waitTime);
  camIndex++;
  Destroy(gameObject);
}
    private void OnTriggerEnter(Collider other) {
        
    cam.Priority = other.CompareTag("Player") && camIndexMin <= camIndex && camIndex < camIndexMax? 20 : cam.Priority;
    print(cam.Priority);
    if(wait)StartCoroutine(WaitToStopLooking());

    }

    private void OnTriggerExit(Collider other) {
        
      if(other.CompareTag("Player") && !wait)  
    cam.Priority = 0;
    

    }
}
