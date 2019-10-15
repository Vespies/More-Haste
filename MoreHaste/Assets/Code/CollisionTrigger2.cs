using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTrigger2 : MonoBehaviour
{
    private Material PlayerBall2;
    public Player2Movement pm2;
    public CollisionTrigger1 ct1;

    // Start is called before the first frame update
    void Start()
    {
        ct1 = GameObject.Find("Player1").GetComponent<CollisionTrigger1>();
        pm2 = GameObject.Find("Player2").GetComponent<Player2Movement>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerExit(Collider other)
    {
        StartCoroutine(TagManager(other));
        //Debug.Log("it's trigger 2 here " + other);

    }
    public void Tagging()
    {
        
        if (gameObject.tag == "Tagged")
        {
            pm2.speed = 0.09f;
            PlayerBall2 = GetComponent<Renderer>().material;
            PlayerBall2.color = Color.red;
            Debug.Log("2 gets all the benefits of being tagged");
        }
        else
        {
            pm2.speed = 0.07f;
            PlayerBall2 = GetComponent<Renderer>().material;
            PlayerBall2.color = Color.green;
        }
    }
    public IEnumerator TagManager(Collider other)
    {
        if (gameObject.tag == "Tagged" && other.gameObject.tag == "NotTagged")
        {
            gameObject.tag = "NotTagged";
            Debug.Log("2 becomes not tagged and 1 becomes tagged");
            Tagging();
            yield return new WaitForSeconds(2);
            other.gameObject.tag = "Tagged";
            ct1.Tagging();
        }
    }
}
