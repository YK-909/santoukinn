using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flog_Tartle_WolfP2 : MonoBehaviour
{
    //カエル　カメ　オオカミ
    //体力でゲームの勝敗を反映するために利用
    public float Player2HP;

    //移動速度
    private float Speed = 8.0f;
    //コントロールキーで速度低下
    private float Sprintspeed = 5.0f;

    //シールド　※カメとの変数に注意　調整中無視していいよ
    private bool Shield = false;
    public GameObject ShieldObj;
    [Range(0f, 1f)]
    public float ShieldPoint;

    //普通のジャンプ
    private bool NormalJump = false;

    //HPバーの生成
    public GameObject P2G;
    public GameObject P2R;
    //座標からHPが10ごと減少した際の値
    private float HP10per = 34.5f;

    //無敵時間の生成
    private bool Invincible = false;

    //飛ぶ方向のための調整
    public GameObject Player2;
    //ガードに攻撃してしまった際の反射
    public GameObject Player1Gard;

    //カエルの攻撃
    public GameObject P2FlogTongue;
    public Animator P2FlogAnimator;
    private bool FlogSwitch = true;

    //下の数値と同じでこの値を変化させて毒ダメージを表す
    private float Poisontimer = 5;
    //毒に係り続ける時間
    private float Poisoningtime = 5;


    //カメのカウンター
    public GameObject P2TurtleGard;
    private bool Gard = true;

    //オオカミの攻撃
    public GameObject P2WolfAtk;
    private bool WolfSwitch = true;
    public Material P2WolfNormal;
    public Material P2WolfColor;


    private Rigidbody Rb;
    private bool AllActionInterval = false;
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        P2TurtleGard.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        P2TurtleGard.transform.position = this.transform.position;
        //シールドの色変更　tの値で変わる　調整中無視していいよ
        ShieldObj.GetComponent<Renderer>().material.color = Color.HSVToRGB(ShieldPoint * 150, 1, 1);

        if (AllActionInterval == false)
        {
            if (Shield == false)
            {
                if (FlogSwitch == true)
                {
                    if (Input.GetKey(KeyCode.LeftControl))
                    {
                        Speed = Sprintspeed;
                    }
                    else
                    {
                        //歩きの速さの調整をする際はここも
                        Speed = 8.0f;
                    }

                    if (Input.GetKey(KeyCode.UpArrow))
                    {
                        //キャラクターが指定の向きを向く
                        transform.rotation = Quaternion.Euler(0, -90, 0);
                        //前方に移動する
                        transform.position += transform.forward * Speed * Time.deltaTime;
                    }
                    else if (Input.GetKey(KeyCode.DownArrow))
                    {
                        //キャラクターが指定の向きを向く
                        transform.rotation = Quaternion.Euler(0, 90, 0);
                        //前方に移動する
                        transform.position += transform.forward * Speed * Time.deltaTime;
                    }
                    else if (Input.GetKey(KeyCode.RightArrow))
                    {
                        //キャラクターが指定の向きを向く
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                        //前方に移動する
                        transform.position += transform.forward * Speed * Time.deltaTime;
                    }
                    else if (Input.GetKey(KeyCode.LeftArrow))
                    {
                        //キャラクターが指定の向きを向く
                        transform.rotation = Quaternion.Euler(0, 180, 0);
                        //前方に移動する
                        transform.position += transform.forward * Speed * Time.deltaTime;
                    }
                }

                if (NormalJump == false)
                {
                    // ボタンを押した1瞬だけアクション実行
                    if (Input.GetKeyDown(KeyCode.Z))
                    {
                        if (FlogSwitch == true)
                        {
                            P2FlogTongue.SetActive(true);
                            P2FlogAnimator.SetTrigger("FlogAtkStartP1");
                            P2FlogAnimator.SetBool("FlogAtkFinP1", false);
                            FlogSwitch = false;
                        }
                    }
                    if (Input.GetKeyUp(KeyCode.Z))
                    {
                        if (FlogSwitch == false)
                        {
                            P2FlogAnimator.SetBool("FlogAtkFinP1", true);
                            //オブジェクトが消える時間
                            Invoke("DelayFlog", 2.2f);
                            AllActionInterval = true;
                            //行動停止
                            Invoke("ActionInterval", 3.0f);
                        }
                    }

                    if (FlogSwitch == true)
                    {
                        if (Input.GetKeyUp(KeyCode.X))
                        {
                            if (Gard == true)
                            {
                                AllActionInterval = true;
                                P2TurtleGard.SetActive(true);
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
                        if (Input.GetKey(KeyCode.C))
                        {
                            if (WolfSwitch == true)
                            {
                                AllActionInterval = true;
                                P2WolfAtk.tag = "P2WolfAttack";
                                Rb.AddForce(transform.forward * 11f, ForceMode.Impulse);
                                P2WolfAtk.GetComponent<Renderer>().material.color = P2WolfColor.color;
                                WolfSwitch = false;
                                //当たり判定がある時間
                                Invoke("WolfAttackTime", 0.5f);
                                //行動停止
                                Invoke("ActionInterval", 0.8f);
                                //リキャストタイム
                                Invoke("DelayWolf", 1.2f);
                            }
                        }
                    }
                }
            }
        }

        //LRのシールド
        if (Input.GetKey(KeyCode.V))
        {
            if (NormalJump == false)
            {
                if (FlogSwitch == true)
                {
                    Shield = true;
                    ShieldObj.SetActive(true);
                    //シールド
                    if (ShieldPoint >= 0)
                    {
                        //シールドの減少量
                        ShieldPoint -= 0.001f;
                    }
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
        if (Input.GetKeyUp(KeyCode.V))
        {
            if (NormalJump == false)
            {
                if (FlogSwitch == true)
                {
                    ShieldObj.SetActive(false);
                    Invoke("ShieldDelay", 0.5f);
                }
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (Shield == false)
            {
                if (NormalJump == false)
                {
                    if (FlogSwitch == true)
                    {
                        Rb.AddForce(transform.up * 5, ForceMode.Impulse);
                        NormalJump = true;
                    }
                }
            }
        }

        //毒状態
        if (Poisontimer < Poisoningtime)
        {
            Poisontimer += Time.deltaTime;
            Player2HP -= Time.deltaTime;
            P2G.transform.position += new Vector3(HP10per * (0.01f * Time.deltaTime), 0, 0);
        }

        //HPの継続的な減少
        if (P2G.transform.position.x > P2R.transform.position.x)
        {
            P2R.transform.position += new Vector3(1f, 0, 0);
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

    void WolfAttackTime()
    {
        //攻撃判定がある状態、分かりやすく現在は色を変更
        P2WolfAtk.tag = "Player2";
        P2WolfAtk.GetComponent<Renderer>().material.color = P2WolfNormal.color;
    }

    void DelayWolf()
    {
        //オオカミ攻撃が連続で発生しないように
        WolfSwitch = true;
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

    void DelayFlog()
    {
        //カエル攻撃オブジェクトの除去
        P2FlogTongue.SetActive(false);
        FlogSwitch = true;
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
        }
    }
    //要修正
    void OnTriggerStay(Collider other)
    {
        if (Invincible == false)
        {
            if (Shield == true)
            {
                //シールド張っているとき
                if (other.gameObject.CompareTag("P1LionAttack"))
                {
                    ShieldPoint -= 0.2f;
                    //ダメを食らう時の半分ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player2);
                    Rb.AddForce(ToVec * 5, ForceMode.Impulse);
                    //無敵タイム開始 当たり判定が連続しないように
                    Invincible = true;
                    Invoke("InvincibleTime", 0.3f);
                }
                if (other.gameObject.CompareTag("P1Impla"))
                {
                    //ダメを食らう時の半分ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player2);
                    Rb.AddForce(ToVec * 7, ForceMode.Impulse);
                    ShieldPoint -= 0.3f;
                    //無敵タイム開始 当たり判定が連続しないように
                    Invincible = true;
                    Invoke("InvincibleTime", 0.3f);
                }

                if (other.gameObject.CompareTag("P1ImplaWave"))
                {
                    //ダメを食らう時の半分ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player2);
                    Rb.AddForce(ToVec * 5, ForceMode.Impulse);
                    ShieldPoint -= 0.1f;
                    //無敵タイム開始 当たり判定が連続しないように
                    Invincible = true;
                    Invoke("InvincibleTime", 0.3f);
                }

                //カエル、サソリ、オオカミ
                if (other.gameObject.CompareTag("P1FlogAttack"))
                {
                    //ダメを食らう時の半分ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player2);
                    Rb.AddForce(ToVec * 1, ForceMode.Impulse);
                    ShieldPoint -= 0.04f;
                    //無敵タイム開始 当たり判定が連続しないように
                    Invincible = true;
                    Invoke("InvincibleTime", 0.3f);
                }
                if (other.gameObject.CompareTag("P1ScorpionAttack"))
                {
                    //ダメを食らう時の半分ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player2);
                    Rb.AddForce(ToVec * 2, ForceMode.Impulse);
                    ShieldPoint -= 0.05f;
                    //無敵タイム開始 当たり判定が連続しないように
                    Invincible = true;
                    Invoke("InvincibleTime", 0.3f);
                }
                if (other.gameObject.CompareTag("P1ScorpionAttackBack"))
                {
                    //ダメを食らう時の半分ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player2);
                    Rb.AddForce(ToVec * 3, ForceMode.Impulse);
                    ShieldPoint -= 0.06f;
                    //無敵タイム開始 当たり判定が連続しないように
                    Invincible = true;
                    Invoke("InvincibleTime", 0.3f);
                }
                if (other.gameObject.CompareTag("P1WolfAttack"))
                {
                    //ダメを食らう時の半分ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player2);
                    Rb.AddForce(ToVec * 7, ForceMode.Impulse);
                    ShieldPoint -= 0.15f;
                    //無敵タイム開始 当たり判定が連続しないように
                    Invincible = true;
                    Invoke("InvincibleTime", 0.3f);
                }
            }
            else
            {
                //ダメージの当たり判定
                if (other.gameObject.CompareTag("P1LionAttack"))
                {
                    Player2HP -= 20;
                    P2G.transform.position += new Vector3(HP10per * 2, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player2);
                    Rb.AddForce(ToVec * 10, ForceMode.Impulse);
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

                if (other.gameObject.CompareTag("P1WolfAttack"))
                {
                    Player2HP -= 15;
                    P2G.transform.position += new Vector3(HP10per * 1.5f, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player2);
                    Rb.AddForce(ToVec * 10, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                }
                if (other.gameObject.CompareTag("P1FlogAttack"))
                {
                    Player2HP -= 4;
                    P2G.transform.position += new Vector3(HP10per * 0.4f, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player2);
                    Rb.AddForce(ToVec * 1, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 0.1f);
                }
                if (other.gameObject.CompareTag("P1ScorpionAttack"))
                {
                    Player2HP -= 5;
                    Poisontimer = 0;
                    P2G.transform.position += new Vector3(HP10per * 0.5f, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player2);
                    Rb.AddForce(ToVec * 5, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                }
                //カウンターダメージ用
                if (other.gameObject.CompareTag("P1FlogAttackBack"))
                {
                    Player2HP -= 4.8f;
                    P2G.transform.position += new Vector3(HP10per * 0.48f, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player2);
                    Rb.AddForce(ToVec * 2, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 0.1f);
                }
                //オオカミのカウンターのタグに切り替えが未実装
                if (other.gameObject.CompareTag("P2WolfAttackBack"))
                {
                    Player2HP -= 18;
                    P2G.transform.position += new Vector3(HP10per * 1.8f, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player2);
                    Rb.AddForce(ToVec * 15, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                }
                if (other.gameObject.CompareTag("P1ScorpionAttackBack"))
                {
                    Player2HP -= 6;
                    Poisontimer = 0;
                    P2G.transform.position += new Vector3(HP10per * 0.6f, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player2);
                    Rb.AddForce(ToVec * 6, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                }
            }
        }
    }
}