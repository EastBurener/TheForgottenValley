using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlObjectController : MonoBehaviour
{
    public GameObject lightObject; // ��Unity��ָ����Light����
    public GameObject controlledObject; // ��Unity��ָ���ı��ض���
    public float detectionRadius = 2f; // ���뾶
    public float triggerTime = 3f; // ����ʱ��
    private float timer = 0f; // ��ʱ��
    private bool hasMoved = false; // ��־�����Ƿ��Ѿ��ƶ�

    void Update()
    {
        // �����Light�Ľӽ��̶�
        if (Vector2.Distance(lightObject.transform.position, transform.position) < detectionRadius)
        {
            // ����ڼ��뾶�ڣ���ʼ��ʱ
            if (!hasMoved)
            {
                timer += Time.deltaTime;
                if (timer >= triggerTime)
                {
                    // �ﵽ����ʱ����ƶ����ض���
                    MoveControlledObject();
                    hasMoved = true; // ���ñ�־����ʾ�����Ѿ��ƶ�
                }
            }
        }
        else
        {
            // ������ڼ��뾶�ڣ����ü�ʱ��
            timer = 0f;
        }
    }

    void MoveControlledObject()
    {
        // �ƶ����ض���ָ��λ��
        controlledObject.transform.position += new Vector3(0, -10f, 0); // ��������10����λ
    }
}