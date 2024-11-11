using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateController : MonoBehaviour
{
    public GameObject controlledObject; // ��Unity��ָ���Ŀ��ƶ���
    public float moveDistance = -10f; // ��Unity�������Y�������ƶ��ľ���
    private bool hasMoved = false; // ��־�����Ƿ��Ѿ��ƶ�

    void Start()
    {
        // ȷ����ʼʱ����û���ƶ�
        hasMoved = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // ��ѹ�����������������巢����ײʱ
        if (!hasMoved)
        {
            // �ƶ����ƶ���ָ��λ��
            controlledObject.transform.position += new Vector3(0, moveDistance, 0);
            // ���ñ�־����ʾ�����Ѿ��ƶ�
            hasMoved = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // ��ѹ������������������ֹͣ��ײʱ�������������·�
        // ����Ҫ���κβ�������Ϊ����Ӧ�ñ������ƶ����λ��
    }
}