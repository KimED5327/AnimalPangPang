using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int myIndex = 0;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (false == collision.CompareTag("Ball"))
            return;

        var collisionBall = collision.GetComponent<Ball>();

        if (collisionBall.myIndex != myIndex)
            return;

        Destroy(collisionBall.gameObject);

        myIndex++;
        transform.localScale = transform.localScale * 1.25f;
    }

}
