using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpionYUDOUp1 : MonoBehaviour
{
    private bool GardTouch = false;
    //Destroyのためのカウント
    private float Timecount = 0;
    private GameObject TargetObj;
    private Vector3 Target;
    private bool Once = true;
    // Start is called before the first frame update
    void Start()
    {
        TargetObj = GameObject.Find("P2camera");
    }

    // Update is called once per frame
    void Update()
    {
        if (Once == true)
        {
            float dist = Vector3.Distance(TargetObj.transform.position, transform.position);
            if (dist < 55)
            {
                Target = new Vector3(TargetObj.transform.position.x, this.transform.position.y, TargetObj.transform.position.z);
                transform.LookAt(Target);
            }
            else
            {
                Target = new Vector3(TargetObj.transform.position.x, TargetObj.transform.position.y, TargetObj.transform.position.z);
                transform.LookAt(Target);
            }

            Once = false;
        }
        Timecount += Time.deltaTime;
        if (GardTouch == false)
        {
            transform.position += transform.forward * 120f * Time.deltaTime;
        }
        else if (GardTouch == true)
        {
            transform.position -= transform.forward * 120f * Time.deltaTime;
        }

        if (Timecount > 2.0)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //ガード以外のタグのものとぶつかった際、速やかに削除
        if (collision.gameObject.tag != "Gard")
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
            this.tag = "PoisonAttackBack";
            //反転した時の射程範囲の調整
            Timecount = 0;
        }
        if (collision.gameObject.tag == "floor")
        {
            Destroy(this);
        }
    }
}