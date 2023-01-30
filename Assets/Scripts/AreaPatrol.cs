using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaPatrol : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;

    public Transform[] moveSpots;
    private int startSpot;

    // Start is called before the first frame update
    void Start()
    {
        startSpot = 0;
        waitTime = startWaitTime;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position, moveSpots[startSpot].position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, moveSpots[startSpot].position) < 0.2f)
        {
            if (waitTime <= 0 )
            {
                if (startSpot == 0)
                {
                    startSpot = 1;
                }
                else
                {
                    startSpot = 0;
                }
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
