using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorpion : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject Block;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject Obj;
            Obj = Instantiate(Bullet, Block.transform.position , Block.transform.rotation) as GameObject;
        }
    }
}
