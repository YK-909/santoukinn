using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineP2 : MonoBehaviour
{
    public GameObject FSI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = FSI.transform.position;
    }
}
