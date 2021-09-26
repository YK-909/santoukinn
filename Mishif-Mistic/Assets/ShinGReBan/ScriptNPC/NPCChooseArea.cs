using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCChooseArea : MonoBehaviour
{
    public CriAtomSource KeyboardSlotLRSrc;

    private float minX = 342;
    private float maxX = 829;

    private float canvasScale;

    // Start is called before the first frame update
    void Start()
    {
        CanvasScaler canvasScaler = GetComponentInParent<CanvasScaler>();

        // キャンバスのスケールを取得しておく
        canvasScale = canvasScaler != null ? canvasScaler.transform.localScale.x : 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Translateの移動量やminX、maxXにcanvasScaleをかけることで
        // キャンバス空間とワールド空間のスケールの違いを吸収する

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(-170 * canvasScale, 0, 0);

            //音鳴らす
            KeyboardSlotLRSrc.Play();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(170 * canvasScale, 0, 0);

            //音鳴らす
            KeyboardSlotLRSrc.Play();
        }

        if (transform.position.x < minX * canvasScale)
        {
            Vector3 temp = transform.position;
            temp.x = minX * canvasScale;
            transform.position = temp;
        }
        if (transform.position.x > maxX * canvasScale)
        {
            Vector3 temp = transform.position;
            temp.x = maxX * canvasScale;
            transform.position = temp;
        }
    }
}
