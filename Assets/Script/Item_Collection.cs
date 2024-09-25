using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static AllControl;

public class Item_Collection : MonoBehaviour
{
    //在下一场景中获取计分板数据
    int kiwis = GameManager.Instance.score;

    [SerializeField] private Text kiwisText;
    [SerializeField] private AudioSource collectSoundEffect;

    [Header("音效")]
    [Tooltip("收集音效")] public AudioClip collectSound;

    private void Start()
    {
        collectSoundEffect = GetComponent<AudioSource>();
    }

    //如何累计计数

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
