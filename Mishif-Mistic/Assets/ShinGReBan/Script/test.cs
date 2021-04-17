using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public Transform Kime;
    bool the = true;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Contlole.GetHead() == 1 && ContloleBody.GetBody() == 1 && ContloleLeg.GetLeg() == 1)
        {
            if (the == true)
            {
                Instantiate(Kime, transform.position, transform.rotation);
                the = false;
            }
            Kime.gameObject.SetActive(true);
        }
        else
        {
            Kime.gameObject.SetActive(false);
        }
    }
}
