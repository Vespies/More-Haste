using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTrigger1 : MonoBehaviour
{
    private Material PlayerBall1;
    public Player1Movement p1m;
    // Start is called before the first frame update
    void Start()
    {
        p1m = GameObject.Find("Player1").GetComponent<Player1Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerExit(Collider other)
    {
        Debug.Log("it's trigger 1 here " + other);
        if (gameObject.tag == "Tagged" && other.gameObject.tag == "NotTagged")
        {
            gameObject.tag = "NotTagged";
            other.gameObject.tag = "Tagged";
            Tagging();
        }
    }
    public void Tagging()
    {
        if (gameObject.tag == "Tagged")
        {
            p1m.speed = 0.09f;
            PlayerBall1 = GetComponent<Renderer>().material;
            PlayerBall1.color = Color.red;
        }
        else
        {
            p1m.speed = 0.07f;
            PlayerBall1 = GetComponent<Renderer>().material;
            PlayerBall1.color = Color.green;
        }
    }
}
