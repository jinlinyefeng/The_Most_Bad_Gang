using UnityEngine;

public class Spring : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D player_rb;

    public float bounceForce = 15f; // ������С

    private void Start()
    {
        player_rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // ��⵽��ɫ��ײ
        if (other.gameObject.CompareTag("Player"))
        {
            player_rb = other.GetComponent<Rigidbody2D>();
            if (player_rb != null)
            {
                // Ӧ�ô�ֱ��
                player_rb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
                animator.SetTrigger("hasSpring");
            }
        }
    }
}