using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joyconTest : MonoBehaviour
{
    public int playerID = 1;
    private int speed=3;
    private Vector3 direction;
    private CharacterController cc;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        var h1 = Input.GetAxis("Horizontal 1");
        var v1 = Input.GetAxis("Vertical 1");
        direction.Set(Input.GetAxis("Horizontal " + playerID), 0, Input.GetAxis("Vertical " + playerID));
        if (direction != Vector3.zero) transform.rotation = Quaternion.LookRotation(direction);
        cc.SimpleMove(direction * speed);
    }
}