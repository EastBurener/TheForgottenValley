using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordPos : MonoBehaviour
{
    public static Vector3 lastRecorded; // 存储最后一个记录的重生点位置

    private void Start()
    {
        // 初始化重生点位置为玩家的初始位置
        lastRecorded = transform.position;
    }
}