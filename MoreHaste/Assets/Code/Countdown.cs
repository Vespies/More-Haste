using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    [SerializeField] Player1Movement p1m;
    [SerializeField] Player2Movement p2m;
    [SerializeField] BeastMovement bm;
    [SerializeField] Chaser c;
    [SerializeField] Text ct;
    private float countdownTime= 3;
    float startingTime = 3f;
    float currentTime = 0f;
    void Start()
    {
        //At the start all movement is disabled and the timer starts from the max number
        currentTime = startingTime;
        p1m.enabled = false;
        p2m.enabled = false;
        bm.enabled = false;
        c.enabled = false;
        StartCoroutine(Counting(countdownTime));
    }

    // Update is called once per frame
    void Update()
    {
        //The colour of text starts as red and starts timer starts counting down each second
        ct.color = Color.red;
        currentTime -= 1 * Time.deltaTime;
        ct.text = currentTime.ToString("0");
        if (currentTime <= 0)
        {
            //Once the timer reaches 0, the text becomes transparent
            currentTime = 0;
            ct.color = Color.clear;
        }
    }
    public IEnumerator Counting(float rcooldownTime)
    {
        //After the timer is complete, all the movement is turned on again
        yield return new WaitForSeconds(rcooldownTime);
        p1m.enabled = true;
        p2m.enabled = true;
        bm.enabled = true;
        c.enabled = true;
    }
}
