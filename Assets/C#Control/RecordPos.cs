using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordPos : MonoBehaviour
{
    public static Vector3 lastRecorded; // �洢���һ����¼��������λ��

    private void Start()
    {
        // ��ʼ��������λ��Ϊ��ҵĳ�ʼλ��
        lastRecorded = transform.position;
    }
}