using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakerController : MonoBehaviour
{
    public Transform lightTransform; // Light组件的Transform
    public float activationDistance = 5f; // 激活距离
    private Collider2D objectCollider; // 物体的Collider
    private SpriteRenderer objectRenderer; // 物体的Renderer
    private Rigidbody2D objectRb;

    void Start()
    {
        // 获取物体的Collider，Renderer，Righbody2D组件
        objectCollider = GetComponent<Collider2D>();
        objectRenderer = GetComponent<SpriteRenderer>();
        objectRb = GetComponent<Rigidbody2D>();

        // 初始状态下禁用Collider，隐藏物体，禁用重力
        objectCollider.enabled = false;
        objectRenderer.enabled = false;
        objectRb.bodyType = RigidbodyType2D.Kinematic;
    }

    void Update()
    {
        // 计算当前物体与Light组件之间的距离
        float distanceToLight = Vector2.Distance(transform.position, lightTransform.position);

        // 如果Light靠近特殊物体，则显示并启用Collider和重力
        if (distanceToLight < activationDistance)
        {
            objectCollider.enabled = true;
            objectRenderer.enabled = true;
            objectRb.bodyType = RigidbodyType2D.Dynamic;
        }
        // 如果Light远离特殊物体，则隐藏并禁用Collider和重力
        else
        {
            objectCollider.enabled = false;
            objectRenderer.enabled = false;
            objectRb.bodyType = RigidbodyType2D.Kinematic;
            objectRb.velocity = Vector2.zero;
            objectRb.angularVelocity = 0f;
        }
    }
}