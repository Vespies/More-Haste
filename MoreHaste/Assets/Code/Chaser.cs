﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    private Transform target;
    private float speed = 0.002f;
    float currentSpeed;
    // Start is called before the first frame update
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
            //float dist = Vector3.Distance(transform.position, target.position);
            transform.position = Vector3.MoveTowards(currentPosition, targetPosition, currentSpeed);
        }

    }
}
