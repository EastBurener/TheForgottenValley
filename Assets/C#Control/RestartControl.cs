using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartControl : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // ȷ��ֻ����Ҿ���ʱ�ż�¼λ��
        {
            RecordPos.lastRecorded = transform.position; // ��¼��ǰλ��
        }
    }
}
