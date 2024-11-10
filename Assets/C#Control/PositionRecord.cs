using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordPosition : MonoBehaviour
{
    public static Vector2 lastRecordedPosition; // ��̬���������ڴ洢���һ�μ�¼������

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            lastRecordedPosition = other.transform.position;
        }
    }
}
