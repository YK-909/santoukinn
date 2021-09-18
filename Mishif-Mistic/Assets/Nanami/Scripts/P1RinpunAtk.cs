using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1RinpunAtk : MonoBehaviour
{
    public static bool isRinpunAtk;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.tag == "Player2")
        {
            isRinpunAtk = true;
        }
        else
        {
            isRinpunAtk = false;
        }
    }
}
