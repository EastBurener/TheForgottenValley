using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    public Vector2 minPosition;
    public Vector2 maxPosition;
    void Start()
    {

    }

    void LateUpdate()
    {
        if (target != null)
        {
            if (transform.position != target.position)
            {
                Vector3 targetPos = target.position;
                targetPos.x = Mathf.Clamp(targetPos.x, minPosition.x, maxPosition.x);
                targetPos.y = Mathf.Clamp(targetPos.y, minPosition.y, maxPosition.y);//限制相机位置
                transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
            }
        }
    }
    public void SetCamePosLimit(Vector2 minPos, Vector2 maxPos)//限制相机位置（注意Unity中限制的坐标要是世界坐标，不是相对坐标）
    {
        minPosition = minPos;
        maxPosition = maxPos;
    }
}


