using System.Collections;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            // �� Player ����ƽ̨ʱ���� Player ���ƽ̨������
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            // �� Player �뿪ƽ̨ʱ���ӳ�һ֡������ Player �ĸ�����Ϊ��
            StartCoroutine(DelayedUnparentPlayer(collision.gameObject));
        }
    }

    private IEnumerator DelayedUnparentPlayer(GameObject player)
    {
        yield return null; // �ӳ�һ֡
        player.transform.SetParent(null);
    }
}
