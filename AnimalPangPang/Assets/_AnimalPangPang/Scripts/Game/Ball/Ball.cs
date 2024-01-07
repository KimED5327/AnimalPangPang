using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int level = 0;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (false == collision.CompareTag("Ball"))
            return;

        var collisionBall = collision.GetComponent<Ball>();
        if (collisionBall.level != level)
            return;

        // Other Ball Destroy
        Destroy(collisionBall.gameObject);


        // Level Up
        level++;

        // Last Level
        var isLastBallLevel = BallManager.Instance.IsLastBallLevel(level);
        if (isLastBallLevel)
        {
            transform.localScale *= 1.25f;
            return;
        }



        // New Ball
        var newBallPrefab = BallManager.Instance.GetBall(level);
        var newBall = Instantiate(newBallPrefab, transform.parent);
        newBall.transform.position = transform.position;
        newBall.GetComponent<Ball>().level = level;

        
        Destroy(this.gameObject);
    }

}
