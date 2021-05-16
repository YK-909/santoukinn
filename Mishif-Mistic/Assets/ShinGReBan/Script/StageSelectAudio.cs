using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectAudio : MonoBehaviour
{
    public AudioClip DecesionSound;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
