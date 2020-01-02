using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Out : MonoBehaviour
{
    private Rigidbody rb;
    private Player1Movement p1m;
    private Player2Movement p2m;
    public UnityEvent endGame;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        //When one of the players come into contact
        if (other.tag == "Tagged" || other.tag =="NotTagged" || other.tag == "MidTagged")
        {
            //Their movement is halted and gravity starts affecting them
            rb = other.GetComponent<Rigidbody>();
            if (other.name == "Player1")
            {
                p1m = other.GetComponent<Player1Movement>();
                p1m.enabled = false;
            }
            else
            {
                p2m = other.GetComponent<Player2Movement>();
                p2m.enabled = false;
            }
            rb.isKinematic = false;
            endGame.Invoke();

        }
    }
}
