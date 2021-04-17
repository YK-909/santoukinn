using UnityEngine;

public class RotateAround : MonoBehaviour
{
    //------------------------------------------------------------------------------------------------------------------
    void Update()
    {
        transform.RotateAround(Vector3.zero, Vector3.up, -20.0f * Time.deltaTime);
    }
}