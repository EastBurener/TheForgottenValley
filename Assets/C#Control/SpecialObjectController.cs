using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialObjectController : MonoBehaviour
{
    public Transform lightTransform; // Light�����Transform
    public float activationDistance = 5f; // �������
    private Collider2D objectCollider; // �����Collider
    private SpriteRenderer objectRenderer; // �����Renderer
    private Rigidbody2D objectRb;

	public float lightDuration = 2f; // ����ʱ�����ʱ��
	private float lightTimer; // ��ʱ��

	void Start()
    {
        // ��ȡ�����Collider��Renderer��Righbody2D���
        objectCollider = GetComponent<Collider2D>();
        objectRenderer = GetComponent<SpriteRenderer>();
        objectRb = GetComponent<Rigidbody2D>();

        // ��ʼ״̬�½���Collider���������壬��������
        objectCollider.enabled = false;
        objectRenderer.enabled = false;
        objectRb.bodyType = RigidbodyType2D.Kinematic;
    }

    void Update()
    {
        // ���㵱ǰ������Light���֮��ľ���
        float distanceToLight = Vector2.Distance(transform.position, lightTransform.position);

        // ���Light�����������壬����ʾ������Collider������
        if (distanceToLight < activationDistance)
        {
			// ����յ��ˣ���ʼ��ʱ
			lightTimer += Time.deltaTime;
            // �����ʱ�������˹��ճ���ʱ��
            if (lightTimer > lightDuration)
                {
                objectCollider.enabled = true;
                objectRenderer.enabled = true;
                objectRb.bodyType = RigidbodyType2D.Dynamic;
            }
        }
        // ���LightԶ���������壬�����ز�����Collider������
        else
        {
            lightTimer = 0f;

			objectCollider.enabled = false;
            objectRenderer.enabled = false;
            objectRb.bodyType = RigidbodyType2D.Kinematic;
            objectRb.velocity = Vector2.zero;
            objectRb.angularVelocity = 0f;
        }
    }
}