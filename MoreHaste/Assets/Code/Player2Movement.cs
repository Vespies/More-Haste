using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    public float speed;
    private Material PlayerBall2;
    private float cooldownTime;
    private bool cooldownState;
    // Start is called before the first frame update
    void Start()
    {
        //This one starts as nottagged and gets all benefits of being nottagged
        gameObject.tag = "NotTagged";
        Tagging();
        cooldownState = true;
}

    // Update is called once per frame
    void Update()
    {
        //Each arrow movement direction can be used to teleport with keypad0 as long as player2 is the one tagged
        Vector3 direction = new Vector3(0, 0, 0);
        if (Input.GetKey("up"))
        {
            direction += Vector3.forward;
            if (Input.GetKey(KeyCode.Keypad0) && cooldownState && gameObject.tag == "Tagged")
            {

                transform.Translate(0, 0, 5);
                cooldownTime = 3;
                StartCoroutine(Cooldown(cooldownTime));
            }
        }
        if (Input.GetKey("down"))
        {
            direction -= Vector3.forward;
            if (Input.GetKey(KeyCode.Keypad0) && cooldownState && gameObject.tag == "Tagged")
            {

                transform.Translate(0, 0, -5);
                cooldownTime = 3;
                StartCoroutine(Cooldown(cooldownTime));
            }
        }
        if (Input.GetKey("left"))
        {
            direction -= Vector3.right;
            if (Input.GetKey(KeyCode.Keypad0) && cooldownState && gameObject.tag == "Tagged")
            {

                transform.Translate(-5, 0, 0);
                cooldownTime = 3;
                StartCoroutine(Cooldown(cooldownTime));
            }
        }
        if (Input.GetKey("right"))
        {
            direction += Vector3.right;
            if (Input.GetKey(KeyCode.Keypad0) && cooldownState && gameObject.tag == "Tagged")
            {

                transform.Translate(5, 0, 0);
                cooldownTime = 3;
                StartCoroutine(Cooldown(cooldownTime));
            }
        }
        if (direction != new Vector3(0,0,0))
        {
            //Normalizing diagonal speed
            transform.Translate(direction.normalized * speed * Time.deltaTime);
        }
    }
    public void Tagging()
    {
        //Depending on the tag, different speed, and colour is assigned
        if (gameObject.tag == "Tagged")
        {
            speed = 10.5f;
            Debug.Log("2 initial assignment");
            PlayerBall2 = GetComponent<Renderer>().material;
            PlayerBall2.color = Color.red;
        }
        else
        {
            speed = 8.5f;
            PlayerBall2 = GetComponent<Renderer>().material;
            PlayerBall2.color = Color.green;
        }
    }
    public IEnumerator Cooldown(float rcooldownTime)
    {
        //Cooldown introduces a three second window during which teleport is not avaliable
        Debug.Log("routine started");
        cooldownState = false;
        yield return new WaitForSeconds(rcooldownTime);
        cooldownState = true;

    }
}
