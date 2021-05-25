using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1ChooseArea : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var h1 = Input.GetAxis("Horizontal1");
        var v1 = Input.GetAxis("Vertical1");

        var h2 = Input.GetAxis("Horizontal2");
        var v2 = Input.GetAxis("Vertical2");
    }

    // Update is called once per frame
    void Update()
    {
        //左傾き
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Translate(-160, 0, 0);
        }
        //右傾き
        else if (0 < Input.GetAxisRaw("Horizontal"))
        {
            transform.Translate(160, 0, 0);
        }
    }
}
