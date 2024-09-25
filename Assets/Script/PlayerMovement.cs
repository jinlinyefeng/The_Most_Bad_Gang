using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private LayerMask jumpableGround;

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
    private BoxCollider2D coll;

    [Header("��Ч")]
    [Tooltip("��Ծ��Ч")] public AudioClip jumpSound;

    private enum MovementState { idle, running, jumping, falling }

    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        //��ȡ���
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>(); 
        coll = GetComponent<BoxCollider2D>();
        jumpSoundEffect = GetComponent<AudioSource>();
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

        if (Input.GetKeyDown(KeyCode.W) && IsGrounded())
        {
            Debug.Log("��������");
            jumpSoundEffect.clip = jumpSound;
            jumpSoundEffect.Play();
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
        MovementState state;
        Debug.Log(dirX);
        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false; //�Ƿ�ת���ﻭ��
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f) 
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        animator.SetInteger("state", (int)state);
    }

    /// <summary>
    /// �ж��Ƿ��ŵ�
    /// </summary>
    /// <returns></returns>
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

}