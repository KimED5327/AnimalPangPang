using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class BallManager : MonoBehaviour
{

    [SerializeField] private GameObject ballEffect;
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


    public void CreateBallEffect(Vector3 pos, int level)
    {
        var effect = Instantiate(ballEffect);
        effect.transform.position = pos;

        effect.transform.localScale = Vector3.one + ((level - 1) * 1.1f * Vector3.one);
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
