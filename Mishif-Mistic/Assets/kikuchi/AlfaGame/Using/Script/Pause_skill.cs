using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_skill : MonoBehaviour
{
    public GameObject SkillUI;
    public GameObject PauseUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SkillInfo()
    {
        SkillUI.SetActive(true);
        PauseUI.SetActive(false);
    }
}
