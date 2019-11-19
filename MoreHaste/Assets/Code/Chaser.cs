using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    private Transform target;
    private float speed = 0.00001f;
    float currentSpeed = 0.0001f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("Tagged") != null)
            target = GameObject.FindWithTag("Tagged").transform;
        if(target != null)
        {
            //Debug.Log("target= " + target);
            Vector3 currentPosition = transform.position;
            Vector3 targetPosition = target.position;
            currentSpeed += speed;
            transform.position = Vector3.MoveTowards(currentPosition, targetPosition, currentSpeed);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
