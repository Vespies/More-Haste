using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    public float speed;
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
    //public void OnTriggerExit(Collider other)
    //{
    //    Debug.Log("it's 2 here" + other);
    //    if (gameObject.tag == "Tagged" && other.gameObject.tag == "NotTagged")
    //    {
    //        Debug.Log("2 has been untagged");
    //        gameObject.tag = "NotTagged";
    //        speed = 0.07f;
    //        PlayerBall2 = GetComponent<Renderer>().material;
    //        PlayerBall2.color = Color.green;
    //        //Tagging();  
    //        other.gameObject.tag = "Tagged";
    //    }
    //    else if (gameObject.tag == "NotTagged" && other.gameObject.tag == "Tagged")
    //    {
    //        Debug.Log("2 has been tagged");
    //        gameObject.tag = "Tagged";
    //        speed = 0.09f;
    //        PlayerBall2 = GetComponent<Renderer>().material;
    //        PlayerBall2.color = Color.red;
    //        //Tagging(); 
    //        other.gameObject.tag = "NotTagged";
    //    }
    //}
    public void Tagging()
    {
        if (gameObject.tag == "Tagged")
        {
            speed = 0.09f;
            Debug.Log("2 initial assignment");
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
