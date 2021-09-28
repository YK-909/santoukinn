using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReEnter : MonoBehaviour
{
    public GameObject Kakunin;

    //AudioSource audioSource;
    private CriAtomSource atomSrc;

    // Start is called before the first frame update
    void Start()
    {
        //CriAtomSourceを取得
        atomSrc = (CriAtomSource)GetComponent("CriAtomSource");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        Kakunin.SetActive(true);
    }
}
