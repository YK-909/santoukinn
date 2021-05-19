using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeybordPlay2 : MonoBehaviour
{
    //全部5倍
    //体力
    public float Player2HP;

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
    public GameObject P2G;
    public GameObject P2R;
    //座標からHPが10ごと減少した際の値
    private float HP10per = 34.5f;

    //無敵時間の生成
    private bool Invincible = false;

    //飛ぶ方向のための調整
    public GameObject Player2;

    //カエルの攻撃
    public GameObject P2FlogTongue;
    public Animator P2FlogAnimator;
    private bool FlogSwitch = true;

    //サソリの攻撃
    private bool ScorpionAtk = true;
    public GameObject ScorpionBullet;
    //攻撃が飛ぶ位置のブロック
    public GameObject P2SetScorpion;
    //下の数値と同じでこの値を変化させて毒ダメージを表す
    private float Poisontimer = 5;
    //毒に係り続ける時間
    private float Poisoningtime = 5;

    //オオカミの攻撃
    public GameObject P2WolfAtk;
    private bool WolfSwitch = true;
    public Material P2WolfNormal;
    public Material P2WolfColor;

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
    private Rigidbody Rb;
    public GameObject P2ImplaBlock;
    public GameObject P2ImplaWaveBlock;

    private bool AllActionInterval = false;
    //透過させるために
    private Collider P1collider;

    //AudioComponent
    public AudioClip Footsteps;
    public AudioClip LionBite;
    public AudioClip FrogTongueAttack;
    public AudioClip TurtleShield;
    public AudioClip ScorpionNeedle;
    public AudioClip ImpalaJump;
    public AudioClip WolfScratch;
    public AudioClip NormalShield;
    public AudioClip AllCharacterJump;
    public AudioClip ShieldBreakSound;
    AudioSource audioSource;

    void Start()
    {
        P2FlogTongue.SetActive(false);
        P2TurtleGard.SetActive(false);
        Rb = GetComponent<Rigidbody>();
        P1collider = GetComponent<Collider>();
        P1collider.isTrigger = false;

        //AudioComponent取得
        audioSource = GetComponent<AudioSource>();
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

                if (Implajump == false)
                {

                    if (FlogSwitch == true)
                    {
                        if (NormalJump == false)
                        {
                            if (Input.GetKey(KeyCode.LeftControl))
                            {
                                Speed = Sprintspeed;
                            }
                            else
                            {
                                //歩きの速さの調整をする際はここも
                                Speed = 40.0f;
                            }
                        }
                        else
                        {
                            Speed = 25f;
                        }

                        if (Input.GetKey(KeyCode.UpArrow))
                        {
                            //キャラクターが指定の向きを向く
                            transform.rotation = Quaternion.Euler(0, -90, 0);
                            //前方に移動する
                            transform.position += transform.forward * Speed * Time.deltaTime;

                            //音鳴らす
                            audioSource.PlayOneShot(Footsteps);
                        }
                        else if (Input.GetKey(KeyCode.DownArrow))
                        {
                            //キャラクターが指定の向きを向く
                            transform.rotation = Quaternion.Euler(0, 90, 0);
                            //前方に移動する
                            transform.position += transform.forward * Speed * Time.deltaTime;

                            //音鳴らす
                            audioSource.PlayOneShot(Footsteps);
                        }
                        else if (Input.GetKey(KeyCode.RightArrow))
                        {
                            //キャラクターが指定の向きを向く
                            transform.rotation = Quaternion.Euler(0, 0, 0);
                            //前方に移動する
                            transform.position += transform.forward * Speed * Time.deltaTime;

                            //音鳴らす
                            audioSource.PlayOneShot(Footsteps);
                        }
                        else if (Input.GetKey(KeyCode.LeftArrow))
                        {
                            //キャラクターが指定の向きを向く
                            transform.rotation = Quaternion.Euler(0, 180, 0);
                            //前方に移動する
                            transform.position += transform.forward * Speed * Time.deltaTime;

                            //音鳴らす
                            audioSource.PlayOneShot(Footsteps);
                        }
                    }

                    if (NormalJump == false)
                    {
                        if (Head == 1)
                        {
                            // ライオン
                            if (Input.GetKey(KeyCode.Z))
                            {
                                //音鳴らす
                                audioSource.PlayOneShot(LionBite);

                                if (LionSwitch == true)
                                {
                                    AllActionInterval = true;
                                    P2Lionhead.tag = "P2LionAttack";
                                    Rb.AddForce(transform.forward * 50f, ForceMode.Impulse);
                                    P2Lionhead.GetComponent<Renderer>().material.color = P2LionColor.color;
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
                        else if (Head == 2)
                        {
                            //カエル
                            if (Input.GetKeyDown(KeyCode.Z))
                            {
                                //音鳴らす
                                audioSource.PlayOneShot(FrogTongueAttack);

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
                                    Invoke("DelayFlog", 1.0f);
                                    AllActionInterval = true;
                                    //行動停止
                                    Invoke("ActionInterval", 3.0f);
                                }
                            }
                        }

                        if (FlogSwitch == true)
                        {
                            if (Body == 1)
                            {
                                //カメ
                                if (Input.GetKeyUp(KeyCode.X))
                                {
                                    //音鳴らす
                                    audioSource.PlayOneShot(TurtleShield);

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
                            }
                            else if (Body == 2)
                            {
                                //サソリ
                                if (Input.GetKeyUp(KeyCode.X))
                                {
                                    //音鳴らす
                                    audioSource.PlayOneShot(ScorpionNeedle);

                                    if (ScorpionAtk == true)
                                    {
                                        AllActionInterval = true;
                                        GameObject Obj;
                                        Obj = Instantiate(ScorpionBullet, P2SetScorpion.transform.position, P2SetScorpion.transform.rotation) as GameObject;
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
                            if (Input.GetKeyDown(KeyCode.C))
                            {
                                //音鳴らす
                                audioSource.PlayOneShot(ImpalaJump);

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
                            if (Input.GetKey(KeyCode.C))
                            {
                                //音鳴らす
                                audioSource.PlayOneShot(WolfScratch);

                                if (WolfSwitch == true)
                                {
                                    AllActionInterval = true;
                                    P2WolfAtk.tag = "P2WolfAttack";
                                    Rb.AddForce(transform.forward * 55f, ForceMode.Impulse);
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
                //音鳴らす
                audioSource.PlayOneShot(NormalShield);

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
            if (Input.GetKeyUp(KeyCode.V))
            {
                if (NormalJump == false)
                {
                    ShieldObj.SetActive(false);
                    Invoke("ShieldDelay", 0.5f);
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
                            Rb.AddForce(transform.up * 30, ForceMode.Impulse);
                            NormalJump = true;

                            //音鳴らす
                            audioSource.PlayOneShot(AllCharacterJump);
                        }
                    }
                }
            }
        }

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

            //音鳴らす
            audioSource.PlayOneShot(ShieldBreakSound);
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
        P2Lionhead.tag = "Player";
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
        //オブジェクト非表示
        P2ImplaBlock.SetActive(false);
    }
    void DelayImpleWave()
    {
        //地面にぶつかった時の衝撃波の除去
        P2ImplaWaveBlock.SetActive(false);
    }
    void ImpleFreeze()
    {
        //空中で一時停止
        Rb.isKinematic = false;
        Rb.AddForce(-transform.up * 30, ForceMode.Impulse);
        P2ImplaBlock.SetActive(true);
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
    void DelayScorpion()
    {
        //カウンターが連続で発生しないため
        ScorpionAtk = true;
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
            Vector3 Pos = this.transform.position;
            //ただのジャンプ
            NormalJump = false;
            Implajump = false;
            //インパラの攻撃のため
            if (AllActionInterval == true)
            {
                //P2のインパラブロックが表示されているとき
                if (P2ImplaBlock.activeSelf == true)
                {
                    //Pos.y = 10;
                    this.transform.position = Pos;
                    //Rb.isKinematic = true;
                    P2ImplaWaveBlock.SetActive(true);
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
                if (other.gameObject.CompareTag("P1LionAttack"))
                {
                    ShieldPoint -= 0.2f;
                    //ダメを食らう時の半分ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player2);
                    Rb.AddForce(ToVec * 15, ForceMode.Impulse);
                    //無敵タイム開始 当たり判定が連続しないように
                    Invincible = true;
                    Invoke("InvincibleTime", 0.3f);
                }
                if (other.gameObject.CompareTag("P1Impla"))
                {
                    //ダメを食らう時の半分ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player2);
                    Rb.AddForce(ToVec * 17, ForceMode.Impulse);
                    ShieldPoint -= 0.3f;
                    //無敵タイム開始 当たり判定が連続しないように
                    Invincible = true;
                    Invoke("InvincibleTime", 0.3f);
                }

                if (other.gameObject.CompareTag("P1ImplaWave"))
                {
                    //ダメを食らう時の半分ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player2);
                    Rb.AddForce(ToVec * 15, ForceMode.Impulse);
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
                    Rb.AddForce(ToVec * 13, ForceMode.Impulse);
                    ShieldPoint -= 0.04f;
                    //無敵タイム開始 当たり判定が連続しないように
                    Invincible = true;
                    Invoke("InvincibleTime", 0.3f);
                }
                if (other.gameObject.CompareTag("PoisonAttack"))
                {
                    //ダメを食らう時の半分ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player2);
                    Rb.AddForce(ToVec * 12, ForceMode.Impulse);
                    ShieldPoint -= 0.05f;
                    //無敵タイム開始 当たり判定が連続しないように
                    Invincible = true;
                    Invoke("InvincibleTime", 0.3f);
                }
                if (other.gameObject.CompareTag("PoisonAttackBack"))
                {
                    //ダメを食らう時の半分ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player2);
                    Rb.AddForce(ToVec * 13, ForceMode.Impulse);
                    ShieldPoint -= 0.06f;
                    //無敵タイム開始 当たり判定が連続しないように
                    Invincible = true;
                    Invoke("InvincibleTime", 0.3f);
                }
                if (other.gameObject.CompareTag("P1WolfAttack"))
                {
                    //ダメを食らう時の半分ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player2);
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
                if (other.gameObject.CompareTag("P1LionAttack"))
                {
                    Player2HP -= 20;
                    P2G.transform.position += new Vector3(HP10per * 2, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player2);
                    Rb.AddForce(ToVec * 20, ForceMode.Impulse);
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
                    Debug.Log(ToVec);
                    Rb.AddForce(ToVec * 25, ForceMode.Impulse);
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
                    Rb.AddForce(ToVec * 20, ForceMode.Impulse);
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
                    Rb.AddForce(ToVec * 20, ForceMode.Impulse);
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
                    Rb.AddForce(ToVec * 15, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 0.3f);
                }
                if (other.gameObject.CompareTag("PoisonAttack"))
                {
                    Player2HP -= 5;
                    Poisontimer = 0;
                    P2G.transform.position += new Vector3(HP10per * 0.5f, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player2);
                    Rb.AddForce(ToVec * 15, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                }
                //カウンターダメージ用
                if (other.gameObject.CompareTag("P2LionAttackBack"))
                {
                    Player2HP -= 24;
                    P2G.transform.position += new Vector3(HP10per * 2 * 1.2f, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player2);
                    Rb.AddForce(ToVec * 25, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                }
                if (other.gameObject.CompareTag("P2ImplaBack"))
                {
                    Player2HP -= 36;
                    P2G.transform.position += new Vector3(HP10per * 3 * 1.2f, 0, 0);
                    Vector3 ToVec = GetAngleVec(other.gameObject, P2ImplaBlock);

                    Rb.AddForce(ToVec * 30, ForceMode.Impulse);
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
                if (other.gameObject.CompareTag("P2FlogAttackBack"))
                {
                    Player2HP -= 4.8f;
                    P2G.transform.position += new Vector3(HP10per * 0.48f, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player2);
                    Rb.AddForce(ToVec * 12, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 0.3f);
                }
                //オオカミのカウンターのタグに切り替えが未実装
                if (other.gameObject.CompareTag("P2WolfAttackBack"))
                {
                    Player2HP -= 18;
                    P2G.transform.position += new Vector3(HP10per * 1.8f, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player2);
                    Rb.AddForce(ToVec * 25, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                }
                if (other.gameObject.CompareTag("PoisonAttackBack"))
                {
                    Player2HP -= 6;
                    Poisontimer = 0;
                    P2G.transform.position += new Vector3(HP10per * 0.6f, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player2);
                    Rb.AddForce(ToVec * 16, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                }
            }
        }
    }
}