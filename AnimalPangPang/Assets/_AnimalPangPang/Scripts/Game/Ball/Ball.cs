using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEditor;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int level = 0;


    public bool isProgress;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (false == collision.CompareTag("Ball"))
            return;

        if (isProgress)
            return;
        

        var collisionBall = collision.GetComponent<Ball>();
        if (collisionBall.isProgress)
            return;

        if (collisionBall.level != level)
            return;


        StartCoroutine(LevelUpCo(collisionBall));
    }


    IEnumerator LevelUpCo(Ball collisionBall)
    {
        collisionBall.isProgress = true;
        isProgress = true;

        var myRigid = transform.GetComponent<Rigidbody2D>();
        myRigid.gravityScale = 0f;
        myRigid.velocity = Vector3.zero;


        var myCols = transform.GetComponents<Collider2D>();
        foreach (var col in myCols)
        {
            col.enabled = false;
        }

        var collisionBallRigid = collisionBall.GetComponent<Rigidbody2D>();
        collisionBallRigid.gravityScale = 0f;
        collisionBallRigid.velocity = Vector3.zero;


        collisionBall.GetComponent<Rigidbody2D>().gravityScale = 0f;
        foreach(var col in collisionBall.GetComponents<Collider2D>())
        {
            col.enabled = false;
        }


        // 서로 끌어당기기
        while (0.01f <= Vector3.SqrMagnitude(transform.position - collisionBall.transform.position))
        {
            transform.position = Vector3.Lerp(transform.position, collisionBall.transform.position, 0.15f);
            collisionBall.transform.position = Vector3.Lerp(collisionBall.transform.position, transform.position, 0.15f);
            yield return null;
        }

        // Level Up
        level++;

        // Last Level
        var isLastBallLevel = BallManager.Instance.IsLastBallLevel(level);
        if (isLastBallLevel)
        {
            transform.localScale *= 1.25f;
            isProgress = false;
            foreach(var col in myCols)
            {
                col.enabled = true;
            }
            myRigid.gravityScale = 1f;
        }


        // New Ball
        var newBallPrefab = BallManager.Instance.GetBall(level);
        var newBall = Instantiate(newBallPrefab, transform.parent);
        newBall.transform.position = transform.position;
        newBall.GetComponent<Ball>().level = level;

        ScoreManager.Instance.IncreaseScore(level);
        BallManager.Instance.CreateBallEffect(transform.position,level);



        // Other Ball Destroy
        Destroy(collisionBall.gameObject);
        Destroy(this.gameObject);
    }
}
