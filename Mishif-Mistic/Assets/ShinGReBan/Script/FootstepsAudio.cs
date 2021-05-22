using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsAudio : MonoBehaviour
{
    public AudioClip FootstepsSound;
    AudioSource FootstepsSource;

    // Start is called before the first frame update
    void Start()
    {
        //Componentを取得
        FootstepsSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //音鳴らす
            FootstepsSource.Play();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //音鳴らす
            FootstepsSource.Play();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //音鳴らす
            FootstepsSource.Play();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //音鳴らす
            FootstepsSource.Play();
        }
        else
        {
            FootstepsSource.Stop();
        }
    }
}
