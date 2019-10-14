using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    private float speed;
    private Material PlayerBall2;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "NotTagged";
        Tagging();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            transform.Translate(Vector3.forward * speed);
        }
        if (Input.GetKey("down"))
        {
            transform.Translate(Vector3.forward * -speed);
        }
        if (Input.GetKey("left"))
        {
            transform.Translate(Vector3.right * -speed);
        }
        if (Input.GetKey("right"))
        {
            transform.Translate(Vector3.right * speed);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (gameObject.tag == "Tagged")
        {
            if (other.gameObject.tag == "NotTagged")
            {
                gameObject.tag = "NotTagged";
                speed = 0.07f;
                PlayerBall2 = GetComponent<Renderer>().material;
                PlayerBall2.color = Color.green;
                //Tagging();  
            }
        }
        if (gameObject.tag == "NotTagged")
        {
            if (other.gameObject.tag == "Tagged")
            {
                gameObject.tag = "Tagged";
                speed = 0.09f;
                Debug.Log("worked");
                PlayerBall2 = GetComponent<Renderer>().material;
                PlayerBall2.color = Color.red;
                //Tagging();  
            }
        }
    }
    public void Tagging()
    {
        if (gameObject.tag == "Tagged")
        {
            speed = 0.09f;
            Debug.Log("worked");
            PlayerBall2 = GetComponent<Renderer>().material;
            PlayerBall2.color = Color.red;
        }
        else
        {
            speed = 0.07f;
            PlayerBall2 = GetComponent<Renderer>().material;
            PlayerBall2.color = Color.green;
        }
    }
}
