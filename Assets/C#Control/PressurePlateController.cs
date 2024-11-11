using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateController : MonoBehaviour
{
    public GameObject controlledObject; // 在Unity中指定的控制对象
    public float moveDistance = -10f; // 在Unity中输入的Y方向上移动的距离
    private bool hasMoved = false; // 标志物体是否已经移动

    void Start()
    {
        // 确保初始时物体没有移动
        hasMoved = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 当压力板与其他任意物体发生碰撞时
        if (!hasMoved)
        {
            // 移动控制对象到指定位置
            controlledObject.transform.position += new Vector3(0, moveDistance, 0);
            // 设置标志，表示物体已经移动
            hasMoved = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // 当压力板与其他任意物体停止碰撞时，保持物体在下方
        // 不需要做任何操作，因为物体应该保持在移动后的位置
    }
}