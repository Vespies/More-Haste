using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    private Transform target;
    private float speed = 0.002f;
    float currentSpeed = 0.07f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindWithTag("Tagged").transform;
        if(target != null)
        {
            //Debug.Log("target= " + target);
            Vector3 currentPosition = transform.position;
            Vector3 targetPosition = target.position;
            currentSpeed += Time.deltaTime * speed;
            transform.position = Vector3.MoveTowards(currentPosition, targetPosition, currentSpeed);
        }

    }
}
