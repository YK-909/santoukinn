using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAudio : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip TitleDecision;

    // Start is called before the first frame update
    void Start()
    {
        //audioComponent取得
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //音鳴らす
            audioSource.PlayOneShot(TitleDecision);
        }
    }
}
