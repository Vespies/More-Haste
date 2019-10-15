using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTrigger2 : MonoBehaviour
{
    private Material PlayerBall2;
    public Player2Movement pm2;
    // Start is called before the first frame update
    void Start()
    {
        pm2 = GameObject.Find("Player2").GetComponent<Player2Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerExit(Collider other)
    {
        Debug.Log("it's trigger 2 here " + other);
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
            pm2.speed = 0.09f;
            PlayerBall2 = GetComponent<Renderer>().material;
            PlayerBall2.color = Color.red;
        }
        else
        {
            pm2.speed = 0.07f;
            PlayerBall2 = GetComponent<Renderer>().material;
            PlayerBall2.color = Color.green;
        }
    }
}
