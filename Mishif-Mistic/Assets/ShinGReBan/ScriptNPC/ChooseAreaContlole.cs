using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseAreaContlole : MonoBehaviour
{
    public GameObject ChooseAreaP1;
    public GameObject ChooseAreaNPC;

    private float canvasScale;

    // Start is called before the first frame update
    void Start()
    {
        ChooseAreaNPC.gameObject.SetActive(false);

        CanvasScaler canvasScaler = GetComponentInParent<CanvasScaler>();

        // キャンバスのスケールを取得しておく
        canvasScale = canvasScaler != null ? canvasScaler.transform.localScale.x : 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(ChooseAreaP1.transform.position.x == 770 * canvasScale)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                ChooseAreaP1.gameObject.SetActive(false);
                ChooseAreaNPC.gameObject.SetActive(true);
            }
        }

        if(ChooseAreaNPC.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                ChooseAreaP1.gameObject.SetActive(true);
                ChooseAreaNPC.gameObject.SetActive(false);
            }
        }


    }
}
