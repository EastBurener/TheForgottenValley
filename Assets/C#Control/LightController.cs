using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlObjectController : MonoBehaviour
{
    public GameObject lightObject; // 在Unity中指定的Light对象
    public GameObject controlledObject; // 在Unity中指定的被控对象
    public float detectionRadius = 2f; // 检测半径
    public float triggerTime = 3f; // 触发时间
    public float moveDistance = -10f; // 在Unity中控制的Y方向上移动的距离，负值表示下移
    private float timer = 0f; // 计时器
    private bool hasMoved = false; // 标志物体是否已经移动

    void Update()
    {
        // 检测与Light的接近程度
        if (Vector2.Distance(lightObject.transform.position, transform.position) < detectionRadius)
        {
            // 如果在检测半径内，开始计时
            if (!hasMoved)
            {
                timer += Time.deltaTime;
                if (timer >= triggerTime)
                {
                    // 达到触发时间后，移动被控对象
                    MoveControlledObject();
                    hasMoved = true; // 设置标志，表示物体已经移动
                }
            }
        }
        else
        {
            // 如果不在检测半径内，重置计时器
            timer = 0f;
            hasMoved = false; // 重置移动标志，以便下次可以再次移动
        }
    }

    void MoveControlledObject()
    {
        // 移动被控对象到指定位置
        controlledObject.transform.position += new Vector3(0, moveDistance, 0);
    }
}