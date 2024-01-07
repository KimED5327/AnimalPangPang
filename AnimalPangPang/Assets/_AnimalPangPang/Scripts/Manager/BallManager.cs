using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class BallManager : MonoBehaviour
{

    [SerializeField] private List<GameObject> ballList;

    private static BallManager ballManager;

    public static BallManager Instance 
    { 
        get 
        {
            return ballManager; 
        } 
    }

    private void Awake()
    {
        ballManager = this;
    }



    public GameObject GetBall(int level)
    {
        if(ballList.Count <= level)
        {
            return ballList.Last();
        }


        return ballList[level];
    }

    public bool IsLastBallLevel(int level)
    {
        return ballList.Count <= level;
    }

}
