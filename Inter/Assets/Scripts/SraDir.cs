using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SraDir : MonoBehaviour
{
   // The target marker.
    Transform target;

    // Angular speed in radians per sec.
    float speed = 5;

    public GameObject player;

    void Update()
    {
        target = player.transform;

        Vector3 targetDir = target.position - transform.position;

        // The step size is equal to speed times frame time.
        float step = speed * Time.deltaTime;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
        Debug.DrawRay(transform.position, newDir, Color.red);

        // Move our position a step closer to the target.
        transform.rotation = Quaternion.LookRotation(newDir);
    }
}
