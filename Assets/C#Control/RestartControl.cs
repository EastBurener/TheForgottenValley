using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartControl : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // 确保只有玩家经过时才记录位置
        {
            RecordPos.lastRecorded = transform.position; // 记录当前位置
        }
    }
}
