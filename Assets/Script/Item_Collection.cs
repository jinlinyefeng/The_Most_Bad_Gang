using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static AllControl;

public class Item_Collection : MonoBehaviour
{
    //����һ�����л�ȡ�Ʒְ�����
    int kiwis = GameManager.Instance.score;

    [SerializeField] private Text kiwisText;
    [SerializeField] private AudioSource collectSoundEffect;

    [Header("��Ч")]
    [Tooltip("�ռ���Ч")] public AudioClip collectSound;

    private void Start()
    {
        collectSoundEffect = GetComponent<AudioSource>();
    }

    //����ۼƼ���

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.gameObject.CompareTag("Kiwi"))
        {
            collectSoundEffect.clip = collectSound;
            collectSoundEffect.Play();
            Destroy( collision.gameObject );
            kiwis++;
            kiwisText.text = "Kiwis:" + kiwis;
        }
    }
}
