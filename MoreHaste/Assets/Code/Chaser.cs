using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    private Transform target;
    public float speed = 5.0f;
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
            Vector3 currentPosition = transform.position;
            Vector3 targetPosition = target.position;
            float currentSpeed = speed * 0.01f;
            float dist = Vector3.Distance(transform.position, target.position);
            transform.position = Vector3.MoveTowards(currentPosition, targetPosition, currentSpeed);
        }

    }
}
