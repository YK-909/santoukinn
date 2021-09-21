using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyAnim : MonoBehaviour
{
    private Animator Animator;

    private string isRinpun="isRinpun";

    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (KeyBordPlay1.RinpunAtk)
        {
            this.Animator.SetBool(isRinpun, true);
            KeyBordPlay1.RinpunAtk = false;
        }
        else
        {
            this.Animator.SetBool(isRinpun, false);
        }
    }
}
