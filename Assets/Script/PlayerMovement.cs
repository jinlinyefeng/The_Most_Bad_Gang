using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�ж��Ƿ�����")]
    public bool jumped;

    [SerializeField]
    [Tooltip("��Ծ����С")]
    public float jumpForce = 7f;
    [Tooltip("������С")]
    public float gravityForce = -2f;
    [Tooltip("�ƶ��ٶ�")]
    public float moveSpeed = 7f;
    private float dirX = 0f;

    private Rigidbody2D rb; //��ҵĸ������
    private SpriteRenderer sprite; //���ﻭ�������ڷ�ת����
    private Animator animator; //��ǰ��������

    // Start is called before the first frame update
    void Start()
    {
        //��ȡ���
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
    }

    /// <summary>
    /// ��Ծ
    /// </summary>
    public void Jump()
    {

        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("��������");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    /// <summary>
    /// �ƶ�
    /// </summary>
    public void Movement()
    {
        Debug.Log("��ʼ�ƶ���");
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        UpdateAnimationState();
    }

    /// <summary>
    /// ���¶���
    /// </summary>
    public void UpdateAnimationState()
    {
        Debug.Log(dirX);
        if (dirX > 0f)
        {
            animator.SetBool("running", true);
            sprite.flipX = false; //�Ƿ�ת���ﻭ��
        }
        else if (dirX < 0f)
        {
            animator.SetBool("running", true);
            sprite.flipX = true;
        }
        else
        {
            animator.SetBool("running", false);
        }
    }

}