using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeastMovement : MonoBehaviour
{
    private Vector3 target;
    [SerializeField]
    private Vector3 self;
    private Vector3 velocity;
    private Vector3 acceleration;

    void Start()
    {
        self = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("Tagged") != null)
        {
            target = GameObject.FindWithTag("Tagged").transform.position;
            acceleration = Vector3.Normalize(target - self) * 0.5f * Time.deltaTime;

            velocity = velocity * 0.985f + acceleration;
            self = self + velocity;
            transform.position = self;
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
