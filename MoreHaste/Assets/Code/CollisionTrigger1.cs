using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTrigger1 : MonoBehaviour
{
    private Material PlayerBall1;
    private Material pb2;
    public Player1Movement p1m;
    public CollisionTrigger2 ct2;
    // Start is called before the first frame update
    void Start()
    {
        //Finding all the necessary components
        pb2 = GameObject.Find("Player2").GetComponent<Renderer>().material;
        PlayerBall1 = GetComponent<Renderer>().material;
        ct2 = GameObject.Find("Player2").GetComponent<CollisionTrigger2>();
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
            p1m.speed = 10.5f;
            PlayerBall1.color = Color.red;
            Debug.Log("1 gets all the benefits of being tagged");
        }
        else
        {
            p1m.speed = 8.5f;
            PlayerBall1.color = Color.green;
        }
    }
    public IEnumerator TagManager(Collider other)
    {
        //When this object is tagged and the one with which the collision us made is nottagged
        if (gameObject.tag == "Tagged" && other.gameObject.tag == "NotTagged")
        {
            other.gameObject.tag = "MidTagged"; //The other player becomes neither tagged nor nottagged
            pb2.color = Color.yellow; //It changes colour to yellow
            yield return new WaitForSeconds(1); //After one second
            gameObject.tag = "NotTagged"; //This one then becomes loses its tagged and gains nottagged
            Tagging(); //Assignment
            other.gameObject.tag = "Tagged"; //The other player becomes tagged which makes the blues chase them
            ct2.Tagging(); //The player who became tagged does their tagging
        }
    }
}
