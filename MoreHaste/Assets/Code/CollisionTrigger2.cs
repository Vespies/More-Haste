using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTrigger2 : MonoBehaviour
{
    private Material PlayerBall2;
    private Material pb1;
    public Player2Movement pm2;
    public CollisionTrigger1 ct1;
    public Player1Movement p1m;
    // Start is called before the first frame update
    void Start()
    {
        //Finding all the necessary components
        pb1 = GameObject.Find("Player1").GetComponent<Renderer>().material;
        PlayerBall2 = GetComponent<Renderer>().material;
        ct1 = GameObject.Find("Player1").GetComponent<CollisionTrigger1>();
        pm2 = GameObject.Find("Player2").GetComponent<Player2Movement>();
        p1m = GameObject.Find("Player1").GetComponent<Player1Movement>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter(Collider other)
    {
        //When collision is made, start coroutine
        StartCoroutine(TagManager(other));

    }
    public void Tagging()
    {
        //Depending on the tag, different speed, and colour is assigned
        if (gameObject.tag == "Tagged")
        {
            pm2.speed = 10.5f;
            PlayerBall2.color = Color.red;
            Debug.Log("2 gets all the benefits of being tagged");
        }
        else
        {
            pm2.speed = 8.5f;
            PlayerBall2.color = Color.green;
        }
    }
    public IEnumerator TagManager(Collider other)
    {
        if (gameObject.tag == "Tagged" && other.gameObject.tag == "NotTagged")
        {
            other.gameObject.tag = "MidTagged"; //The other player becomes neither tagged nor nottagged
            pb1.color = Color.yellow; //The other player changes colour to yellow
            yield return new WaitForSeconds(1); //After one second
            gameObject.tag = "NotTagged"; //This one then becomes loses its tagged and gains nottagged
            Tagging(); //Assignment
            other.gameObject.tag = "Tagged"; //The other player becomes tagged which makes the blues chase them
            ct1.Tagging(); //The player who became tagged does their tagging
        }
    }
}
