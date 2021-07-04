using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeybordPlay2 : MonoBehaviour
{
    //体力
    public static float Player2HP = 100;
    //
    private int Gamemode = 0;

    //キャラ変更
    //1=ライオン 2=カエル
    public int Head = 0;
    //1=カメ 2=サソリ 3=アルマジロ
    public int Body = 0;
    //1=インパラ 2=オオカミ 3=馬
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
    public GameObject P2G;
    public GameObject P2R;
    //座標からHPが10ごと減少した際の値
    private float HP10per = 34.7f;

    //無敵時間の生成
    private bool Invincible = false;

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

    //ライオンの攻撃
    public GameObject P2Lionhead;
    private bool LionSwitch = true;
    //出血について
    private float Bloodingtimer = 5;
    private float Bloodingtime = 5;
    private int Bloodper;

    //カメのカウンター
    public GameObject P2TurtleGard;
    public GameObject P2TurtleCounter;
    private bool Gard = true;

    //インパラののジャンプ攻撃
    private bool Implajump = false;
    private Rigidbody Rb;
    public GameObject P2ImplaBlock;
    public GameObject P2ImplaWaveBlock;

    //アルマジロの攻撃
    private float ArmadilloSpeed = 30.0f;
    private int ArmadilloMode = 0;
    private bool ArmadilloSwitch = true;

    //馬の攻撃
    public GameObject P2HorseLeg;
    private bool HorseSwitch=true;

    //クワガタの攻撃
    public GameObject KuwagataBlock;
    private bool KuwagataSwitch = true;
    private bool Flying = false;

    private bool AllActionInterval = false;
    private bool CalledOncePoint = false;

    //キャラの向きを常に一定に
    private GameObject EnemyObj;
    private Vector3 Enemy;

    //ADX設定
    //public CriAtomSource AnimalFSSrc;
    //public CriAtomSource LionSrc;
    //public CriAtomSource FrogSwingSrc;
    //public CriAtomSource FrogAtkSrc;
    //public CriAtomSource TurtleShieldOPSrc;
    //public CriAtomSource ScorpionSrc;
    //public CriAtomSource ImpalaJumpSrc;
    //public CriAtomSource WolfSrc;
    //public CriAtomSource AnimalJumpSrc;
    //public CriAtomSource AnimalShieldOPSrc;
    //public CriAtomSource AnimalShieldDstSrc;
    //public CriAtomSource AnimalShieldDmgSrc;
    //public CriAtomSource LionAtkVoSrc;
    //public CriAtomSource FrogAtkVoSrc;
    //public CriAtomSource AnimalDamage;
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
        P2FlogTongue.SetActive(false);
        P2TurtleGard.SetActive(false);
        P2Lionhead.SetActive(false);
        P2WolfAtk.SetActive(false);
        Rb = GetComponent<Rigidbody>();
        Rb.isKinematic = true;
        EnemyObj = GameObject.Find("P1camera");

        Animator = GetComponent<Animator>();

        atomSrc = (CriAtomSource)GetComponent<CriAtomSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Gamemode = Timer.GetGamemode();
        P2TurtleGard.transform.position = this.transform.position + transform.forward * 5+transform.up*-2;
        //シールドの色変更　tの値で変わる　調整中無視していいよ
        ShieldObj.GetComponent<Renderer>().material.color = Color.HSVToRGB(ShieldPoint * 150, 1, 1);

        if (Gamemode == 1)
        {
            if (AllActionInterval == false)
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
                        if (FlogSwitch == true)
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
                                    //AnimalFSSrc.Play();
                                    atomSrc.Play("Garden_Footsteps");
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
                                    //AnimalFSSrc.Play();
                                    atomSrc.Play("Garden_Footsteps");
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
                                    //AnimalFSSrc.Play();
                                    atomSrc.Play("Garden_Footsteps");
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
                                    //AnimalFSSrc.Play();
                                    atomSrc.Play("Garden_Footsteps");
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
                        if (Invincible == false)
                        {
                            if (NormalJump == false)
                            {
                                if (Head == 1)
                                {
                                    //カエル
                                    if (Input.GetKey(KeyCode.Z))
                                    {
                                        if (FlogSwitch == true)
                                        {
                                            //音鳴らす
                                            //FrogSwingSrc.Play();
                                            atomSrc.Play("Frog_Swing");
                                            //FrogAtkVoSrc.Play();

                                            P2FlogTongue.SetActive(true);
                                            P2FlogAnimator.SetTrigger("FlogAtkStartP1");
                                            P2FlogAnimator.SetBool("FlogAtkFinP1", false);
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
                                            P2FlogAnimator.SetBool("FlogAtkFinP1", true);
                                            //オブジェクトが消える時間
                                            Invoke("DelayFlog", 1.5f);
                                            AllActionInterval = true;
                                            //行動停止
                                            Invoke("ActionInterval", 3.0f);

                                            //音止める
                                            //FrogSwingSrc.Stop();
                                            atomSrc.Stop();

                                            //舌攻撃
                                            this.Animator.SetBool(isTongueStr, false);
                                            this.Animator.SetBool(isTongueFin, true);
                                        }
                                    }
                                }
                                else if (Head == 2)
                                {
                                    if (LionSwitch == true)
                                    {
                                        // ライオン
                                        if (Input.GetKeyDown(KeyCode.Z))
                                        {
                                            //音鳴らす
                                            //LionAtkVoSrc.Play();
                                            atomSrc.Play("LionAtkVo");
                                            Invoke("BiteSound", 0.6f);

                                            //P2Lionhead.SetActive(true);
                                            AllActionInterval = true;
                                            P2Lionhead.tag = "P2LionAttack";
                                            Rb.AddForce(transform.forward * 30f, ForceMode.Impulse);
                                            LionSwitch = false;
                                            //行動停止
                                            Invoke("ActionInterval", 1.1f);
                                            //リキャストタイム
                                            Invoke("DelayLion", 1.4f);

                                            //噛む
                                            this.Animator.SetBool(isBite, true);
                                            //当たり判定
                                            Invoke("BiteEnable", 0.4f);
                                            Invoke("BiteUnable", 1.0f);

                                        }
                                        else
                                        {
                                            this.Animator.SetBool(isBite, false);
                                        }
                                    }
                                }
                                else if (Head == 3)
                                {
                                    //クワガタの攻撃
                                    if (KuwagataSwitch == true)
                                    {
                                        if (Input.GetKeyDown(KeyCode.Z))
                                        {
                                            KuwagataSwitch = false;
                                            AllActionInterval = true;
                                            KuwagataBlock.tag = "P2KuwagataAttack";
                                            KuwagataBlock.SetActive(true);
                                            Rb.isKinematic = true;
                                            Invoke("KuwagataUnable", 0.7f);
                                            //行動停止
                                            Invoke("ActionInterval", 1.5f);
                                            //リキャストタイム
                                            Invoke("DelayKuwagata", 3f);

                                            //ギロチンアタック
                                            this.Animator.SetBool(isGilotine, true);
                                        }

                                    }
                                    else
                                    {
                                        this.Animator.SetBool(isGilotine, false);
                                    }

                                }

                                if (FlogSwitch == true)
                                {
                                    if (Body == 1)
                                    {
                                        if (Gard == true)
                                        {
                                            //カメ
                                            if (Input.GetKeyUp(KeyCode.X))
                                            {
                                                //音鳴らす
                                                //TurtleShieldOPSrc.Play();
                                                atomSrc.Play("Turtle_Shield");

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
                                        if (ScorpionAtk == true)
                                        {
                                            //サソリ
                                            if (Input.GetKey(KeyCode.X))
                                            {
                                                //音鳴らす
                                                //ScorpionSrc.Play();


                                                AllActionInterval = true;
                                                ScorpionAtk = false;
                                                //GameObject Obj;
                                                //Obj = Instantiate(ScorpionBullet, P2SetScorpion.transform.position, P2SetScorpion.transform.rotation) as GameObject;
                                                //行動停止
                                                Invoke("ActionInterval", 1.5f);
                                                //リキャストタイム
                                                Invoke("DelayScorpion", 1.8f);

                                                //ミサイル発射タイミング
                                                Invoke("MissileTiming", 1.0f);
                                                Invoke("MissileTiming", 1.4f);

                                                //ミサイル発射
                                                this.Animator.SetBool(isMissileStr, true);
                                                this.Animator.SetBool(isMissileFin, false);
                                            }
                                            else
                                            {
                                                this.Animator.SetBool(isMissileStr, false);
                                                this.Animator.SetBool(isMissileFin, true);
                                            }
                                        }
                                    }
                                    else if (Body == 3)
                                    {
                                        if (ArmadilloSwitch == true)
                                        {
                                            if (ArmadilloMode == 0)
                                            {
                                                //アルマジロ
                                                if (Input.GetKey(KeyCode.X))
                                                {
                                                    Debug.Log(ArmadilloSpeed);
                                                    if (ArmadilloSpeed < 60)
                                                    {
                                                        ArmadilloSpeed += 15 * Time.deltaTime;
                                                    }

                                                    //ローリングアタック
                                                    this.Animator.SetBool(isRollStr, true);
                                                    this.Animator.SetBool(isRollFin, false);
                                                }
                                                if (Input.GetKeyUp(KeyCode.X))
                                                {
                                                    ArmadilloMode = 1;

                                                    this.Animator.SetBool(isRollStr, false);
                                                    this.Animator.SetBool(isRollFin, true);
                                                }
                                            }
                                            else if (ArmadilloMode == 1)
                                            {
                                                if (ArmadilloSpeed > 0)
                                                {
                                                    this.tag = "P2ArmadilloAttack";
                                                    ArmadilloSpeed += -20 * Time.deltaTime;
                                                    transform.position += transform.forward * ArmadilloSpeed * Time.deltaTime;
                                                    if (Input.GetKey(KeyCode.RightArrow))
                                                    {
                                                        //右に回転
                                                        transform.Rotate(0, 10 * Time.deltaTime, 0);
                                                    }
                                                    if (Input.GetKey(KeyCode.LeftArrow))
                                                    {
                                                        //左に回転
                                                        transform.Rotate(0, -10 * Time.deltaTime, 0);
                                                    }
                                                }
                                                else
                                                {
                                                    this.tag = "Player2";
                                                    ArmadilloMode = 0;
                                                    //オブジェクトが消える時間
                                                    ArmadilloSwitch = false;
                                                    Invoke("DelayArma", 3.0f);
                                                    AllActionInterval = true;
                                                    //行動停止
                                                    Invoke("ActionInterval", 3.0f);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (Invincible == false)
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
                                        //ImpalaJumpSrc.Play();
                                        atomSrc.Play("Impala_Jump");

                                        if (Implajump == true)
                                        {
                                            if (this.transform.position.y > 20)
                                            {
                                                Rb.isKinematic = true;
                                                AllActionInterval = true;
                                                Invoke("ImpleFreeze", 0.7f);

                                                Invoke("ImpalaAtkTiming", 0.5f);
                                                Invoke("ImpalaFinTiming", 1.5f);
                                            }
                                        }
                                        else if (Implajump == false)
                                        {
                                            Rb.AddForce(transform.up * 60, ForceMode.Impulse);
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
                                        if (WolfSwitch == true)
                                        {
                                            //音鳴らす
                                            //WolfSrc.Play();
                                            Invoke("ScratchSound", 0.5f);

                                            AllActionInterval = true;
                                            P2WolfAtk.tag = "P2WolfAttack";
                                            Rb.AddForce(transform.forward * 40f, ForceMode.Impulse);
                                            WolfSwitch = false;
                                            //行動停止
                                            Invoke("ActionInterval", 1.2f);
                                            //リキャストタイム
                                            Invoke("DelayWolf", 1.7f);

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
                                else if (Leg == 3)
                                {
                                    // ウマ
                                    if (Input.GetKeyDown(KeyCode.C))
                                    {

                                        if (HorseSwitch == true)
                                        {
                                            //音鳴らす

                                            AllActionInterval = true;
                                            P2HorseLeg.tag = "P2HorseAttack";
                                            Rb.AddForce(transform.forward * 25f, ForceMode.Impulse);
                                            HorseSwitch = false;
                                            //行動停止
                                            Invoke("ActionInterval", 1.1f);
                                            //リキャストタイム
                                            Invoke("DelayHorse", 1.6f);

                                            //蹴る
                                            this.Animator.SetBool(isKick, true);
                                            //当たり判定
                                            Invoke("KickEnable", 0.8f);
                                            Invoke("KickUnable", 1.2f);

                                        }
                                    }
                                    else
                                    {
                                        this.Animator.SetBool(isKick, false);
                                    }
                                }
                            }
                        }
                    }

                }



                if (Invincible == false)
                {
                    if (Implajump == false)
                    {
                        if (NormalJump == false)
                        {
                            //LRのシールド
                            if (Input.GetKey(KeyCode.V))
                            {
                                //音鳴らす
                                //AnimalShieldOPSrc.Play();
                                atomSrc.Play("Animal_Shield_OP");

                                //シールド展開
                                this.Animator.SetBool(isShield, true);


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

                                ShieldObj.SetActive(false);
                                Invoke("ShieldDelay", 0.5f);//行動停止
                                this.Animator.SetBool(isShield, false);
                            }
                            if (Shield == false)
                            {
                                if (Input.GetKey(KeyCode.Space))
                                {
                                    if (FlogSwitch == true)
                                    {
                                        Rb.AddForce(transform.up * 45, ForceMode.Impulse);
                                        NormalJump = true;

                                        //音鳴らす
                                        //AnimalJumpSrc.Play();
                                        atomSrc.Play("Animal_Jump");

                                        //ジャンプする
                                        this.Animator.SetBool(isJump, true);
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
            P2G.transform.position += new Vector3(HP10per * (0.1f * Time.deltaTime), 0, 0);
        }

        if (Bloodingtimer < Bloodingtime)
        {
            Bloodingtimer += Time.deltaTime;
            Player2HP -= Time.deltaTime;
            P2G.transform.position += new Vector3(HP10per * (0.1f * Time.deltaTime), 0, 0);
        }

        //HPの継続的な減少
        if (P2G.transform.position.x > P2R.transform.position.x)
        {
            P2R.transform.position += new Vector3(0.2f, 0, 0);
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
            //AnimalShieldDstSrc.Play();
            atomSrc.Play("Animal_Shield_Dst");
        }
        if (Flying == true) 
        {
            transform.position += transform.forward * 50 * Time.deltaTime;
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
        gameObject.layer = LayerMask.NameToLayer("ImplaLayer");
        Rb.AddForce(-transform.up * 45, ForceMode.Impulse);
        P2ImplaBlock.SetActive(true);
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

    void MissileTiming()
    {
        //音鳴らす
        //ScorpionSrc.Play();
        atomSrc.Play("Scorpion_Needle");
        //ミサイル発射タイミング
        GameObject Obj;
        Obj = Instantiate(ScorpionBullet, P2SetScorpion.transform.position, P2SetScorpion.transform.rotation) as GameObject;
    }

    void ScratchSound()
    {
        //音鳴らす
        //WolfSrc.Play();
        atomSrc.Play("Wolf_Scratch");
    }

    void ScratchEnable()
    {
        //オオカミの当たり判定
        P2WolfAtk.SetActive(true);

    }

    void ScratchUnable()
    {
        //オオカミの当たり判定を消す
        P2WolfAtk.SetActive(false);
    }

    void BiteSound()
    {
        //音鳴らす
        //LionSrc.Play();
        atomSrc.Play("Lion_Bite");
    }

    void BiteEnable()
    {
        //ライオンの当たり判定
        P2Lionhead.SetActive(true);
        
    }

    void BiteUnable()
    {
        //ライオンの当たり判定を消すタイミングをイベントで制御
        P2Lionhead.SetActive(false);
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

    void DelayArma()
    {
        ArmadilloSwitch = true;
    }

    void DelayHorse()
    {
        HorseSwitch = true;
    }

    void KickEnable()
    {
        P2HorseLeg.SetActive(true);
    }

    void KickUnable()
    {
        P2HorseLeg.SetActive(false);
    }

    void KuwagataUnable()
    {
        KuwagataBlock.SetActive(false);
        Rb.isKinematic = false;
    }
    void DelayKuwagata()
    {
        KuwagataSwitch = true;
    }
    void NotFlying()
    {
        Flying = false;
    }
    Vector3 GetAngleVec(GameObject _from, GameObject _to)
    {
        //高さの概念を入れないベクトルを作る
        Vector3 fromVec = new Vector3(_from.transform.position.x, 0, _from.transform.position.z);
        Vector3 toVec = new Vector3(_to.transform.position.x, 0, _to.transform.position.z);
        return Vector3.Normalize(toVec - fromVec);
    }
    public static float GetP2HP()
    {
        return Player2HP;
    }
    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "floor")
        {
            //インパラ攻撃からStayに戻す
            ImpalaFinTiming();

            //ただのジャンプ
            NormalJump = false;
            Implajump = false;
            gameObject.layer = LayerMask.NameToLayer("NormalLayer");
            //インパラの攻撃のため
            if (AllActionInterval == true)
            {
                //P2のインパラブロックが表示されているとき
                if (P2ImplaBlock.activeSelf == true)
                {
                    P2ImplaWaveBlock.SetActive(true);
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
        if (other.gameObject.tag != "floor")
        {
            Rb.isKinematic = false;
        }
        if (Invincible == false)
        {


            if (Shield == true)
            {
                //シールドを張っているとき
                if (other.gameObject.CompareTag("P1LionAttack"))
                {
                    ShieldPoint -= 0.3f;
                    //ダメを食らう時の半分ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, this.gameObject);
                    Rb.AddForce(ToVec * 15, ForceMode.Impulse);
                    //無敵タイム開始 当たり判定が連続しないように
                    Invincible = true;
                    Invoke("InvincibleTime", 0.3f);
                    //音鳴らす
                    //AnimalShieldDmgSrc.Play();
                    atomSrc.Play("Animal_Shield_Dmg");
                }
                if (other.gameObject.CompareTag("P1Impla"))
                {
                    //ダメを食らう時の半分ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, this.gameObject);
                    Rb.AddForce(ToVec * 17, ForceMode.Impulse);
                    ShieldPoint -= 0.3f;
                    //無敵タイム開始 当たり判定が連続しないように
                    Invincible = true;
                    Invoke("InvincibleTime", 0.3f);
                    //音鳴らす
                    //AnimalShieldDmgSrc.Play();
                    atomSrc.Play("Animal_Shield_Dmg");
                }

                if (other.gameObject.CompareTag("P1ImplaWave"))
                {
                    //ダメを食らう時の半分ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, this.gameObject);
                    Rb.AddForce(ToVec * 15, ForceMode.Impulse);
                    ShieldPoint -= 0.1f;
                    //無敵タイム開始 当たり判定が連続しないように
                    Invincible = true;
                    Invoke("InvincibleTime", 0.3f);
                    //音鳴らす
                    //AnimalShieldDmgSrc.Play();
                    atomSrc.Play("Animal_Shield_Dmg");
                }
                //カエル、サソリ、オオカミ
                if (other.gameObject.CompareTag("P1FlogAttack"))
                {
                    //ダメを食らう時の半分ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, this.gameObject);
                    Rb.AddForce(ToVec * 13, ForceMode.Impulse);
                    ShieldPoint -= 0.01f;
                    //無敵タイム開始 当たり判定が連続しないように
                    Invincible = true;
                    Invoke("InvincibleTime", 0.3f);
                    //音鳴らす
                    //AnimalShieldDmgSrc.Play();
                    atomSrc.Play("Animal_Shield_Dmg");
                }
                if (other.gameObject.CompareTag("PoisonAttack"))
                {
                    //ダメを食らう時の半分ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, this.gameObject);
                    Rb.AddForce(ToVec * 12, ForceMode.Impulse);
                    ShieldPoint -= 0.03f;
                    //無敵タイム開始 当たり判定が連続しないように
                    Invincible = true;
                    Invoke("InvincibleTime", 0.3f);
                    //音鳴らす
                    //AnimalShieldDmgSrc.Play();
                    atomSrc.Play("Animal_Shield_Dmg");
                }
                if (other.gameObject.CompareTag("PoisonAttackBack"))
                {
                    //ダメを食らう時の半分ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, this.gameObject);
                    Rb.AddForce(ToVec * 13, ForceMode.Impulse);
                    ShieldPoint -= 0.036f;
                    //無敵タイム開始 当たり判定が連続しないように
                    Invincible = true;
                    Invoke("InvincibleTime", 0.3f);
                    //音鳴らす
                    //AnimalShieldDmgSrc.Play();
                    atomSrc.Play("Animal_Shield_Dmg");
                }
                if (other.gameObject.CompareTag("P1WolfAttack"))
                {
                    //ダメを食らう時の半分ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, this.gameObject);
                    Rb.AddForce(ToVec * 17, ForceMode.Impulse);
                    ShieldPoint -= 0.2f;
                    //無敵タイム開始 当たり判定が連続しないように
                    Invincible = true;
                    Invoke("InvincibleTime", 0.3f);
                    //音鳴らす
                    //AnimalShieldDmgSrc.Play();
                    atomSrc.Play("Animal_Shield_Dmg");
                }
                if (other.gameObject.CompareTag("P1ArmadilloAttack"))
                {
                    //ダメを食らう時の半分ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, this.gameObject);
                    Rb.AddForce(ToVec * 15, ForceMode.Impulse);
                    ShieldPoint -= 0.25f;
                    //無敵タイム開始 当たり判定が連続しないように
                    Invincible = true;
                    Invoke("InvincibleTime", 0.3f);
                    //音鳴らす
                    //AnimalShieldDmgSrc.Play();
                    //atomSrc.Play("Animal_Shield_Dmg");
                    atomSrc.Play("Animal_Shield_Dmg");
                }
                if (other.gameObject.CompareTag("P1HorseAttack"))
                {
                    //ダメを食らう時の半分ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, this.gameObject);
                    Rb.AddForce(ToVec * 15, ForceMode.Impulse);
                    ShieldPoint -= 0.25f;
                    //無敵タイム開始 当たり判定が連続しないように
                    Invincible = true;
                    Invoke("InvincibleTime", 0.3f);
                    //音鳴らす
                    //AnimalShieldDmgSrc.Play();
                    atomSrc.Play("Animal_Shield_Dmg");
                }
            }
            else
            {
                //ダメージの当たり判定
                if (other.gameObject.CompareTag("P1LionAttack"))
                {
                    Player2HP -= 30;
                    P2G.transform.position += new Vector3(HP10per * 3, 0, 0);
                    Bloodper = Random.Range(0, 10);
                    if (Bloodper == 0 || Bloodper == 1)
                    {
                        Bloodingtimer = 0;
                    }
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, this.gameObject);
                    Rb.AddForce(ToVec * 50, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                    P2ImplaBlock.SetActive(false);
                    //音鳴らす
                    //LionSrc.Play();
                    //AnimalDamage.Play();
                    atomSrc.Play("Animal_Damage");

                    //ふっとぶ
                    this.Animator.SetBool(isBlown, true);
                }
                if (other.gameObject.CompareTag("P1Impla"))
                {
                    Player2HP -= 30;
                    P2G.transform.position += new Vector3(HP10per * 3, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, this.gameObject);
                    Debug.Log(ToVec);
                    Rb.AddForce(ToVec * 60, ForceMode.Impulse);
                    P2ImplaBlock.SetActive(false);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);

                    //音鳴らす
                    atomSrc.Play("Impala_Attack");

                    //ふっとぶ
                    this.Animator.SetBool(isBlown, true);

                }
                if (other.gameObject.CompareTag("P1ImplaWave"))
                {
                    Player2HP -= 10;
                    P2G.transform.position += new Vector3(HP10per, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, this.gameObject);
                    Rb.AddForce(ToVec * 30, ForceMode.Impulse);
                    P2ImplaBlock.SetActive(false);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                    //音鳴らす
                    atomSrc.Play("Impala_Attack");

                    //ふっとぶ
                    this.Animator.SetBool(isBlown, true);
                }
                if (other.gameObject.CompareTag("P1WolfAttack"))
                {
                    Player2HP -= 20;
                    P2G.transform.position += new Vector3(HP10per * 2f, 0, 0);
                    Bloodper = Random.Range(0, 10);
                    if (Bloodper == 0 || Bloodper == 1)
                    {
                        Bloodingtimer = 0;
                    }
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, this.gameObject);
                    Rb.AddForce(ToVec * 40, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                    P2ImplaBlock.SetActive(false);
                    //音鳴らす
                    //AnimalDamage.Play();
                    atomSrc.Play("Animal_Damage");

                    //ふっとぶ
                    this.Animator.SetBool(isBlown, true);
                }
                if (other.gameObject.CompareTag("P1FlogAttack"))
                {
                    Player2HP -= 1;
                    P2G.transform.position += new Vector3(HP10per * 0.1f, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, this.gameObject);
                    Rb.AddForce(ToVec * 15, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 0.6f);
                    P2ImplaBlock.SetActive(false);
                    //音鳴らす
                    //FrogAtkSrc.Play();
                    atomSrc.Play("Frog_Attack");

                    //怯む
                    this.Animator.SetBool(isFalt, true);
                }
                if (other.gameObject.CompareTag("PoisonAttack"))
                {
                    Player2HP -= 3;
                    Poisontimer = 0;
                    P2G.transform.position += new Vector3(HP10per * 0.3f, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, this.gameObject);
                    Rb.AddForce(ToVec * 15, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 0.7f);
                    P2ImplaBlock.SetActive(false); 

                    //音鳴らす
                    //AnimalDamage.Play();
                    atomSrc.Play("Animal_Damage");

                    //怯む
                    this.Animator.SetBool(isFalt, true);
                }
                if (other.gameObject.CompareTag("P1ArmadilloAttack"))
                {
                    Player2HP -= 25;
                    P2G.transform.position += new Vector3(HP10per * 2.5f, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, this.gameObject);
                    Rb.AddForce(ToVec * 50, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                    P2ImplaBlock.SetActive(false);
                    //ふっとぶ
                    this.Animator.SetBool(isBlown, true);
                }
                if (other.gameObject.CompareTag("P1HorseAttack"))
                {
                    Player2HP -= 25;
                    P2G.transform.position += new Vector3(HP10per * 2.5f, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, this.gameObject);
                    Rb.AddForce(ToVec * 50, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                    P2ImplaBlock.SetActive(false);
                    //ふっとぶ
                    this.Animator.SetBool(isBlown, true);
                }
                //カウンターダメージ用
                if (other.gameObject.CompareTag("P2LionAttackBack"))
                {
                    Player2HP -= 36;
                    P2G.transform.position += new Vector3(HP10per * 3 * 1.2f, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, this.gameObject);
                    Rb.AddForce(ToVec * 55, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);

                }
                if (other.gameObject.CompareTag("P2ImplaBack"))
                {
                    Player2HP -= 36;
                    P2G.transform.position += new Vector3(HP10per * 3 * 1.2f, 0, 0);
                    Vector3 ToVec = GetAngleVec(other.gameObject, P2ImplaBlock);

                    Rb.AddForce(ToVec * 60, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                    P2ImplaBlock.SetActive(false);
                }
                if (other.gameObject.CompareTag("P2ImplaWaveBack"))
                {
                    Player2HP -= 12;
                    P2G.transform.position += new Vector3(HP10per * 1.2f, 0, 0);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                    P2ImplaBlock.SetActive(false);
                }
                if (other.gameObject.CompareTag("P2FlogAttackBack"))
                {
                    Player2HP -= 1.2f;
                    P2G.transform.position += new Vector3(HP10per * 0.12f, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, this.gameObject);
                    Rb.AddForce(ToVec * 20, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 0.5f);
                }
                //オオカミのカウンターのタグに切り替えが未実装
                if (other.gameObject.CompareTag("P2WolfAttackBack"))
                {
                    Player2HP -= 22;
                    P2G.transform.position += new Vector3(HP10per * 2.2f, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, this.gameObject);
                    Rb.AddForce(ToVec * 55, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);

                }
                if (other.gameObject.CompareTag("PoisonAttackBack"))
                {
                    Player2HP -= 3.6f;
                    Poisontimer = 0;
                    P2G.transform.position += new Vector3(HP10per * 3.6f, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, this.gameObject);
                    Rb.AddForce(ToVec * 16, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);

                }
                if (other.gameObject.CompareTag("Gard") && this.tag == "P2ArmadilloAttack")
                {
                    Player2HP -= 30;
                    P2G.transform.position += new Vector3(HP10per * 3f, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, this.gameObject);
                    Rb.AddForce(ToVec * 60, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                }
                if (other.gameObject.CompareTag("P2HorseAttackBack"))
                {
                    Player2HP -= 30;
                    P2G.transform.position += new Vector3(HP10per * 3f, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, this.gameObject);
                    Rb.AddForce(ToVec * 60, ForceMode.Impulse);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                }
            }
            if (other.gameObject.CompareTag("P1KuwagataAttack"))
            {
                Player2HP -= 30;
                P2G.transform.position += new Vector3(HP10per * 3, 0, 0);
                //ノックバック
                Vector3 ToVec = GetAngleVec(this.gameObject, other.gameObject);
                Rb.AddForce(ToVec * 60, ForceMode.Impulse);
                Flying = true;
                Invoke("NotFlying", 0.7f);
                //無敵タイム開始
                AllActionInterval = true;
                //行動停止
                Invoke("ActionInterval", 1.2f);
                //音鳴らす
                //AnimalDamage.Play();
                atomSrc.Play("Animal_Damage");
            }
        }
        else
        {
            this.Animator.SetBool(isFalt, false);
            this.Animator.SetBool(isBlown, false);
        }
    }
}