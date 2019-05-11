using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creditos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKey(KeyCode.Space)) Time.timeScale += 0.1f;
		else Time.timeScale = 1;
        
    }
}
