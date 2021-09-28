using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_finish : MonoBehaviour
{
    public GameObject VolumeUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (VolumeUI.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                VolumeUI.SetActive(false);
            }
        }
    }
    public void Soundfinish()
    {
        VolumeUI.SetActive(false);
    }
}
