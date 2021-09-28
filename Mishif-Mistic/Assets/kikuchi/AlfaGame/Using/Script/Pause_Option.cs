using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Option : MonoBehaviour
{
    public GameObject VolumeUI;
    public GameObject PauseUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SoundCont()
    {
        VolumeUI.SetActive(true);
        PauseUI.SetActive(false);
    }
}
