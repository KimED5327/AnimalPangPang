using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float lerpTime = 0.02f;

    [SerializeField] private Transform tf_BallHolder;
    [SerializeField] private Camera cam;

    [SerializeField] private Transform tf_BallContainerParent;
    [SerializeField] private GameObject go_PrefabBall;

    [SerializeField] private GameObject go_Line;

    [SerializeField] private float waitTime = 0.5f;
    private float waitCurTime;
    
    private bool isTouchDown;
    private bool canShowLine;


    private Vector3 destPos;
    private bool isArrived = true;




    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        waitCurTime += Time.deltaTime;
        Move();

        // 마구 클릭 방지용
        if(waitTime < waitCurTime)
        {
            // 터치 가능할때 터치하면
            if (Input.GetMouseButtonDown(0))
            {
                waitCurTime = 0;
                isTouchDown = true;
            }
        }

        // 클릭 방출
        if (Input.GetMouseButtonUp(0))
        {
            isTouchDown = false;
        }

        UpdateTouchPoint();
    }


    private void UpdateTouchPoint()
    {
        if (false == isTouchDown)
            return;

        var targetPos = cam.ScreenToWorldPoint(Input.mousePosition);
        destPos = new Vector3(targetPos.x, tf_BallHolder.position.y, tf_BallHolder.position.z);
        
        isArrived = false;
    }


    private void Move()
    {
        if (isArrived)
            return;

        if (destPos == Vector3.zero)
            return;

        if (Time.deltaTime <= 0)
            return;

        tf_BallHolder.position = Vector3.Lerp(tf_BallHolder.position, destPos, lerpTime);

        if (isTouchDown)
            return;

        if(Mathf.Abs(tf_BallHolder.position.x - destPos.x) <= 0.05f)
        {
            destPos = Vector3.zero;
            isArrived = true;
            CreateBall();
        }
    }


    private void CreateBall()
    {
        var newBall = Instantiate(go_PrefabBall, tf_BallContainerParent);
        newBall.SetActive(true);

        newBall.transform.position = tf_BallHolder.position;
    }
}
