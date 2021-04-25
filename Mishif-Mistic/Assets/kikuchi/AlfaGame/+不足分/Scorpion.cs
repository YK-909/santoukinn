using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorpion : MonoBehaviour
{
    private bool GardTouch = false;
    //Destroyのためのカウント
    private float Timecount = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Timecount += Time.deltaTime;
        if (GardTouch == false)
        {
            transform.position += transform.forward * 10f * Time.deltaTime;
        }
        else if (GardTouch == true)
        {
            transform.position -= transform.forward * 10f * Time.deltaTime;
        }

        if (Timecount > 2.0)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //ガード以外のタグのものとぶつかった際、速やかに削除
        if (collision.gameObject.tag != "Gard" && collision.gameObject.tag != "ScorpionMuzzle")
        {
            Destroy(this, 0.01f);
        }
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Gard")
        {
            //進む方向を変化させるため＋当たり判定のタグを変更
            GardTouch = true;
            this.tag = "P1ScorpionAttackBack";
            //反転した時の射程範囲の調整
            Timecount = 0;
        }
    }
}