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
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap")//所有陷阱记得打上Trap这个标签
        {
            death();

        }
        //Player设为静态后不能拥有速度，Unity会报警告，不影响运行，勿动
    }
    private void death()
    {
        anim.SetTrigger("death");
        rb.bodyType = RigidbodyType2D.Static;
    }
    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        player.transform.position = RecordPosition.lastRecordedPosition;//移至存档点
    }
}
