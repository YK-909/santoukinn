using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabButton2 : MonoBehaviour
{
    public GameObject TypeInfo;
    public GameObject MyInfo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            TypeInfo.SetActive(false);
            MyInfo.SetActive(true);
        }
    }
}
