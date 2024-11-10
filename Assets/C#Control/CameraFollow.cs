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
                targetPos.y = Mathf.Clamp(targetPos.y, minPosition.y, maxPosition.y);//�������λ��
                transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
            }
        }
    }
    public void SetCamePosLimit(Vector2 minPos, Vector2 maxPos)//�������λ�ã�ע��Unity�����Ƶ�����Ҫ���������꣬����������꣩
    {
        minPosition = minPos;
        maxPosition = maxPos;
    }
}


