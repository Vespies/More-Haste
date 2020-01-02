using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Chaser : MonoBehaviour
{
    private Transform target;
    private float speed = 0.001f;
    float currentSpeed = 0.01f;
    public UnityEvent endGame;
    void Start()
    {

    }

    void Update()
    {
        //As long as there is a tagged player, it becomes the target
        if (GameObject.FindWithTag("Tagged") != null)
            target = GameObject.FindWithTag("Tagged").transform;
        if(target != null)
        {
            //As long as there is a target, move towards it with increasing speed
            Vector3 currentPosition = transform.position;
            Vector3 targetPosition = target.position;
            currentSpeed += speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(currentPosition, targetPosition, currentSpeed);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        //When red is caught, it is destroyed and press r to restart pops up
        if (other.tag == "Tagged")
        {
            Destroy(other.gameObject);
            endGame.Invoke();
        }
    }

}
