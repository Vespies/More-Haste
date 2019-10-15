using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTrigger1 : MonoBehaviour
{
    private Material PlayerBall1;
    public Player1Movement p1m;
    public CollisionTrigger2 ct2;
    // Start is called before the first frame update
    void Start()
    {
        ct2 = GameObject.Find("Player2").GetComponent<CollisionTrigger2>();
        p1m = GameObject.Find("Player1").GetComponent<Player1Movement>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerExit(Collider other)
    {
        //Debug.Log("it's trigger 1 here " + other);
        StartCoroutine(TagManager(other));
    }
    public void Tagging()
    {

        if (gameObject.tag == "Tagged")
        {
            p1m.speed = 0.09f;
            PlayerBall1 = GetComponent<Renderer>().material;
            PlayerBall1.color = Color.red;
            Debug.Log("1 gets all the benefits of being tagged");
        }
        else
        {
            p1m.speed = 0.07f;
            PlayerBall1 = GetComponent<Renderer>().material;
            PlayerBall1.color = Color.green;
        }
    }
    public IEnumerator TagManager(Collider other)
    {
        if (gameObject.tag == "Tagged" && other.gameObject.tag == "NotTagged")
        {
            gameObject.tag = "NotTagged";
            Debug.Log("1 becomes not tagged and 2 becomes tagged");
            Tagging();
            yield return new WaitForSeconds(1);
            other.gameObject.tag = "Tagged";
            ct2.Tagging();
        }
    }
}
