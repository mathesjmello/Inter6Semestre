using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedBackSound : MonoBehaviour
{
    public GameObject feedSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayFeed(){
        feedSound.SetActive(true);
    }
}
