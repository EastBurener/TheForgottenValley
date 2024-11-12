using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public GameObject player;
    public float deathDelay = 1f; // ������������ʱ��
    private float deathTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        deathTimer = deathDelay; // ��ʼ��������ʱ��
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap") // ��������ǵô���Trap�����ǩ
        {
            death();
        }
    }

    private void death()
    {
        anim.SetTrigger("death");
        rb.bodyType = RigidbodyType2D.Static;
        deathTimer = 0f; // ����������ʱ��
    }

    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Death")) // ����Ƿ����ڲ�����������
        {
            deathTimer += Time.deltaTime;
            if (deathTimer >= deathDelay)
            {
                Restart();
            }
        }
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        player.transform.position = RecordPos.lastRecorded; // �����浵��
    }
}
