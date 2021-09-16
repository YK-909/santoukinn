using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2inpunAtk : MonoBehaviour
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
        if (other.gameObject.CompareTag("Player1"))
        {
            isRinpunAtk = true;
            Debug.Log(isRinpunAtk);
            Destroy(gameObject, 2f);
        }
        else
        {
            isRinpunAtk = false;
        }
        
    }
}
