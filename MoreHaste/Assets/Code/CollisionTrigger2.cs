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
            PlayerBall2.color = Color.red;
            Debug.Log("2 gets all the benefits of being tagged");
        }
        else
        {
            pm2.speed = 0.07f;
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
            p1m.enabled = false;
            pb1.color = Color.yellow;
            yield return new WaitForSeconds(0.3f);
            p1m.enabled =true;
            other.gameObject.tag = "Tagged";
            ct1.Tagging();
        }
    }
}
