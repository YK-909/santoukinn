using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joyconVerPlayermove1 : MonoBehaviour
{
    //体力
    public float Player1HP;

    //移動速度
    private float Speed = 8.0f;
    //走る時の速さは未実装
    private float Sprintspeed = 5.0f;
    private Vector3 Direction;

    //シールド　※カメとの変数に注意　調整中無視していいよ
    private bool Shield = false;
    public GameObject ShieldObj;
    [Range(0f, 1f)]
    public float ShieldPoint;

    //普通のジャンプ
    private bool NormalJump = false;

    //HPバーの生成
    public GameObject P1G;
    public GameObject P1R;
    //座標からHPが10ごと減少した際の値
    private float HP10per = 34.5f;

    //無敵時間の生成
    private bool Invincible = false;

    //飛ぶ方向のための調整
    public GameObject Player1;
    //ガードに攻撃してしまった際の反射
    public GameObject Player2Gard;

    //ライオンの攻撃
    public GameObject P1Lionhead;
    public Material P1LionNormal;
    public Material P1LionColor;
    private bool LionSwitch = true;

    //カメのカウンター
    public GameObject P1TurtleGard;
    private bool Gard = true;

    //インパラののジャンプ攻撃
    private bool Implajump = false;
    private Rigidbody Rb;
    public GameObject P1ImplaBlock;
    public GameObject P1ImplaWaveBlock;

    private bool AllActionInterval = false;
    //透過させるために
    private Collider P1collider;
    void Start()
    {
        P1TurtleGard.SetActive(false);
        Rb = GetComponent<Rigidbody>();
        P1collider = GetComponent<Collider>();
        P1collider.isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        P1TurtleGard.transform.position = this.transform.position;
        //シールドの色変更　tの値で変わる　調整中無視していいよ
        ShieldObj.GetComponent<Renderer>().material.color = Color.HSVToRGB(ShieldPoint * 150, 1, 1);

        if (AllActionInterval == false)
        {
            if (Shield == false)
            {
                if (Implajump == false)
                {
                    if (Input.GetKey(KeyCode.Joystick1Button14))
                    {
                        Speed = Sprintspeed;
                    }
                    else
                    {
                        //歩きの速さの調整をする際はここも
                        Speed = 8.0f;
                    }

                    Direction.Set(Input.GetAxis("Vertical 1"), 0, Input.GetAxis("Horizontal 1"));
                    if (Direction != Vector3.zero)
                    {
                        //向きを指定
                        transform.rotation = Quaternion.LookRotation(Direction);
                    }
                    //前方に移動する
                    transform.position += Direction * Speed * Time.deltaTime;
                    if (NormalJump == false)
                    {
                        // ボタンを押した1瞬だけアクション実行
                        if (Input.GetKey(KeyCode.Joystick1Button3))
                        {
                            if (LionSwitch == true)
                            {
                                AllActionInterval = true;
                                P1Lionhead.tag = "P1LionAttack";
                                Rb.AddForce(transform.forward * 10f, ForceMode.Impulse);
                                P1Lionhead.GetComponent<Renderer>().material.color = P1LionColor.color;
                                LionSwitch = false;
                                //当たり判定がある時間
                                Invoke("LionAttackTime", 0.5f);
                                //行動停止
                                Invoke("ActionInterval", 0.8f);
                                //リキャストタイム
                                Invoke("DelayLion", 1.2f);
                            }
                        }

                        if (Input.GetKeyUp(KeyCode.Joystick1Button1))
                        {
                            if (Gard == true)
                            {
                                AllActionInterval = true;
                                P1TurtleGard.SetActive(true);
                                Gard = false;
                                //無敵タイム開始
                                Invincible = true;
                                //無敵時間
                                Invoke("InvincibleTime", 2f);
                                //上と同じ値
                                Invoke("TurtleGardRemove", 2f);
                                //行動停止
                                Invoke("ActionInterval", 3.0f);
                                //リキャストタイム
                                Invoke("DelayTartle", 6f);
                            }
                        }
                    }
                }

                if (Input.GetKeyDown(KeyCode.Joystick1Button0))
                {
                    if (Implajump == true)
                    {
                        Rb.constraints = RigidbodyConstraints.FreezePosition;
                        P1collider.isTrigger = true;
                        AllActionInterval = true;
                        Invoke("ImpleFreeze", 0.2f);
                    }
                    else if (Implajump == false)
                    {
                        Rb.AddForce(transform.up * 15, ForceMode.Impulse);
                        Implajump = true;
                    }
                }

                if (Implajump == true)
                {
                    transform.position += transform.forward * 5 * Time.deltaTime;
                }
            }

            //LRのシールド
            if (Input.GetKey(KeyCode.Joystick2Button15)|| Input.GetKey(KeyCode.Joystick1Button15))
            {
                if (NormalJump == false)
                {
                    if (Shield == false)
                    {
                        Shield = true;
                        ShieldObj.SetActive(true);
                    }
                    //シールド
                    if (ShieldPoint >= 0)
                    {
                        //シールドの減少量
                        ShieldPoint -= 0.001f;
                    }
                }
            }
            else
            {
                ShieldObj.SetActive(false);
                //シールド
                if (ShieldPoint <= 1)
                {
                    //シールドの回復速度
                    ShieldPoint += 0.001f;
                }
            }
            //ガードのボタンを離したとき　後隙
            if (Input.GetKeyUp(KeyCode.Joystick2Button15) || Input.GetKeyUp(KeyCode.Joystick1Button15))
            {
                if (NormalJump == false)
                {
                    ShieldObj.SetActive(false);
                    Invoke("ShieldDelay", 1.5f);
                }
            }
            if (Input.GetKey(KeyCode.Joystick1Button2))
            {
                if (Shield == false)
                {
                    if (NormalJump == false)
                    {
                        Rb.AddForce(transform.up * 5, ForceMode.Impulse);
                        NormalJump = true;
                    }
                }
            }
        }

        //HPの継続的な減少
        if (P1G.transform.position.x < P1R.transform.position.x)
        {
            P1R.transform.position -= new Vector3(1f, 0, 0);
        }

        //シールドブレイク
        if (ShieldPoint <= 0)
        {
            ShieldObj.SetActive(false);
            AllActionInterval = true;
            //何もできない待機時間
            Invoke("ActionInterval", 5f);
            //上と同じ値で　シールドが壊れた時の対応
            Invoke("ShieldBreak", 5f);
        }

        if (this.transform.position.y <= 0 && P1collider.isTrigger == true)
        {
            //透過下ブロックが落ちないように
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            P1collider.isTrigger = false;
        }
    }

    void ShieldBreak()
    {
        //シールド全回複
        ShieldPoint = 1;
    }
    void ShieldDelay()
    {
        Shield = false;
    }
    void LionAttackTime()
    {
        //攻撃判定がある状態、分かりやすく現在は色を変更
        P1Lionhead.tag = "Player";
        P1Lionhead.GetComponent<Renderer>().material.color = P1LionNormal.color;
    }
    void DelayLion()
    {
        //ライオン攻撃が連続で発生しないように
        LionSwitch = true;
    }
    void TurtleGardRemove()
    {
        //カウンターの球体の表示を消すため
        P1TurtleGard.SetActive(false);
    }
    void DelayTartle()
    {
        //カウンターが連続で発生しないため
        Gard = true;
    }
    void DelayImple() 
    {
        //オブジェクト非表示
        P1ImplaBlock.SetActive(false);
    }
    void DelayImpleWave()
    {
        //地面にぶつかった時の衝撃波の除去
        P1ImplaWaveBlock.SetActive(false);
    }
    void ImpleFreeze()
    {
        //空中で一時停止
        Rb.constraints = RigidbodyConstraints.None;
        Rb.AddForce(-transform.up * 30, ForceMode.Impulse);
        P1ImplaBlock.SetActive(true);

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

        if (other.gameObject.tag == "floor")
        {
            //ただのジャンプ
            NormalJump = false;
            Implajump = false;
            //インパラの攻撃のため
            if (AllActionInterval == true)
            {
                //P2のインパラブロックが表示されているとき
                if (P1ImplaBlock.activeSelf == true)
                {
                    P1ImplaWaveBlock.SetActive(true);
                    Invoke("DelayImple", 0.05f);
                    Invoke("DelayImpleWave", 0.1f);
                }
                //行動停止
                Invoke("ActionInterval", 0.5f);
            }
            P1collider.isTrigger = false;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (Invincible == false)
        {
            if (Shield == true)
            {
                //シールドを張っているとき
                if (other.gameObject.CompareTag("P2LionAttack"))
                {
                    ShieldPoint -= 0.2f;
                    //ダメを食らう時の半分ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player1);
                    Rb.AddForce(ToVec * 5, ForceMode.Impulse);
                    //無敵タイム開始 当たり判定が連続しないように
                    Invincible = true;
                    Invoke("InvincibleTime", 0.3f);
                }
                if (other.gameObject.CompareTag("Blood"))
                {
                    ShieldPoint -= 0.05f;
                    //ダメを食らう時の半分ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player1);
                    Rb.AddForce(ToVec * 3, ForceMode.Impulse);
                    //無敵タイム開始 当たり判定が連続しないように
                    Invincible = true;
                    Invoke("InvincibleTime", 0.3f);
                }

                if (other.gameObject.CompareTag("PowerUpBlood"))
                {
                    //ダメを食らう時の半分ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player1);
                    Rb.AddForce(ToVec * 4, ForceMode.Impulse);
                    ShieldPoint -= 0.06f;
                    //無敵タイム開始 当たり判定が連続しないように
                    Invincible = true;
                    Invoke("InvincibleTime", 0.3f);
                }

                if (other.gameObject.CompareTag("P1Impla"))
                {
                    //ダメを食らう時の半分ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player1);
                    Rb.AddForce(ToVec * 7, ForceMode.Impulse);
                    ShieldPoint -= 0.3f;
                    //無敵タイム開始 当たり判定が連続しないように
                    Invincible = true;
                    Invoke("InvincibleTime", 0.3f);
                }

                if (other.gameObject.CompareTag("P1ImplaWave"))
                {
                    //ダメを食らう時の半分ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player1);
                    Rb.AddForce(ToVec * 5, ForceMode.Impulse);
                    ShieldPoint -= 0.1f;
                    //無敵タイム開始 当たり判定が連続しないように
                    Invincible = true;
                    Invoke("InvincibleTime", 0.3f);
                }

            }
            else
            {
                //ダメージの当たり判定
                if (other.gameObject.CompareTag("P2LionAttack"))
                {
                    Player1HP -= 20;
                    P1G.transform.position -= new Vector3(HP10per * 2, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player1);
                    Rb.AddForce(ToVec * 10, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                }
                if (other.gameObject.CompareTag("Blood"))
                {
                    Player1HP -= 5;
                    P1G.transform.position -= new Vector3(HP10per / 2, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player1);
                    Rb.AddForce(ToVec * 6, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                }

                if (other.gameObject.CompareTag("P2Impla"))
                {
                    Player1HP -= 30;
                    P1G.transform.position -= new Vector3(HP10per * 3, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player1);
                    Debug.Log(ToVec);
                    Rb.AddForce(ToVec * 15, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                }
                if (other.gameObject.CompareTag("P2ImplaWave"))
                {
                    Player1HP -= 10;
                    P1G.transform.position -= new Vector3(HP10per, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player1);
                    Rb.AddForce(ToVec * 10, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                }

                //カウンターダメージ用
                if (other.gameObject.CompareTag("P1LionAttackBack"))
                {
                    Player1HP -= 24;
                    P1G.transform.position -= new Vector3(HP10per * 2 * 1.2f, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(Player2Gard, Player1);
                    Rb.AddForce(ToVec * 15, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                }

                if (other.gameObject.CompareTag("PowerUpBlood"))
                {
                    Player1HP -= 6;
                    P1G.transform.position -= new Vector3(HP10per / 2 * 1.2f, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player1);
                    Rb.AddForce(ToVec * 8, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                }

                if (other.gameObject.CompareTag("P1ImplaBack"))
                {
                    Player1HP -= 36;
                    P1G.transform.position -= new Vector3(HP10per * 3 * 1.2f, 0, 0);
                    Vector3 ToVec = GetAngleVec(Player2Gard, P1ImplaBlock);

                    Rb.AddForce(ToVec * 20, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                }
                if (other.gameObject.CompareTag("P1ImplaWaveBack"))
                {
                    Player1HP -= 12;
                    P1G.transform.position -= new Vector3(HP10per * 1.2f, 0, 0);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                }
            }
        }
    }
}