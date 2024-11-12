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
    public float deathDelay = 1f; // 死亡动画播放时间
    private float deathTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        deathTimer = deathDelay; // 初始化死亡计时器
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap") // 所有陷阱记得打上Trap这个标签
        {
            death();
        }
    }

    private void death()
    {
        anim.SetTrigger("death");
        rb.bodyType = RigidbodyType2D.Static;
        deathTimer = 0f; // 重置死亡计时器
    }

    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Death")) // 检查是否正在播放死亡动画
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
        player.transform.position = RecordPos.lastRecorded; // 移至存档点
    }
}
