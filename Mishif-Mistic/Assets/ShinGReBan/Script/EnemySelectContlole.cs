using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class EnemySelectContlole : MonoBehaviour
{
    private GameObject Button;
    public GameObject Type1Button;
    public GameObject Type2Button;
    public GameObject Type3Button;
    public GameObject Type1Info;
    public GameObject Type2Info;
    public GameObject Type3Info;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Button = EventSystem.current.currentSelectedGameObject;

        if(Button == Type1Button)
        {
            Type1Info.SetActive(true);
            Type2Info.SetActive(false);
            Type3Info.SetActive(false);
        }

        if (Button == Type2Button)
        {
            Type1Info.SetActive(false);
            Type2Info.SetActive(true);
            Type3Info.SetActive(false);
        }

        if (Button == Type3Button)
        {
            Type1Info.SetActive(false);
            Type2Info.SetActive(false);
            Type3Info.SetActive(true);
        }
    }
}
