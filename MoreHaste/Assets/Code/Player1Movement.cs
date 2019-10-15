using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Movement : MonoBehaviour
{
    public float speed;
    private Material PlayerBall1;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Tagged";
        Tagging();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            transform.Translate(Vector3.forward * speed);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(Vector3.forward * -speed);
        }
        if (Input.GetKey("a"))
        {
            transform.Translate(Vector3.right * -speed);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * speed);
        }
    }
    //public void OnTriggerExit(Collider other)
    //{
    //    Debug.Log("it's 1 here " + other);
    //    if (gameObject.tag =="Tagged" && other.gameObject.tag == "NotTagged")
    //    {
    //        gameObject.tag = "NotTagged";
    //        other.gameObject.tag = "Tagged";
    //        Tagging();
    //        OnTriggerExit.enabled = false;
    //    }
    //}
    public void Tagging()
    {
        if (gameObject.tag == "Tagged")
        {
            speed = 0.09f;
            Debug.Log("1 initial assignment");
            PlayerBall1 = GetComponent<Renderer>().material;
            PlayerBall1.color = Color.red;
        }
        else
        {
            speed = 0.07f;
            PlayerBall1 = GetComponent<Renderer>().material;
            PlayerBall1.color = Color.green;
        }
    }
}
