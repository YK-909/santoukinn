using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoykonMove : MonoBehaviour
{
    public int PlayerID = 1;
    private Vector3 Direction;
    private Rigidbody Rb;

    //体力
    public int Player2HP;
    //移動速度
    private float Speed = 3.0f;
    //加速用※今後の修正ポイント
    private float Sprintspeed = 10.0f;
    //HPバーの生成
    public GameObject P2G;
    public GameObject P2R;
    //座標からHPが10ごと減少した際の値 調整
    private float HP10per = 34.5f;
    //無敵時間の生成
    private bool Invincible = false;
    //飛ぶ方向のための調整
    public GameObject Player2;
    //ガードに攻撃してしまった際の反射
    public GameObject Player2Impla;
    public GameObject Player1Gard;

    //ライオンの攻撃
    public GameObject P2Lionhead;
    public Material P2LionNormal;
    public Material P2LionColor;
    private bool LionSwitch = true;

    //カメのカウンター
    public GameObject P2TurtleGard;
    private bool Gard = true;

    //インパラののジャンプ攻撃
    private bool Implajump = false;
    public GameObject P2ImplaBlock;
    public GameObject P2ImplaWaveBlock;

    private bool AllActionInterval = false;

    void Start()
    {
        P2TurtleGard.SetActive(false);
        Rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        P2TurtleGard.transform.position = this.transform.position;
        if (AllActionInterval == false)
        {
            Direction.Set(Input.GetAxis("Vertical " + PlayerID), 0, Input.GetAxis("Horizontal " + PlayerID));
            if (Direction != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(Direction);
                // 前方に移動する
                transform.position += transform.forward * Speed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.Joystick2Button2))
            {
                Rb.AddForce(transform.up * 3, ForceMode.Impulse);
            }

            if (Input.GetKey(KeyCode.Joystick2Button3))
            {
                if (LionSwitch == true)
                {
                    AllActionInterval = true;
                    P2Lionhead.tag = "P2LionAttack";
                    Rb.AddForce(transform.forward * 5f, ForceMode.Impulse);
                    P2Lionhead.GetComponent<Renderer>().material.color = P2LionColor.color;
                    LionSwitch = false;
                    Invoke("LionAttackSpan", 1.0f);
                    Invoke("ActionInterval", 0.5f);
                    Invoke("DelayLion", 1.0f);
                }
            }

            if (Input.GetKey(KeyCode.Joystick2Button1))
            {
                if (Gard == true)
                {
                    AllActionInterval = true;
                    P2TurtleGard.SetActive(true);
                    Gard = false;
                    Invoke("TurtleGardRemove", 3f);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 3f);
                    Invoke("ActionInterval", 0.5f);
                    Invoke("DelayTartle", 2f);
                }
            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button0))
            {
                if (Implajump == true)
                {
                    AllActionInterval = true;
                    Rb.AddForce(-transform.up * 15, ForceMode.Impulse);
                    P2ImplaBlock.SetActive(true);
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
        if (P2G.transform.position.x > P2R.transform.position.x)
        {
            P2R.transform.position += new Vector3(1f, 0, 0);
        }
        void LionAttackSpan()
        {
            //攻撃判定がある状態、分かりやすく現在は色を変更
            P2Lionhead.tag = "Player2";
            P2Lionhead.GetComponent<Renderer>().material.color = P2LionNormal.color;
        }
        void DelayLion()
        {
            //ライオン攻撃が連続で発生しないように
            LionSwitch = true;
        }
        void TurtleGardRemove()
        {
            //カウンターの球体の表示を消すため
            P2TurtleGard.SetActive(false);
        }
        void DelayTartle()
        {
            //カウンターが連続で発生しないため
            Gard = true;
        }
        void DelayImple()
        {
            //インパル攻撃による落下時の除去
            P2ImplaBlock.SetActive(false);
        }
        void DelayImpleWave()
        {
            //地面にぶつかった時の衝撃波の除去
            P2ImplaWaveBlock.SetActive(false);
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
                    P2ImplaWaveBlock.SetActive(true);
                    Invoke("DelayImpleWave", 0.1f);
                }
                Implajump = false;
            }
        }

        void OnTriggerStay(Collider other)
        {
            if (Invincible == false)
            {
                //ダメージの当たり判定
                if (other.gameObject.CompareTag("Blood"))
                {
                    Player2HP -= 5;
                    P2G.transform.position += new Vector3(HP10per / 2, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player2);
                    Rb.AddForce(ToVec * 6, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                }
                if (other.gameObject.CompareTag("PowerUpBlood"))
                {
                    Player2HP -= 6;
                    P2G.transform.position -= new Vector3(HP10per / 2 * 1.2f, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player2);
                    Rb.AddForce(ToVec * 8, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                }

                if (other.gameObject.CompareTag("P1Impla"))
                {
                    Player2HP -= 30;
                    P2G.transform.position += new Vector3(HP10per * 3, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player2);
                    Rb.AddForce(ToVec * 15, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                }
                if (other.gameObject.CompareTag("P1ImplaWave"))
                {
                    Player2HP -= 10;
                    P2G.transform.position += new Vector3(HP10per, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player2);
                    Rb.AddForce(ToVec * 10, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                }

                //カウンターダメージ用
                if (other.gameObject.CompareTag("P2ImplaBack"))
                {
                    Player2HP -= 36;
                    P2G.transform.position += new Vector3(HP10per * 3 * 1.2f, 0, 0);
                    Vector3 ToVec = GetAngleVec(Player1Gard, Player2Impla);
                    //調整用
                    //ToVec = ToVec + new Vector3(0, 2f, 0);
                    //強めにしないと形状によっては突起に引っかかることも
                    Rb.AddForce(ToVec * 20, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                }
                if (other.gameObject.CompareTag("P2ImplaWaveBack"))
                {
                    Player2HP -= 12;
                    P2G.transform.position += new Vector3(HP10per * 1.2f, 0, 0);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                }
            }
        }
    }
}
