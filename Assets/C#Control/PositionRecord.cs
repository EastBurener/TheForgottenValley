using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordPosition : MonoBehaviour
{
    public static Vector2 lastRecordedPosition; // 静态变量，用于存储最后一次记录的坐标

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            lastRecordedPosition = other.transform.position;
        }
    }
}
