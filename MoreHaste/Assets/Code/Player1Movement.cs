using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Movement : MonoBehaviour
{
    public float speed;
    private Material PlayerBall1;
    private float cooldownTime;
    private bool cooldownState;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Tagged";
        Tagging();
        cooldownState = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(0, 0, 0);
        if (Input.GetKey("w"))
        {
            direction += Vector3.forward;
            if (Input.GetKey("space") && cooldownState && gameObject.tag == "Tagged")
            {

                transform.Translate(0, 0, 5);
                cooldownTime = 3;
                StartCoroutine(Cooldown(cooldownTime));
            }
        }
        if (Input.GetKey("s"))
        {
            direction -= Vector3.forward;
            if (Input.GetKey("space") && cooldownState && gameObject.tag == "Tagged")
            {

                transform.Translate(0, 0, -5);
                cooldownTime = 3;
                StartCoroutine(Cooldown(cooldownTime));
            }
        }
        if (Input.GetKey("a"))
        {
            direction -= Vector3.right;
            if (Input.GetKey("space") && cooldownState && gameObject.tag == "Tagged")
            {

                transform.Translate(-5, 0, 0);
                cooldownTime = 3;
                StartCoroutine(Cooldown(cooldownTime));
            }
        }
        if (Input.GetKey("d"))
        {
            direction += Vector3.right;
            if (Input.GetKey("space") && cooldownState && gameObject.tag == "Tagged")
            {

                transform.Translate(5, 0, 0);
                cooldownTime = 3;
                StartCoroutine(Cooldown(cooldownTime));
            }
        }
        if (direction != new Vector3(0, 0, 0))
        {
            transform.Translate(direction.normalized * speed * Time.deltaTime);
        }
    }
    public void Tagging()
    {
        if (gameObject.tag == "Tagged")
        {
            speed = 10.5f;
            Debug.Log("1 initial assignment");
            PlayerBall1 = GetComponent<Renderer>().material;
            PlayerBall1.color = Color.red;
        }
        else
        {
            speed = 8.5f;
            PlayerBall1 = GetComponent<Renderer>().material;
            PlayerBall1.color = Color.green;
        }
    }
    public IEnumerator Cooldown(float rcooldownTime)
    {
        Debug.Log("routine started");
        cooldownState = false;
        yield return new WaitForSeconds(rcooldownTime);
        cooldownState = true;

    }
}
