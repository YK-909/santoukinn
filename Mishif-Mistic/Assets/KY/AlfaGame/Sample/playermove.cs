using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class playermove : MonoBehaviour
{
    //体力
    public int PlayerHP;
    //移動速度
    private float Speed = 3.0f;
    private float Sprintspeed = 10.0f;
    //HPバーの生成
    public GameObject P1G;
    public GameObject P1R;
    //座標からHPが10ごと減少した際の値
    private float HP10per = 31.2f;
    //無敵時間の生成
    private bool Invincible=false;
    //飛ぶ方向のための調整
    public GameObject Player1;
    //ガードに攻撃してしまった際の反射
    public GameObject Player1Impla;
    public GameObject Player2Gard;

    //トカゲの攻撃
    public GameObject Bullet;

    //カメのカウンター
    public GameObject TurtleGard;
    private bool Gard = false;

    //インパラののジャンプ攻撃
    private bool Implajump = false;
    private Rigidbody Rb;
    public GameObject ImplaBlock;
    public GameObject ImplaWaveBlock;

    private bool AllActionInterval = false;
    void Start()
    {
        TurtleGard.SetActive(false);
        Rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        TurtleGard.transform.position = this.transform.position;
        if (AllActionInterval == false)
        {
            if (Input.GetKey("left shift"))
            {
                Speed = Sprintspeed;
            }
            else
            {
                //歩きの速さの調整をする際はここも
                Speed = 2.0f;
            }

            if (Input.GetKey(KeyCode.W))
            {
                //キャラクターが指定の向きを向く
                transform.rotation = Quaternion.Euler(0, -90, 0);
                //前方に移動する
                transform.position += transform.forward * Speed * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                //キャラクターが指定の向きを向く
                transform.rotation = Quaternion.Euler(0, 90, 0);
                //前方に移動する
                transform.position += transform.forward * Speed * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                //キャラクターが指定の向きを向く
                transform.rotation = Quaternion.Euler(0, 180, 0);
                //前方に移動する
                transform.position += transform.forward * Speed * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                //キャラクターが指定の向きを向く
                transform.rotation = Quaternion.Euler(0, 0, 0);
                //前方に移動する
                transform.position += transform.forward * Speed * Time.deltaTime;
            }

            // ボタンを押した1瞬だけアクション実行
            if (Input.GetKey(KeyCode.J))
            {
                AllActionInterval = true;
                GameObject Obj;
                GameObject Obj2;
                Obj = Instantiate(Bullet, transform.position - transform.right * 1f, this.transform.rotation) as GameObject;
                Obj2 = Instantiate(Bullet, transform.position + transform.right * 1f, this.transform.rotation) as GameObject;
                Invoke("ActionInterval", 2.0f);
            }

            if (Input.GetKeyUp(KeyCode.K))
            {
                if (Gard == false)
                {
                    AllActionInterval = true;
                    TurtleGard.SetActive(true);
                    Gard = true;
                    Invoke("TurtleGardRemove", 3f);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 3f);
                    Invoke("ActionInterval", 1.5f);
                    Invoke("DelayTartle", 2f);
                }
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                if (Implajump == true)
                {
                    AllActionInterval = true;
                    Rb.AddForce(-transform.up * 15, ForceMode.Impulse);
                    ImplaBlock.SetActive(true);
                    Invoke("ActionInterval", 0.5f);
                }
                else if (Implajump == false)
                {
                    Rb.AddForce(transform.up * 10, ForceMode.Impulse);
                    Implajump = true;
                }
            }
            else if (Implajump == true)
            {
                transform.position += transform.forward * 10 * Time.deltaTime;
            }

            if (Implajump == false)
            {
                Invoke("DelayImple", 0.3f);
            }
        }

        //HPの継続的な減少
        if (P1G.transform.position.x < P1R.transform.position.x)
        {
            P1R.transform.position -= new Vector3(1f, 0, 0);
        }
    }

    void TurtleGardRemove()
    {
        //カウンターの球体の表示を消すため
        TurtleGard.SetActive(false);
    }
    void DelayTartle()
    {
        //カウンターが連続で発生しないため
        Gard = false;
    }
    void DelayImple()
    {
        //インパル攻撃による落下時の除去
        ImplaBlock.SetActive(false);
    }
    void DelayImpleWave()
    {
        //地面にぶつかった時の衝撃波の除去
        ImplaWaveBlock.SetActive(false);
    }
    void ActionInterval()
    {
        //全操作の一時停止
        AllActionInterval = false;
    }
    void InvincibleTime()
    {
        //無敵タイムの終了
        Invincible = false;
    }
    Vector3 GetAngleVec(GameObject _from, GameObject _to)
    {
        //高さの概念を入れないベクトルを作る
        Vector3 fromVec = new Vector3(_from.transform.position.x, 0, _from.transform.position.z);
        Vector3 toVec = new Vector3(_to.transform.position.x, 0, _to.transform.position.z);

        return Vector3.Normalize(toVec - fromVec);
    }

    void OnCollisionEnter(Collision other)
    {
        //インパラの攻撃のため
        if (other.gameObject.tag == "floor")
        {
            if (AllActionInterval == true)
            {
                if (Implajump == true)
                {
                    ImplaWaveBlock.SetActive(true);
                    Invoke("DelayImpleWave", 0.1f);
                }
            }
            Implajump = false;
        } 
    }

    void OnTriggerStay(Collider other)
    {
　　　　//新しく作り直す

        if (Invincible == false)
        {
            //ダメージの当たり判定
            if (other.gameObject.CompareTag("P2LionAttack"))
            {
                PlayerHP -= 20;
                P1G.transform.position -= new Vector3(HP10per * 2, 0, 0);
                //ノックバック
                Vector3 ToVec = GetAngleVec(other.gameObject, Player1);
                Rb.AddForce(ToVec * 10, ForceMode.Impulse);
                //無敵タイム開始
                Invincible = true;
                Invoke("InvincibleTime", 1.5f);
            }

            //カウンターで食らった用
            if (other.gameObject.CompareTag("Blood"))
            {
                PlayerHP -= 5;
                P1G.transform.position -= new Vector3(HP10per / 2, 0, 0);
                //ノックバック
                Vector3 ToVec = GetAngleVec(other.gameObject, Player1);
                Rb.AddForce(ToVec * 6, ForceMode.Impulse);
                //無敵タイム開始
                Invincible = true;
                Invoke("InvincibleTime", 1.5f);
            }
            if (other.gameObject.CompareTag("PowerUpBlood"))
            {
                PlayerHP -= 6;
                P1G.transform.position -= new Vector3(HP10per / 2 * 1.2f, 0, 0);
                //ノックバック
                Vector3 ToVec = GetAngleVec(other.gameObject, Player1);
                Rb.AddForce(ToVec * 8, ForceMode.Impulse);
                //無敵タイム開始
                Invincible = true;
                Invoke("InvincibleTime", 1.5f);
            }
            if (other.gameObject.CompareTag("P2Impla"))
            {
                PlayerHP -= 30;
                P1G.transform.position -= new Vector3(HP10per * 3, 0, 0);
                //ノックバック
                Vector3 ToVec = GetAngleVec(other.gameObject, Player1);
                Rb.AddForce(ToVec * 15, ForceMode.Impulse);
                //無敵タイム開始
                Invincible = true;
                Invoke("InvincibleTime", 1.5f);
            }
            if (other.gameObject.CompareTag("P2ImplaWave"))
            {
                PlayerHP -= 10;
                P1G.transform.position -= new Vector3(HP10per, 0, 0);
                //ノックバック
                Vector3 ToVec = GetAngleVec(other.gameObject, Player1);
                Rb.AddForce(ToVec * 10, ForceMode.Impulse);
                //無敵タイム開始
                Invincible = true;
                Invoke("InvincibleTime", 1.5f);
            }

            //カウンターダメージ用
            if (other.gameObject.CompareTag("P1ImplaBack"))
            {
                PlayerHP -= 36;
                P1G.transform.position -= new Vector3(HP10per * 3 * 1.2f, 0, 0);
                Vector3 ToVec = GetAngleVec(Player2Gard, Player1Impla);
                //調整用
                //ToVec = ToVec + new Vector3(0, 2f, 0);
                //強めにしないと形状によっては突起に引っかかることも
                Rb.AddForce(ToVec * 20, ForceMode.Impulse);
                //無敵タイム開始
                Invincible = true;
                Invoke("InvincibleTime", 1.5f);
            }
            if (other.gameObject.CompareTag("P1ImplaWaveBack"))
            {
                PlayerHP -= 12;
                P1G.transform.position -= new Vector3(HP10per * 1.2f, 0, 0);
                //無敵タイム開始
                Invincible = true;
                Invoke("InvincibleTime", 1.5f);
            }
        }
    }
}
