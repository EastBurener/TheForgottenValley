using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject myBag;
    bool isOpen;

    public float runSpeed;
    public float jumpSpeed;

    private Rigidbody2D myRigidbody;
    private BoxCollider2D myFeet;
    private Animator MyAnim;
    private bool isGround;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myFeet = GetComponent<BoxCollider2D>();
        MyAnim = GetComponent<Animator>();
    }

    void Update()
    {
        Flip();
        run();
        jump();
        CheckGrounded();
        OpenMyBag();

	}
    void Flip()
    {
        bool PlayerHasXSpeed = Mathf.Abs(myRigidbody.velocity.x) > 0.00001f;//�����˶��ж�

        if (PlayerHasXSpeed)
        {
            if (myRigidbody.velocity.x>0.1)
            {
                transform.localRotation = Quaternion.Euler(0,0,0);
            }
            if (myRigidbody.velocity.x < -0.1)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }
    void run()
    {
        float moveDir = Input.GetAxis("Horizontal");
        Vector2 playerVe1 = new Vector2(moveDir * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVe1;
        bool PlayerHasXSpeed = Mathf.Abs(myRigidbody.velocity.x)>Mathf.Epsilon;//����X�����˶��ж�(Mathf.Epsilon��С)
        MyAnim.SetBool("Run",PlayerHasXSpeed);

    }
    void jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (isGround)
            {
                MyAnim.SetBool("Jump",true);
                Vector2 jumpVe1 = new Vector2(0.0f, jumpSpeed);
                myRigidbody.velocity = Vector2.up * jumpVe1;
            }
        }

    }
    void CheckGrounded()//��������ܱ���Ҳ�����Ծ������ŵ�Ground��
    {
        isGround = myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"));
    }

    void OpenMyBag()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isOpen = !isOpen;
            myBag.SetActive(isOpen);
        }
    }
}
