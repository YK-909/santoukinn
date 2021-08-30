using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotCinemaPlayer : MonoBehaviour
{
    public GameObject FSW;
    private Vector3 PlayerObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FSW.activeSelf)
        {
            PlayerObject = FSW.transform.position;
        }
        this.transform.position = PlayerObject;
    }
}
