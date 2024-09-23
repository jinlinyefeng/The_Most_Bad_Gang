using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    [Tooltip("判断是否起跳")]
    public bool jumped;

    [SerializeField]
    [Tooltip("跳跃力大小")]
    public float jumpForce = 7f;
    [Tooltip("重力大小")]
    public float gravityForce = -2f;
    [Tooltip("移动速度")]
    public float moveSpeed = 7f;
    private float dirX = 0f;

    private Rigidbody2D rb; //玩家的刚体组件
    private SpriteRenderer sprite; //人物画布，用于反转画布
    private Animator animator; //当前动画变量

    // Start is called before the first frame update
    void Start()
    {
        //获取组件
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
    /// 跳跃
    /// </summary>
    public void Jump()
    {

        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("跳起来了");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    /// <summary>
    /// 移动
    /// </summary>
    public void Movement()
    {
        Debug.Log("开始移动了");
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        UpdateAnimationState();
    }

    /// <summary>
    /// 更新动画
    /// </summary>
    public void UpdateAnimationState()
    {
        Debug.Log(dirX);
        if (dirX > 0f)
        {
            animator.SetBool("running", true);
            sprite.flipX = false; //是否反转人物画布
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