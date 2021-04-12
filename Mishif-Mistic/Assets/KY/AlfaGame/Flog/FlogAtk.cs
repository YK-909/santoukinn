using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlogAtk : MonoBehaviour
{
    Animator animator;

    // スタート時に呼ばれる
    void Start()
    {
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            animator.SetTrigger("FlogAtkStartP1");
            animator.SetBool("FlogAtkFinP1", false);
        }
        if(Input.GetKeyUp("a"))
        {
            animator.SetBool("FlogAtkFinP1",true);
        }
    }
}
