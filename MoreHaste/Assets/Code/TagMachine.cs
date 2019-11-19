using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagMachine : MonoBehaviour
{
    public GameObject target;
    public Collider targetcollider;
    public CollisionTrigger2 ct2;
    public CollisionTrigger1 ct1;
    // Start is called before the first frame update
    void Start()
    {
        ct2 = GameObject.Find("Player2").GetComponent<CollisionTrigger2>();
        ct1 = GameObject.Find("Player1").GetComponent<CollisionTrigger1>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("Tagged") != null)
        {
            target = GameObject.FindWithTag("Tagged");
            targetcollider = target.GetComponent<BoxCollider>();
            if (target.name == "Player1")
            {
                ct1.enabled = true;
                ct2.enabled = false;
            }
            else if (target.name == "Player2")
            {
                ct2.enabled = true;
                ct1.enabled = false;
            }
        }

    }
}
