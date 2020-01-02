using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BeastMovement : MonoBehaviour
{
    private Vector3 target;
    [SerializeField]
    private Vector3 self;
    private Vector3 velocity;
    private Vector3 acceleration;
    public UnityEvent endGame;

    void Start()
    {
        //Saves its own position
        self = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("Tagged") != null)
        {
            target = GameObject.FindWithTag("Tagged").transform.position; //Saves target's position
            acceleration = Vector3.Normalize(target - self) * 0.5f * Time.deltaTime; //Acceleration is how the velocity changes each frame, velocity is how the position changes each frame
            //Normalization makes sure the object doesnt teleport to the target right away so we get a small vector with the direction, multiplaying by half simply further reduces it
            velocity = velocity * 0.995f + acceleration; //New velocity is slightly reduced old velocity plus acceleration (not reducing the old velocity would make the object orbit around the target endlessly)
            self = self + velocity; //New position is the old position plus the change in position
            transform.position = self; // The object is actually moved
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        //When red is caught, it is destroyed and "press r to restart" pops up
        if (other.tag == "Tagged")
        {
            Destroy(other.gameObject);
            endGame.Invoke();
        }
    }
}
