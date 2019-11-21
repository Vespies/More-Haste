using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    private Transform target;
    private float speed = 0.001f;
    float currentSpeed = 0.01f;
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
            currentSpeed += speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(currentPosition, targetPosition, currentSpeed);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tagged")
        {
            Destroy(other.gameObject);
        }
    }
}
