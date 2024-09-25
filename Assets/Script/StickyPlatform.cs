using System.Collections;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            // 当 Player 触碰平台时，让 Player 变成平台的子类
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            // 当 Player 离开平台时，延迟一帧后设置 Player 的父物体为空
            StartCoroutine(DelayedUnparentPlayer(collision.gameObject));
        }
    }

    private IEnumerator DelayedUnparentPlayer(GameObject player)
    {
        yield return null; // 延迟一帧
        player.transform.SetParent(null);
    }
}
