using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyconPlay1 : MonoBehaviour
{
    //体力
    public static float Player1HP=100;
    //スタートの合図のため
    private int Gamemode = 0;

    //キャラ変更
    //1=ライオン 2=カエル
    public int Head = 0;
    //1=カメ 1=サソリ
    public int Body = 0;
    //1=インパラ 1=オオカミ
    public int Leg = 0;

    //移動速度
    private float Speed = 40.0f;
    //走る時の速さは未実装
    private float Sprintspeed = 25.0f;
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
    private float HP10per = -34.7f;

    //無敵時間の生成
    private bool Invincible = false;

    //飛ぶ方向のための調整
    public GameObject Player1;

    //カエルの攻撃
    public GameObject P1FlogTongue;
    public Animator P1FlogAnimator;
    private bool FlogSwitch = true;

    //サソリの攻撃
    private bool ScorpionAtk = true;
    public GameObject P1ScorpionBullet;
    //攻撃が飛ぶ位置のブロック
    public GameObject P1SetScorpion;
    //下の数値と同じでこの値を変化させて毒ダメージを表す
    private float Poisontimer = 5;
    //毒に係り続ける時間
    private float Poisoningtime = 5;

    //オオカミの攻撃
    public GameObject P1WolfAtk;
    private bool WolfSwitch = true;
    public Material P1WolfNormal;
    public Material P1WolfColor;

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

    //キャラの向きを常に一定に
    private GameObject EnemyObj;

    //ADX設定
    public CriAtomSource AnimalFSSrc;
    public CriAtomSource LionSrc;
    public CriAtomSource FrogSwingSrc;
    public CriAtomSource TurtleShieldOPSrc;
    public CriAtomSource ScorpionSrc;
    public CriAtomSource ImpalaJumpSrc;
    public CriAtomSource WolfSrc;
    public CriAtomSource AnimalJumpSrc;
    public CriAtomSource AnimalShieldOPSrc;

    void Start()
    {
        P1FlogTongue.SetActive(false);
        P1Lionhead.SetActive(false);
        P1TurtleGard.SetActive(false);
        P1WolfAtk.SetActive(false);
        Rb = GetComponent<Rigidbody>();
        P1collider = GetComponent<Collider>();
        P1collider.isTrigger = false;
        Rb.isKinematic = true;
        EnemyObj = GameObject.Find("P2camera");

    }

    // Update is called once per frame
    void Update()
    {
        Gamemode = Timer.GetGamemode();
        P1TurtleGard.transform.position = this.transform.position;
        //シールドの色変更　tの値で変わる　調整中無視していいよ
        ShieldObj.GetComponent<Renderer>().material.color = Color.HSVToRGB(ShieldPoint * 150, 1, 1);

        if (AllActionInterval == false)
        {
            if (Gamemode == 1)
            {
                if (Shield == false)
                {
                    Rb.isKinematic = false;
                    if (Implajump == false)
                    {

                        if (FlogSwitch == true)
                        {
                            if (NormalJump == false)
                            {
                                if (Input.GetKey(KeyCode.Joystick1Button14))
                                {
                                    Speed = Sprintspeed;

                                    //音鳴らす
                                    AnimalFSSrc.Play();
                                }
                                else
                                {
                                    //歩きの速さの調整をする際はここも
                                    Speed = 40.0f;
                                }
                            }
                            else
                            {
                                Speed = 15f;
                            }

                            Direction.Set(Input.GetAxis("Vertical 1"), 0, Input.GetAxis("Horizontal 1"));
                            if (Direction != Vector3.zero)
                            {
                                //向きを指定
                                transform.rotation = Quaternion.LookRotation(Direction);
                            }
                            else
                            {
                                transform.LookAt(EnemyObj.transform);
                            }
                            //前方に移動する
                            transform.position += Direction * Speed * Time.deltaTime;

                        }

                        if (NormalJump == false)
                        {

                            if (Head == 1)
                            {
                                //カエル
                                if (Input.GetKeyDown(KeyCode.Joystick1Button3))
                                {
                                    //音鳴らす
                                    FrogSwingSrc.Play();

                                    if (FlogSwitch == true)
                                    {
                                        P1FlogTongue.SetActive(true);
                                        P1FlogAnimator.SetTrigger("FlogAtkStartP1");
                                        P1FlogAnimator.SetBool("FlogAtkFinP1", false);
                                        FlogSwitch = false;
                                    }
                                }
                                if (Input.GetKeyUp(KeyCode.Joystick1Button3))
                                {
                                    if (FlogSwitch == false)
                                    {
                                        P1FlogAnimator.SetBool("FlogAtkFinP1", true);
                                        //オブジェクトが消える時間
                                        Invoke("DelayFlog", 1.5f);
                                        AllActionInterval = true;
                                        //行動停止
                                        Invoke("ActionInterval", 3.0f);
                                    }
                                }
                                else if (Head == 2)
                                {
                                    // ライオン
                                    if (Input.GetKey(KeyCode.Joystick1Button3))
                                    {
                                        //音鳴らす
                                        LionSrc.Play();

                                        if (LionSwitch == true)
                                        {
                                            AllActionInterval = true;
                                            P1Lionhead.tag = "P1LionAttack";
                                            P1Lionhead.SetActive(true);
                                            Rb.AddForce(transform.forward * 20f, ForceMode.Impulse);
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
                                }

                                if (FlogSwitch == true)
                                {

                                    if (Body == 1)
                                    {
                                        //カメ
                                        if (Input.GetKeyUp(KeyCode.Joystick1Button1))
                                        {
                                            //音鳴らす
                                            TurtleShieldOPSrc.Play();

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
                                    else if (Body == 2)
                                    {
                                        //サソリ
                                        if (Input.GetKeyUp(KeyCode.Joystick1Button1))
                                        {
                                            //音鳴らす
                                            ScorpionSrc.Play();

                                            if (ScorpionAtk == true)
                                            {
                                                AllActionInterval = true;
                                                GameObject Obj;
                                                Obj = Instantiate(P1ScorpionBullet, P1SetScorpion.transform.position, P1SetScorpion.transform.rotation) as GameObject;
                                                //行動停止
                                                Invoke("ActionInterval", 0.2f);
                                                //リキャストタイム
                                                Invoke("DelayScorpion", 0.2f);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        if (FlogSwitch == true)
                        {
                            if (NormalJump == false)
                            {

                                if (Leg == 1)
                                {
                                    //インパラ
                                    if (Input.GetKeyDown(KeyCode.Joystick1Button0))
                                    {
                                        //音鳴らす
                                        ImpalaJumpSrc.Play();

                                        if (Implajump == true)
                                        {
                                            if (this.transform.position.y > 20)
                                            {
                                                Rb.isKinematic = true;
                                                P1collider.isTrigger = true;
                                                AllActionInterval = true;
                                                Invoke("ImpleFreeze", 1.0f);
                                            }
                                        }
                                        else if (Implajump == false)
                                        {
                                            Rb.AddForce(transform.up * 40, ForceMode.Impulse);
                                            Implajump = true;
                                        }
                                    }
                                    if (Implajump == true)
                                    {
                                        transform.position += transform.forward * 25 * Time.deltaTime;
                                    }
                                }
                                else if (Leg == 2)
                                {
                                    //オオカミ
                                    if (Input.GetKey(KeyCode.Joystick1Button0))
                                    {
                                        //音鳴らす
                                        WolfSrc.Play();

                                        if (WolfSwitch == true)
                                        {
                                            P1WolfAtk.SetActive(true);
                                            AllActionInterval = true;
                                            P1WolfAtk.tag = "P2WolfAttack";
                                            Rb.AddForce(transform.forward * 30f, ForceMode.Impulse);
                                            P1WolfAtk.GetComponent<Renderer>().material.color = P1WolfColor.color;
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

                }
            }

            //LRのシールド
            if (Input.GetKey(KeyCode.Joystick2Button15) || Input.GetKey(KeyCode.Joystick1Button15))
            {
                //音鳴らす
                AnimalShieldOPSrc.Play();

                if (NormalJump == false)
                {
                    if (FlogSwitch == true)
                    {
                        Shield = true;
                        ShieldObj.SetActive(true);
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
            if (Input.GetKeyUp(KeyCode.Joystick2Button15) || Input.GetKeyUp(KeyCode.Joystick1Button15))
            {
                if (NormalJump == false)
                {
                    ShieldObj.SetActive(false);
                    Invoke("ShieldDelay", 0.5f);
                }
            }
            if (Input.GetKey(KeyCode.Joystick1Button2))
            {
                if (Shield == false)
                {
                    if (NormalJump == false)
                    {
                        if (FlogSwitch == true)
                        {
                            Rb.AddForce(transform.up * 15, ForceMode.Impulse);
                            NormalJump = true;

                            //音鳴らす
                            AnimalJumpSrc.Play();
                        }
                    }
                }
            }
        }

        if (Poisontimer < Poisoningtime)
        {
            Poisontimer += Time.deltaTime;
            Player1HP -= Time.deltaTime;
            P1G.transform.position += new Vector3(HP10per * (0.01f * Time.deltaTime), 0, 0);
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

            //音鳴らす
            //audioSource.PlayOneShot(ShieldBreakSound);
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
        P1Lionhead.SetActive(false);
        P1Lionhead.tag = "Player1";
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
        Rb.AddForce(-transform.up * 25, ForceMode.Impulse);
        P1ImplaBlock.SetActive(true);
    }
    void WolfAttackTime()
    {
        //攻撃判定がある状態、分かりやすく現在は色を変更
        P1WolfAtk.SetActive(false);
        P1WolfAtk.tag = "Player1";
        P1WolfAtk.GetComponent<Renderer>().material.color = P1WolfNormal.color;
    }
    void DelayWolf()
    {
        //オオカミ攻撃が連続で発生しないように
        WolfSwitch = true;
    }
    void DelayScorpion()
    {
        //カウンターが連続で発生しないため
        ScorpionAtk = true;
    }
    void DelayFlog()
    {
        //カエル攻撃オブジェクトの除去
        P1FlogTongue.SetActive(false);
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

    public static float GetP1HP()
    {
        return Player1HP;
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

    //元の数字に10+
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
                    Rb.AddForce(ToVec * 15, ForceMode.Impulse);
                    //無敵タイム開始 当たり判定が連続しないように
                    Invincible = true;
                    Invoke("InvincibleTime", 0.3f);
                }
                if (other.gameObject.CompareTag("P2Impla"))
                {
                    //ダメを食らう時の半分ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player1);
                    Rb.AddForce(ToVec * 17, ForceMode.Impulse);
                    ShieldPoint -= 0.3f;
                    //無敵タイム開始 当たり判定が連続しないように
                    Invincible = true;
                    Invoke("InvincibleTime", 0.3f);
                }

                if (other.gameObject.CompareTag("P2ImplaWave"))
                {
                    //ダメを食らう時の半分ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player1);
                    Rb.AddForce(ToVec * 15, ForceMode.Impulse);
                    ShieldPoint -= 0.1f;
                    //無敵タイム開始 当たり判定が連続しないように
                    Invincible = true;
                    Invoke("InvincibleTime", 0.3f);
                }
                //カエル、サソリ、オオカミ
                if (other.gameObject.CompareTag("P2FlogAttack"))
                {
                    //ダメを食らう時の半分ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player1);
                    Rb.AddForce(ToVec * 13, ForceMode.Impulse);
                    ShieldPoint -= 0.04f;
                    //無敵タイム開始 当たり判定が連続しないように
                    Invincible = true;
                    Invoke("InvincibleTime", 0.3f);
                }
                if (other.gameObject.CompareTag("PoisonAttack"))
                {
                    //ダメを食らう時の半分ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player1);
                    Rb.AddForce(ToVec * 12, ForceMode.Impulse);
                    ShieldPoint -= 0.05f;
                    //無敵タイム開始 当たり判定が連続しないように
                    Invincible = true;
                    Invoke("InvincibleTime", 0.3f);
                }
                if (other.gameObject.CompareTag("PoisonAttackBack"))
                {
                    //ダメを食らう時の半分ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player1);
                    Rb.AddForce(ToVec * 13, ForceMode.Impulse);
                    ShieldPoint -= 0.06f;
                    //無敵タイム開始 当たり判定が連続しないように
                    Invincible = true;
                    Invoke("InvincibleTime", 0.3f);
                }
                if (other.gameObject.CompareTag("P2WolfAttack"))
                {
                    //ダメを食らう時の半分ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player1);
                    Rb.AddForce(ToVec * 17, ForceMode.Impulse);
                    ShieldPoint -= 0.15f;
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
                    P1G.transform.position += new Vector3(HP10per * 2, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player1);
                    Rb.AddForce(ToVec * 20, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                }
                if (other.gameObject.CompareTag("P2Impla"))
                {
                    Player1HP -= 30;
                    P1G.transform.position += new Vector3(HP10per * 3, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player1);
                    Debug.Log(ToVec);
                    Rb.AddForce(ToVec * 25, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                }
                if (other.gameObject.CompareTag("P2ImplaWave"))
                {
                    Player1HP -= 10;
                    P1G.transform.position += new Vector3(HP10per, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player1);
                    Rb.AddForce(ToVec * 20, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                }
                if (other.gameObject.CompareTag("P2WolfAttack"))
                {
                    Player1HP -= 15;
                    P1G.transform.position += new Vector3(HP10per * 1.5f, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player1);
                    Rb.AddForce(ToVec * 20, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                }
                if (other.gameObject.CompareTag("P2FlogAttack"))
                {
                    Player1HP -= 4;
                    P1G.transform.position += new Vector3(HP10per * 0.4f, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player1);
                    Rb.AddForce(ToVec * 15, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 0.3f);
                }
                if (other.gameObject.CompareTag("PoisonAttack"))
                {
                    Player1HP -= 5;
                    Poisontimer = 0;
                    P1G.transform.position += new Vector3(HP10per * 0.5f, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player1);
                    Rb.AddForce(ToVec * 15, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                }
                //カウンターダメージ用
                if (other.gameObject.CompareTag("P1LionAttackBack"))
                {
                    Player1HP -= 24;
                    P1G.transform.position += new Vector3(HP10per * 2 * 1.2f, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player1);
                    Rb.AddForce(ToVec * 25, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                }
                if (other.gameObject.CompareTag("P1ImplaBack"))
                {
                    Player1HP -= 36;
                    P1G.transform.position += new Vector3(HP10per * 3 * 1.2f, 0, 0);
                    Vector3 ToVec = GetAngleVec(other.gameObject, P1ImplaBlock);

                    Rb.AddForce(ToVec * 30, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                }
                if (other.gameObject.CompareTag("P1ImplaWaveBack"))
                {
                    Player1HP -= 12;
                    P1G.transform.position += new Vector3(HP10per * 1.2f, 0, 0);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                }
                if (other.gameObject.CompareTag("P1FlogAttackBack"))
                {
                    Player1HP -= 4.8f;
                    P1G.transform.position += new Vector3(HP10per * 0.48f, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player1);
                    Rb.AddForce(ToVec * 12, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 0.3f);
                }
                //オオカミのカウンターのタグに切り替えが未実装
                if (other.gameObject.CompareTag("P1WolfAttackBack"))
                {
                    Player1HP -= 18;
                    P1G.transform.position += new Vector3(HP10per * 1.8f, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player1);
                    Rb.AddForce(ToVec * 25, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                }
                if (other.gameObject.CompareTag("PoisonAttackBack"))
                {
                    Player1HP -= 6;
                    Poisontimer = 0;
                    P1G.transform.position += new Vector3(HP10per * 0.6f, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player1);
                    Rb.AddForce(ToVec * 16, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                }
            }
        }
    }
}