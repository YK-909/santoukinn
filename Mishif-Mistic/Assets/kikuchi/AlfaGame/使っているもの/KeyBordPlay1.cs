using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBordPlay1 : MonoBehaviour
{
    //体力
    public static float Player2HP = 100;
    //
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
    public GameObject Player2;

    //カエルの攻撃
    public GameObject P1FlogTongue;
    public Animator P1FlogAnimator;
    private bool FlogSwitch = true;

    //サソリの攻撃
    private bool ScorpionAtk = true;
    public GameObject ScorpionBullet;
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
    public GameObject P2TurtleCounter;
    private bool Gard = true;

    //インパラののジャンプ攻撃
    private bool Implajump = false;
    private Rigidbody Rb;
    public GameObject P1ImplaBlock;
    public GameObject P1ImplaWaveBlock;

    private bool AllActionInterval = false;
    private bool CalledOncePoint = false;

    //キャラの向きを常に一定に
    private GameObject EnemyObj;
    private Vector3 Enemy;

    public CriAtomSource AnimalFSSrc;
    public CriAtomSource LionSrc;
    public CriAtomSource FrogSwingSrc;
    public CriAtomSource FrogAtkSrc;
    public CriAtomSource TurtleShieldOPSrc;
    public CriAtomSource ScorpionSrc;
    public CriAtomSource ImpalaJumpSrc;
    public CriAtomSource WolfSrc;
    public CriAtomSource AnimalJumpSrc;
    public CriAtomSource AnimalShieldOPSrc;
    public CriAtomSource AnimalShieldDstSrc;
    public CriAtomSource AnimalShieldDmgSrc;
    public CriAtomSource LionAtkVoSrc;
    public CriAtomSource FrogAtkVoSrc;
    public CriAtomSource AnimalDamage;
    private CriAtomSource atomSrc;

    //アニメーター
    private Animator Animator;

    //共通アニメーション
    private string isWalk = "isWalk";
    private string isRun = "isRun";
    private string isJump = "isJump";
    private string isFalt = "isFalt";
    private string isBlown = "isBlown";
    private string isShield = "isShield";

    //固有スキルアニメーション
    private string isBite = "isBite";
    private string isScratch = "isScratch";
    private string isKameShield = "isKameShield";
    private string isCounter = "isCounter";
    private string isMissileStr = "isMissileStr";
    private string isMissileFin = "isMissileFin";
    private string isTongueStr = "isTongueStr";
    private string isTongueFin = "isTongueFin";
    private string isImpalaAtkStr = "isImpAtkStr";
    private string isImpalaAtkCont = "isImpAtkCont";
    private string isImpalaAtkFin = "isImpAtkFin";
    private string isKick = "isKick";
    private string isGilotine = "isGilotine";
    private string isRollStr = "isRollStr";
    private string isRollFin = "isRollFin";

    void Start()
    {
        P1FlogTongue.SetActive(false);
        P1TurtleGard.SetActive(false);
        P1Lionhead.SetActive(false);
        P1WolfAtk.SetActive(false);
        Rb = GetComponent<Rigidbody>();
        Rb.isKinematic = true;
        EnemyObj = GameObject.Find("P2camera");

        Animator = GetComponent<Animator>();

        atomSrc = (CriAtomSource)GetComponent("CriAtomSource");
    }

    // Update is called once per frame
    void Update()
    {
        Gamemode = Timerbotgame.GetGamemode();
        P1TurtleGard.transform.position = this.transform.position + transform.forward * 5 + transform.up * -2;
        //シールドの色変更　tの値で変わる　調整中無視していいよ
        ShieldObj.GetComponent<Renderer>().material.color = Color.HSVToRGB(ShieldPoint * 150, 1, 1);

        if (Gamemode == 1)
        {
            if (!CalledOncePoint)
            {
                CalledOncePoint = true;
                Rb.isKinematic = false;
            }
            if (Shield == false)
            {

                if (Implajump == false)
                {
                    if (WolfSwitch == true)
                    {
                        if (ScorpionAtk == true)
                        {
                            if (Gard == true)
                            {
                                if (FlogSwitch == true)
                                {
                                    if (LionSwitch == true)
                                    {
                                        if (NormalJump == false)
                                        {
                                            //歩きの速さの調整をする際はここも
                                            Speed = 40.0f;

                                        }
                                        else
                                        {
                                            Speed = 15f;
                                        }

                                        if (Input.GetKey(KeyCode.UpArrow))
                                        {
                                            //キャラクターが指定の向きを向く
                                            transform.rotation = Quaternion.Euler(0, 0, 0);
                                            //前方に移動する
                                            transform.position += transform.forward * Speed * Time.deltaTime;
                                            if (Speed == 40.0)
                                            {
                                                //音鳴らす
                                                AnimalFSSrc.Play();
                                            }

                                            //走る
                                            this.Animator.SetBool(isRun, true);
                                        }
                                        else if (Input.GetKey(KeyCode.DownArrow))
                                        {
                                            //キャラクターが指定の向きを向く
                                            transform.rotation = Quaternion.Euler(0, 180, 0);
                                            //前方に移動する
                                            transform.position += transform.forward * Speed * Time.deltaTime;

                                            if (Speed == 40.0)
                                            {
                                                //音鳴らす
                                                AnimalFSSrc.Play();
                                            }

                                            //走る
                                            this.Animator.SetBool(isRun, true);
                                        }
                                        else if (Input.GetKey(KeyCode.RightArrow))
                                        {
                                            //キャラクターが指定の向きを向く
                                            transform.rotation = Quaternion.Euler(0, 90, 0);
                                            //前方に移動する
                                            transform.position += transform.forward * Speed * Time.deltaTime;
                                            if (Speed == 40.0)
                                            {
                                                //音鳴らす
                                                AnimalFSSrc.Play();
                                            }

                                            //走る
                                            this.Animator.SetBool(isRun, true);
                                        }
                                        else if (Input.GetKey(KeyCode.LeftArrow))
                                        {
                                            //キャラクターが指定の向きを向く
                                            transform.rotation = Quaternion.Euler(0, -90, 0);
                                            //前方に移動する
                                            transform.position += transform.forward * Speed * Time.deltaTime;

                                            if (Speed == 40.0)
                                            {
                                                //音鳴らす
                                                AnimalFSSrc.Play();
                                            }

                                            //走る
                                            this.Animator.SetBool(isRun, true);
                                        }
                                        else
                                        {
                                            Enemy = new Vector3(EnemyObj.transform.position.x, this.transform.position.y, EnemyObj.transform.position.z);
                                            transform.LookAt(Enemy);

                                            this.Animator.SetBool(isRun, false);
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (AllActionInterval == false)
                    {
                        if (NormalJump == false)
                        {
                            if (Head == 1)
                            {
                                //カエル
                                if (Input.GetKey(KeyCode.Z))
                                {
                                    //音鳴らす
                                    FrogSwingSrc.Play();
                                    //FrogAtkVoSrc.Play();

                                    if (FlogSwitch == true)
                                    {
                                        P1FlogTongue.SetActive(true);
                                        P1FlogAnimator.SetTrigger("FlogAtkStartP1");
                                        P1FlogAnimator.SetBool("FlogAtkFinP1", false);
                                        FlogSwitch = false;

                                        //舌攻撃
                                        this.Animator.SetBool(isTongueStr, true);
                                        this.Animator.SetBool(isTongueFin, false);
                                    }
                                }
                                if (Input.GetKeyUp(KeyCode.Z))
                                {
                                    if (FlogSwitch == false)
                                    {
                                        P1FlogAnimator.SetBool("FlogAtkFinP1", true);
                                        //オブジェクトが消える時間
                                        Invoke("DelayFlog", 1.5f);
                                        AllActionInterval = true;
                                        //行動停止
                                        Invoke("ActionInterval", 3.0f);

                                        //音止める
                                        FrogSwingSrc.Stop();

                                        //舌攻撃
                                        this.Animator.SetBool(isTongueStr, false);
                                        this.Animator.SetBool(isTongueFin, true);
                                    }
                                }
                            }
                            else if (Head == 2)
                            {
                                // ライオン
                                if (Input.GetKeyDown(KeyCode.Z))
                                {
                                    //音鳴らす
                                    LionAtkVoSrc.Play();
                                    Invoke("BiteSound", 0.6f);

                                    if (LionSwitch == true)
                                    {
                                        //P1Lionhead.SetActive(true);
                                        AllActionInterval = true;
                                        P1Lionhead.tag = "P1LionAttack";
                                        Rb.AddForce(transform.forward * 30f, ForceMode.Impulse);
                                        //P1Lionhead.GetComponent<Renderer>().material.color = P1LionColor.color;
                                        LionSwitch = false;
                                        //当たり判定がある時間
                                        Invoke("LionAttackTime", 0.5f);
                                        //行動停止
                                        Invoke("ActionInterval", 0.8f);
                                        //リキャストタイム
                                        Invoke("DelayLion", 1.2f);

                                        //噛む
                                        this.Animator.SetBool(isBite, true);
                                        //当たり判定
                                        Invoke("BiteEnable", 0.4f);
                                        Invoke("BiteUnable", 1.0f);
                                    }
                                }
                                else
                                {
                                    this.Animator.SetBool(isBite, false);
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
                                            Invoke("ActionInterval", 2.0f);
                                            //リキャストタイム
                                            Invoke("DelayTartle", 4f);

                                            //カメのシールド
                                            this.Animator.SetBool(isKameShield, true);
                                            this.Animator.SetBool(isCounter, false);

                                            //遷移タイミング
                                            Invoke("TurtleAnimTiming", 1.8f);
                                        }
                                    }
                                }
                                else if (Body == 2)
                                {
                                    //サソリ
                                    if (Input.GetKey(KeyCode.X))
                                    {
                                        //音鳴らす
                                        //ScorpionSrc.Play();

                                        if (ScorpionAtk == true)
                                        {
                                            AllActionInterval = true;
                                            ScorpionAtk = false;                                         
                                            //行動停止
                                            Invoke("ActionInterval", 0.2f);
                                            //リキャストタイム
                                            Invoke("DelayScorpion", 0.2f);

                                            //ミサイル発射タイミング
                                            Invoke("MissileTiming", 1.0f);
                                            Invoke("MissileTiming", 1.2f);

                                            //ミサイル発射
                                            this.Animator.SetBool(isMissileStr, true);
                                            this.Animator.SetBool(isMissileFin, false);
                                        }
                                    }
                                    else
                                    {
                                        this.Animator.SetBool(isMissileStr, false);
                                        this.Animator.SetBool(isMissileFin, true);
                                    }
                                }
                            }
                        }
                    }
                }

                if (AllActionInterval == false)
                {
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
                                    ImpalaJumpSrc.Play();

                                    if (Implajump == true)
                                    {
                                        if (this.transform.position.y > 20)
                                        {
                                            Rb.isKinematic = true;
                                            AllActionInterval = true;
                                            Invoke("ImpleFreeze", 1.0f);

                                            Invoke("ImpalaAtkTiming", 0.5f);
                                            Invoke("ImpalaFinTiming", 1.5f);
                                        }
                                    }
                                    else if (Implajump == false)
                                    {
                                        Rb.AddForce(transform.up * 90, ForceMode.Impulse);
                                        Implajump = true;

                                        //インパラ攻撃
                                        this.Animator.SetBool(isImpalaAtkStr, true);
                                        this.Animator.SetBool(isImpalaAtkCont, false);
                                        this.Animator.SetBool(isImpalaAtkFin, false);

                                    }
                                }
                                if (Implajump == true)
                                {
                                    transform.position += transform.forward * 15 * Time.deltaTime;

                                }


                            }
                            else if (Leg == 2)
                            {
                                //オオカミ
                                if (Input.GetKey(KeyCode.C))
                                {
                                    //音鳴らす
                                    //WolfSrc.Play();
                                    Invoke("ScratchSound", 0.5f);

                                    if (WolfSwitch == true)
                                    {
                                        //P1WolfAtk.SetActive(true);
                                        AllActionInterval = true;
                                        P1WolfAtk.tag = "P1WolfAttack";
                                        Rb.AddForce(transform.forward * 40f, ForceMode.Impulse);
                                        // P1WolfAtk.GetComponent<Renderer>().material.color = P1WolfColor.color;
                                        WolfSwitch = false;
                                        //当たり判定がある時間
                                        Invoke("WolfAttackTime", 0.5f);
                                        //行動停止
                                        Invoke("ActionInterval", 0.8f);
                                        //リキャストタイム
                                        Invoke("DelayWolf", 1.2f);

                                        //ひっかく
                                        this.Animator.SetBool(isScratch, true);
                                        //当たり判定
                                        Invoke("ScratchEnable", 0.4f);
                                        Invoke("ScratchUnable", 1.0f);
                                    }
                                }
                                else
                                {
                                    //ひっかく
                                    this.Animator.SetBool(isScratch, false);
                                }
                            }
                        }
                    }
                }

            }



            if (AllActionInterval == false)
            {
                if (Implajump == false)
                {
                    //LRのシールド
                    if (Input.GetKey(KeyCode.V))
                    {
                        //音鳴らす
                        AnimalShieldOPSrc.Play();

                        //シールド展開
                        this.Animator.SetBool(isShield, true);

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

                        this.Animator.SetBool(isShield, false);
                    }
                    if (Input.GetKey(KeyCode.Space))
                    {
                        if (Shield == false)
                        {
                            if (NormalJump == false)
                            {
                                if (FlogSwitch == true)
                                {
                                    Rb.AddForce(transform.up * 45, ForceMode.Impulse);
                                    NormalJump = true;

                                    //音鳴らす
                                    AnimalJumpSrc.Play();

                                    //ジャンプする
                                    this.Animator.SetBool(isJump, true);
                                }
                            }
                        }
                    }
                    else
                    {
                        //ジャンプする
                        this.Animator.SetBool(isJump, false);
                    }
                }
            }

        }
        else if (Gamemode == 2)
        {
            Player2HP = 100;
        }

        if (Poisontimer < Poisoningtime)
        {
            Poisontimer += Time.deltaTime;
            Player2HP -= Time.deltaTime;
            P1G.transform.position += new Vector3(HP10per * (0.1f * Time.deltaTime), 0, 0);
        }

        //HPの継続的な減少
        if (P1G.transform.position.x < P1R.transform.position.x)
        {
            P1R.transform.position -= new Vector3(0.1f, 0, 0);
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
            AnimalShieldDstSrc.Play();
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
        //P1Lionhead.SetActive(false);
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
        Rb.isKinematic = false;
        gameObject.layer = LayerMask.NameToLayer("ImplaLayer");
        Rb.AddForce(-transform.up * 30, ForceMode.Impulse);
        P1ImplaBlock.SetActive(true);
    }
    void WolfAttackTime()
    {
        //攻撃判定がある状態、分かりやすく現在は色を変更
        //P1WolfAtk.SetActive(false);
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

    void MissileTiming()
    {
        ScorpionSrc.Play();
        //ミサイル発射タイミング
        GameObject Obj;
        Obj = Instantiate(ScorpionBullet, P1SetScorpion.transform.position, P1SetScorpion.transform.rotation) as GameObject;
    }

    void ScratchSound()
    {
        WolfSrc.Play();
    }

    void ScratchEnable()
    {
        //オオカミの当たり判定
        P1WolfAtk.SetActive(true);

    }

    void ScratchUnable()
    {
        //オオカミの当たり判定を消す
        P1WolfAtk.SetActive(false);
    }

    void BiteSound()
    {
        LionSrc.Play();
    }

    void BiteEnable()
    {
        //ライオンの当たり判定
        P1Lionhead.SetActive(true);
    }

    void BiteUnable()
    {
        //ライオンの当たり判定を消すタイミングをイベントで制御
        P1Lionhead.SetActive(false);
    }

    void TurtleAnimTiming()
    {
        //カメのシールドがカウンターに遷移するタイミング
        this.Animator.SetBool(isKameShield, false);
        this.Animator.SetBool(isCounter, true);
    }
    void TurtleCounter()
    {
        GameObject Obj;
        Obj = Instantiate(P2TurtleCounter, transform.position + transform.forward * 6, transform.rotation) as GameObject;
        Destroy(Obj, 0.7f);
    }

    void ImpalaAtkTiming()
    {
        this.Animator.SetBool(isImpalaAtkCont, true);
        this.Animator.SetBool(isImpalaAtkFin, false);
        this.Animator.SetBool(isImpalaAtkStr, false);
    }

    void ImpalaFinTiming()
    {
        this.Animator.SetBool(isImpalaAtkFin, true);
        this.Animator.SetBool(isImpalaAtkStr, false);
        this.Animator.SetBool(isImpalaAtkCont, false);
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
        return Player2HP;
    }
    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "floor")
        {
            //ただのジャンプ
            NormalJump = false;
            Implajump = false;
            gameObject.layer = LayerMask.NameToLayer("NormalLayer");

            //インパラの攻撃のため
            if (AllActionInterval == true)
            {
                //P1のインパラブロックが表示されているとき
                if (P1ImplaBlock.activeSelf == true)
                {
                    P1ImplaWaveBlock.SetActive(true);
                    Invoke("DelayImple", 0.05f);
                    Invoke("DelayImpleWave", 0.1f);
                }
                //行動停止
                Invoke("ActionInterval", 0.5f);
            }
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
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player2);
                    Rb.AddForce(ToVec * 15, ForceMode.Impulse);
                    //無敵タイム開始 当たり判定が連続しないように
                    Invincible = true;
                    Invoke("InvincibleTime", 0.3f);
                    //音鳴らす
                    AnimalShieldDmgSrc.Play();
                }
                if (other.gameObject.CompareTag("P2Impla"))
                {
                    //ダメを食らう時の半分ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player2);
                    Rb.AddForce(ToVec * 17, ForceMode.Impulse);
                    ShieldPoint -= 0.3f;
                    //無敵タイム開始 当たり判定が連続しないように
                    Invincible = true;
                    Invoke("InvincibleTime", 0.3f);
                }

                if (other.gameObject.CompareTag("P2ImplaWave"))
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
                if (other.gameObject.CompareTag("P2FlogAttack"))
                {
                    //ダメを食らう時の半分ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player2);
                    Rb.AddForce(ToVec * 13, ForceMode.Impulse);
                    ShieldPoint -= 0.04f;
                    //無敵タイム開始 当たり判定が連続しないように
                    Invincible = true;
                    Invoke("InvincibleTime", 0.3f);
                    //音鳴らす
                    AnimalShieldDmgSrc.Play();
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
                    //音鳴らす
                    AnimalShieldDmgSrc.Play();
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
                if (other.gameObject.CompareTag("P2WolfAttack"))
                {
                    //ダメを食らう時の半分ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player2);
                    Rb.AddForce(ToVec * 17, ForceMode.Impulse);
                    ShieldPoint -= 0.15f;
                    //無敵タイム開始 当たり判定が連続しないように
                    Invincible = true;
                    Invoke("InvincibleTime", 0.3f);
                    //音鳴らす
                    AnimalShieldDmgSrc.Play();
                }

            }
            else
            {
                //ダメージの当たり判定
                if (other.gameObject.CompareTag("P2LionAttack"))
                {
                    Player2HP -= 20;
                    P1G.transform.position += new Vector3(HP10per * 2, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player2);
                    Rb.AddForce(ToVec * 50, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                    //音鳴らす
                    //LionSrc.Play();
                    //音鳴らす
                    AnimalDamage.Play();

                    //ふっとぶ
                    this.Animator.SetBool(isBlown, true);
                }
                if (other.gameObject.CompareTag("P2Impla"))
                {
                    Player2HP -= 30;
                    P1G.transform.position += new Vector3(HP10per * 3, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player2);
                    Debug.Log(ToVec);
                    Rb.AddForce(ToVec * 60, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);

                    //音鳴らす
                    atomSrc.Play("Impala_Attack");

                    //ふっとぶ
                    this.Animator.SetBool(isBlown, true);

                }
                if (other.gameObject.CompareTag("P2ImplaWave"))
                {
                    Player2HP -= 10;
                    P1G.transform.position += new Vector3(HP10per, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player2);
                    Rb.AddForce(ToVec * 30, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);

                    //ふっとぶ
                    this.Animator.SetBool(isBlown, true);
                }
                if (other.gameObject.CompareTag("P2WolfAttack"))
                {
                    Player2HP -= 15;
                    P1G.transform.position += new Vector3(HP10per * 1.5f, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player2);
                    Rb.AddForce(ToVec * 40, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                    //音鳴らす
                    AnimalDamage.Play();

                    //ふっとぶ
                    this.Animator.SetBool(isBlown, true);
                }
                if (other.gameObject.CompareTag("P2FlogAttack"))
                {
                    Player2HP -= 4;
                    P1G.transform.position += new Vector3(HP10per * 0.4f, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player2);
                    Rb.AddForce(ToVec * 15, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 0.6f);
                    //音鳴らす
                    FrogAtkSrc.Play();

                    //怯む
                    this.Animator.SetBool(isFalt, true);
                }
                if (other.gameObject.CompareTag("PoisonAttack"))
                {
                    Player2HP -= 5;
                    Poisontimer = 0;
                    P1G.transform.position += new Vector3(HP10per * 0.5f, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player2);
                    Rb.AddForce(ToVec * 15, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 0.7f);
                    //音鳴らす
                    AnimalDamage.Play();

                    //怯む
                    this.Animator.SetBool(isFalt, true);
                }
                //カウンターダメージ用
                if (other.gameObject.CompareTag("P1LionAttackBack"))
                {
                    Player2HP -= 24;
                    P1G.transform.position += new Vector3(HP10per * 2 * 1.2f, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player2);
                    Rb.AddForce(ToVec * 55, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                }
                if (other.gameObject.CompareTag("P1ImplaBack"))
                {
                    Player2HP -= 36;
                    P1G.transform.position += new Vector3(HP10per * 3 * 1.2f, 0, 0);
                    Vector3 ToVec = GetAngleVec(other.gameObject, P1ImplaBlock);

                    Rb.AddForce(ToVec * 60, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                }
                if (other.gameObject.CompareTag("P1ImplaWaveBack"))
                {
                    Player2HP -= 12;
                    P1G.transform.position += new Vector3(HP10per * 1.2f, 0, 0);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                }
                if (other.gameObject.CompareTag("P1FlogAttackBack"))
                {
                    Player2HP -= 4.8f;
                    P1G.transform.position += new Vector3(HP10per * 0.48f, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player2);
                    Rb.AddForce(ToVec * 20, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 0.3f);
                }
                //オオカミのカウンターのタグに切り替えが未実装
                if (other.gameObject.CompareTag("P1WolfAttackBack"))
                {
                    Player2HP -= 18;
                    P1G.transform.position += new Vector3(HP10per * 1.8f, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player2);
                    Rb.AddForce(ToVec * 55, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                }
                if (other.gameObject.CompareTag("PoisonAttackBack"))
                {
                    Player2HP -= 6;
                    Poisontimer = 0;
                    P1G.transform.position += new Vector3(HP10per * 0.6f, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, Player2);
                    Rb.AddForce(ToVec * 16, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                }
            }
        }
        else
        {
            this.Animator.SetBool(isFalt, false);
            this.Animator.SetBool(isBlown, false);
        }
    }
}