using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxRotation : MonoBehaviour
{
    //回転のスピード
    [Range(0.01f, 0.1f)]
    public float rotateSpeed;
    public Material sky;
    float rotationRepeatValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotationRepeatValue = Mathf.Repeat(sky.GetFloat("_Rotation") + rotateSpeed, 360f);

        sky.SetFloat("_Rotation", rotationRepeatValue);

        if(Input.anyKey == false)
        {
            return;
        }
    }
}
