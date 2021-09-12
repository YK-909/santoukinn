using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyconPlay1 : MonoBehaviour
{
    //体力
    public static float Player1HP = 100;
    //スタートの合図のため
    private int Gamemode = 0;

    //キャラ変更
    //1=ライオン 2=カエル
    public int Head = 0;
    //1=カメ 1=サソリ
    public int Body = 0;
    //1=インパラ 1=オオカミ
    public int Leg = 0;
    //外装
    //2=加速　吸血＝3
    public int Exterior = 0;
    //移動速度
    private float Speed = 40.0f;
    private Vector3 Direction;

    //シールド　※カメとの変数に注意　調整中無視していいよ
    private bool Shield = false;
    public GameObject ShieldObj;
    [Range(0f, 1f)]
    private float ShieldPoint = 1.0f;
    public GameObject Shield_Blue;
    public GameObject Shield_Yellow;
    public GameObject Shield_Red;

    //普通のジャンプ
    private bool NormalJump = false;

    //HPバーの生成
    public GameObject P1G;
    public GameObject P1R;
    //座標からHPが10ごと減少した際の値
    private float HP10per = -34.7f;

    //無敵時間の生成
    private bool Invincible = false;

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

    //ライオンの攻撃
    public GameObject P1Lionhead;
    private bool LionSwitch = true;
    //出血について
    private float Bloodingtimer = 5;
    private float Bloodingtime = 5;
    private int Bloodper;

    //カメのカウンター
    public GameObject P1TurtleGard;
    public GameObject P2TurtleCounter;
    private bool Gard = true;
    private Vector3 Poseposition = new Vector3();

    //インパラののジャンプ攻撃
    private bool Implajump = false;
    private Rigidbody Rb;
    public GameObject P1ImplaBlock;
    public GameObject P1ImplaWaveBlock;

    public GameObject shockWave;

    //アルマジロの攻撃
    private float ArmadilloSpeed = 0.0f;
    private int ArmadilloMode = 0;
    private bool ArmadilloSwitch = true;
    public GameObject ArmadilloBlock;
    private bool OnceArma = true;

    //馬の攻撃
    public GameObject P1HorseLeg;
    private bool HorseSwitch = true;

    //クワガタの攻撃
    public GameObject KuwagataBlock;
    private bool KuwagataSwitch = true;
    private Vector3 KuwagataVec;

    private bool AllActionInterval = false;
    private bool CalledOncePoint = false;

    //加速するための
    private float BuffSpeed = 1.0f;
    //外部に数値を持っていく
    private static int BuffCountP1 = 3;
    public float BuffTimer = 0;

    //吸血
    private float DamageHP1=0;
    private static float EnemyHP_2 =100;
    public GameObject P2G;
    public GameObject P2R;

    //キャラの向きを常に一定に
    private GameObject EnemyObj;
    private Vector3 Enemy;

    //エフェクト
    public GameObject HitEff;
    public GameObject Speedup;
    public GameObject Wing;
    public GameObject HealEffect;
    private bool isDrain;

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
    public CriAtomSource WolfFS;
    public CriAtomSource ImpalaFS;
    public CriAtomSource HorseFS;

    //アニメーター
    private Animator Animator;

    //共通アニメーション
    private string isWalk = "isWalk";
    private string isRun = "isRun";
    private string isJump = "isJump";
    private string isFalt = "isFalt";
    private string isBlown = "isBlown";
    private string isShield = "isShield";
    private string isDown = "isDown";

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
        P1Lionhead.SetActive(false);
        P1TurtleGard.SetActive(false);
        P1WolfAtk.SetActive(false);
        Rb = GetComponent<Rigidbody>();
        Rb.isKinematic = true;
        EnemyObj = GameObject.Find("P2camera");
        ShieldObj.SetActive(false);

        EnemyHP_2 = 100;
        Player1HP = 100;
        if (Exterior == 2)
        {
            BuffSpeed = 0.8f;
        }
        BuffCountP1 = 3;

        Animator = GetComponent<Animator>();

        atomSrc = (CriAtomSource)GetComponent<CriAtomSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Gamemode = Timer.GetGamemode();
        P1TurtleGard.transform.position = this.transform.position + transform.forward * 5 + transform.up * -2; 
        DamageHP1 = 0;
        if (P1TurtleGard.activeSelf == true)
        {
            this.transform.position = new Vector3(Poseposition.x, Poseposition.y, Poseposition.z);
        }

        //通常のダウンの音鳴らす
        if (Animator.GetCurrentAnimatorStateInfo(0).IsName("Blown"))
        {
            //音鳴らす
            atomSrc.Play("Down");
        }

        if (Gamemode == 1)
        {
            if (AllActionInterval == false)
            {
                if (Exterior == 3)
                {
                    Player1HP = KeybordPlay2.GetP1HP();
                }
                    EnemyHP_2 = KeybordPlay2.GetP2HP();
                //重力とは別な上からの力　要調整
                Rb.AddForce(new Vector3(0, -30, 0), ForceMode.Force);

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
                            if (ArmadilloSpeed <= 0)
                            {
                                if (NormalJump == false)
                                {
                                    Speed = 40.0f;
                                }
                                else
                                {
                                    Speed = 15f;
                                }

                                Direction.Set(Input.GetAxis("Horizontal1"), 0, Input.GetAxis("Vertical1"));
                                if (Direction != Vector3.zero)
                                {
                                    //向きを指定
                                    transform.rotation = Quaternion.LookRotation(Direction);
                                    if (Speed == 40.0)
                                    {
                                        //スピードアップしている時
                                        if (BuffSpeed == 1.5f)
                                        {
                                            //音鳴らす
                                            atomSrc.Play("Speed_UP_Wing");
                                        }
                                        //以下通常時
                                        //インパラの足音
                                        else if (Leg == 1)
                                        {
                                            //音鳴らす
                                            //AnimalFSSrc.Play();
                                            //atomSrc.Play("Impala_GFootsteps");
                                            ImpalaFS.Play();
                                        }

                                        //狼の足音
                                        else if (Leg == 2)
                                        {
                                            //音鳴らす
                                            //AnimalFSSrc.Play();
                                            //atomSrc.Play("Garden_Footsteps");
                                            WolfFS.Play();
                                        }

                                        //馬の足音
                                        else if (Leg == 3)
                                        {
                                            //音鳴らす
                                            //AnimalFSSrc.Play();
                                            //atomSrc.Play("Horse_GFootsteps");
                                            HorseFS.Play();
                                        }
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
                                //前方に移動する
                                transform.position += Direction * Speed * BuffSpeed * Time.deltaTime;
                            }
                        }

                        if (Invincible == false)
                        {
                            if (NormalJump == false)
                            {

                                if (Head == 1)
                                {
                                    //カエル
                                    if (Input.GetKeyDown(KeyCode.Joystick1Button0))
                                    {
                                        if (FlogSwitch == true)
                                        {
                                            //音鳴らす
                                            //FrogSwingSrc.Play();
                                            atomSrc.Play("Frog_Swing");
                                            //FrogAtkVoSrc.Play();

                                            P1FlogTongue.SetActive(true);
                                            P1FlogAnimator.SetTrigger("FlogAtkStartP1");
                                            P1FlogAnimator.SetBool("FlogAtkFinP1", false);
                                            FlogSwitch = false;

                                            //舌攻撃
                                            this.Animator.SetBool(isTongueStr, true);
                                            this.Animator.SetBool(isTongueFin, false);
                                        }
                                    }
                                    if (Input.GetKeyUp(KeyCode.Joystick1Button0))
                                    {
                                        if (FlogSwitch == false)
                                        {
                                            P1FlogAnimator.SetBool("FlogAtkFinP1", true);
                                            //オブジェクトが消える時間
                                            Invoke("DelayFlog", 1.5f);
                                            AllActionInterval = true;
                                            //行動停止
                                            Invoke("ActionInterval", 2.65f);

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
                                    // ライオン
                                    if (Input.GetKeyDown(KeyCode.Joystick1Button0))
                                    {
                                        if (LionSwitch == true)
                                        {
                                            //音鳴らす
                                            //LionAtkVoSrc.Play();
                                            atomSrc.Play("LionAtkVo");
                                            Invoke("BiteSound", 0.6f);

                                            AllActionInterval = true;
                                            P1Lionhead.tag = "P1LionAttack";
                                            Rb.AddForce(transform.forward * 30f, ForceMode.Impulse);
                                            LionSwitch = false;
                                            //行動停止
                                            Invoke("ActionInterval", 0.8f);
                                            //リキャストタイム
                                            Invoke("DelayLion", 1.25f);

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
                                else if (Head == 3)
                                {
                                    //クワガタの攻撃
                                    if (KuwagataSwitch == true)
                                    {
                                        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
                                        {
                                            KuwagataSwitch = false;
                                            AllActionInterval = true;
                                            KuwagataBlock.tag = "P1KuwagataAttack";
                                            KuwagataBlock.SetActive(true);
                                            Rb.isKinematic = true;
                                            //音鳴らす
                                            atomSrc.Play("Stag_Grab");
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
                                        //カメ
                                        if (Input.GetKeyUp(KeyCode.Joystick1Button3))
                                        {

                                            if (Gard == true)
                                            {
                                                //音鳴らす
                                                //TurtleShieldOPSrc.Play();
                                                atomSrc.Play("Turtle_Shield");

                                                AllActionInterval = true;
                                                P1TurtleGard.SetActive(true);
                                                Gard = false;
                                                //無敵タイム開始
                                                Invincible = true;
                                                Poseposition = this.transform.position;
                                                //無敵時間
                                                Invoke("InvincibleTime", 2f);
                                                //上と同じ値
                                                Invoke("TurtleGardRemove", 2f);
                                                //行動停止
                                                Invoke("ActionInterval", 2.3f);
                                                //リキャストタイム
                                                Invoke("DelayTartle", 3.2f);

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
                                            if (Input.GetKey(KeyCode.Joystick1Button3))
                                            {
                                                //音鳴らす
                                                //ScorpionSrc.Play();

                                                AllActionInterval = true;
                                                Enemy = new Vector3(EnemyObj.transform.position.x, this.transform.position.y, EnemyObj.transform.position.z);
                                                transform.LookAt(Enemy);
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
                                                if (Input.GetKey(KeyCode.Joystick1Button3))
                                                {
                                                    Debug.Log(ArmadilloSpeed);
                                                    if (ArmadilloSpeed < 30)
                                                    {
                                                        ArmadilloSpeed += 10 * Time.deltaTime;
                                                    }

                                                    //ローリングアタック
                                                    this.Animator.SetBool(isRollStr, true);
                                                    this.Animator.SetBool(isRollFin, false);

                                                    //音鳴らす
                                                    atomSrc.Play("Armadillo_Roll");
                                                }
                                                if (Input.GetKeyUp(KeyCode.Joystick1Button3))
                                                {
                                                    ArmadilloMode = 1;

                                                    this.Animator.SetBool(isRollStr, false);
                                                }
                                            }
                                            else if (ArmadilloMode == 1)
                                            {
                                                if (ArmadilloSpeed > 0)
                                                {
                                                    if (OnceArma == true)
                                                    {
                                                        ArmadilloSpeed += 50;
                                                        OnceArma = false;
                                                    }
                                                    ArmadilloBlock.SetActive(true);
                                                    ArmadilloBlock.tag = "P1ArmadilloAttack";
                                                    ArmadilloSpeed += -20 * Time.deltaTime;
                                                    transform.position += transform.forward * 50 * Time.deltaTime;
                                                    if (Direction.x > 0)
                                                    {
                                                        //右に回転
                                                        transform.Rotate(0, 10 * Time.deltaTime, 0);
                                                    }
                                                    if (Direction.x < 0)
                                                    {
                                                        //左に回転
                                                        transform.Rotate(0, -10 * Time.deltaTime, 0);
                                                    }
                                                }
                                                else
                                                {
                                                    OnceArma = true;
                                                    this.Animator.SetBool(isRollFin, true);
                                                    ArmadilloBlock.SetActive(false);
                                                    ArmadilloMode = 0;
                                                    //オブジェクトが消える時間
                                                    ArmadilloSwitch = false;
                                                    Invoke("DelayArma", 1.5f);
                                                    AllActionInterval = true;
                                                    //行動停止
                                                    Invoke("ActionInterval", 1.0f);
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
                                    if (Input.GetKeyDown(KeyCode.Joystick1Button2))
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
                                                Invoke("ImpleFreeze", 0.35f);
                                                Invoke("ActionInterval", 1.2f);

                                                Invoke("ImpalaAtkTiming", 0.5f);
                                                Invoke("ImpalaFinTiming", 1.5f);
                                            }
                                        }
                                        else if (Implajump == false)
                                        {
                                            Rb.AddForce(transform.up * 100, ForceMode.Impulse);
                                            Implajump = true;

                                            //インパラ攻撃
                                            this.Animator.SetBool(isImpalaAtkStr, true);
                                            this.Animator.SetBool(isImpalaAtkCont, false);
                                            this.Animator.SetBool(isImpalaAtkFin, false);

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
                                    if (Input.GetKey(KeyCode.Joystick1Button2))
                                    {
                                        if (WolfSwitch == true)
                                        {
                                            //音鳴らす
                                            //WolfSrc.Play();
                                            Invoke("ScratchSound", 0.5f);

                                            AllActionInterval = true;
                                            P1WolfAtk.tag = "P1WolfAttack";
                                            Rb.AddForce(transform.forward * 60f, ForceMode.Impulse);
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
                                    if (Input.GetKeyDown(KeyCode.Joystick1Button2))
                                    {

                                        if (HorseSwitch == true)
                                        {
                                            //音鳴らす
                                            atomSrc.Play("Horse_Swing");

                                            AllActionInterval = true;
                                            P1HorseLeg.tag = "P1HorseAttack";
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

                                if (Exterior == 2)
                                {
                                    if (BuffSpeed != 1.5f && BuffCountP1 != 0)
                                    {
                                        if (Input.GetKey(KeyCode.Joystick1Button7))
                                        {
                                            BuffSpeed = 1.5f;
                                            BuffCountP1 -= 1;

                                            //スピードアップエフェクト
                                            GameObject SpeedObj;
                                            SpeedObj = Instantiate(Speedup, transform.position + transform.up * -7 + transform.forward * -2, transform.rotation) as GameObject;
                                            Speedup.transform.localScale = new Vector3(5.0f, 5.0f, 5.0f);
                                            Destroy(SpeedObj, 1.6f);

                                            //音鳴らす
                                            atomSrc.Play("Speed_UP");

                                            Invoke("WingTiming", 0.5f);
                                        }
                                    }
                                }
                                else if (Exterior == 3)
                                {


                                }
                                else if (Exterior == 1)
                                {
                                   
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
                            if (Input.GetKey(KeyCode.Joystick1Button6))
                            {
                                //音鳴らす
                                //AnimalShieldOPSrc.Play();
                                atomSrc.Play("Animal_Shield_OP");

                                //シールド展開
                                this.Animator.SetBool(isShield, true);


                                if (FlogSwitch == true)
                                {
                                    Shield = true;
                                    Shield_Blue.transform.position = ShieldObj.transform.position;
                                    Shield_Yellow.transform.position = ShieldObj.transform.position;
                                    Shield_Red.transform.position = ShieldObj.transform.position;
                                    if (ShieldPoint > 0.6f)
                                    {
                                        Shield_Blue.SetActive(true);
                                        Shield_Yellow.SetActive(false);
                                        Shield_Red.SetActive(false);
                                    }
                                    if (0.6f >= ShieldPoint && ShieldPoint > 0.3f)
                                    {
                                        Shield_Blue.SetActive(false);
                                        Shield_Yellow.SetActive(true);
                                        Shield_Red.SetActive(false);
                                    }
                                    if (0.3f >= ShieldPoint && ShieldPoint > 0f)
                                    {
                                        Shield_Blue.SetActive(false);
                                        Shield_Yellow.SetActive(false);
                                        Shield_Red.SetActive(true);
                                    }
                                    if (ShieldPoint >= 0)
                                    {
                                        //シールドの減少量
                                        ShieldPoint -= 0.001f;
                                    }

                                }

                            }
                            else
                            {
                                Shield_Blue.SetActive(false);
                                Shield_Yellow.SetActive(false);
                                Shield_Red.SetActive(false);
                                //シールド
                                if (ShieldPoint <= 1)
                                {
                                    //シールドの回復速度
                                    ShieldPoint += 0.001f;
                                }
                            }
                            //ガードのボタンを離したとき　後隙
                            if (Input.GetKeyUp(KeyCode.Joystick1Button6))
                            {
                                ShieldObj.SetActive(false);
                                Invoke("ShieldDelay", 0.25f);
                                this.Animator.SetBool(isShield, false);
                            }
                            if (Shield == false)
                            {
                                if (Input.GetKey(KeyCode.Joystick1Button1))
                                {
                                    if (FlogSwitch == true)
                                    {
                                        Rb.AddForce(transform.up * 60, ForceMode.Impulse);
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
            Player1HP = 100;
        }

        if (BuffSpeed > 1)
        {
            BuffTimer += Time.deltaTime;
            Debug.Log(BuffTimer);
            if (BuffTimer > 5)
            {
                BuffSpeed = 0.8f;
                Wing.SetActive(false);
            }
        }
        else
        {
            BuffTimer = 0;
        }

        if (Poisontimer < Poisoningtime)
        {
            Poisontimer += Time.deltaTime;
            Player1HP -= Time.deltaTime;
            P1G.transform.position += new Vector3(HP10per * (0.1f * Time.deltaTime), 0, 0);
        }

        if (Bloodingtimer < Bloodingtime)
        {
            Bloodingtimer += Time.deltaTime;
            Player1HP -= Time.deltaTime;
            P1G.transform.position += new Vector3(HP10per * (0.1f * Time.deltaTime), 0, 0);
        }

        //HPの継続的な減少
        if (P1G.transform.position.x < P1R.transform.position.x)
        {
            P1R.transform.position -= new Vector3(10f, 0, 0) * Time.deltaTime;
        }

        //シールドブレイク
        if (ShieldPoint <= 0)
        {
            Shield_Blue.SetActive(false);
            Shield_Yellow.SetActive(false);
            Shield_Red.SetActive(false);
            AllActionInterval = true;
            Shield = false;
            this.Animator.SetBool(isShield, false);
            //何もできない待機時間
            Invoke("ActionInterval", 3f);
            //上と同じ値で　シールドが壊れた時の対応
            Invoke("ShieldBreak", 3f);

            //音鳴らす
            //AnimalShieldDstSrc.Play();
            atomSrc.Play("Animal_Shield_Dst");
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
        Rb.AddForce(-transform.up * 60, ForceMode.Impulse);
        P1ImplaBlock.SetActive(true);
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
        //カエルの攻撃途中の時に被ダメした用
        P1FlogAnimator.SetBool("FlogAtkFinP1", true);
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
        ArmadilloSpeed = 0;
    }

    void MissileTiming()
    {
        //音鳴らす
        //ScorpionSrc.Play();
        atomSrc.Play("Scorpion_Needle");
        //ミサイル発射タイミング
        GameObject Obj;
        Obj = Instantiate(P1ScorpionBullet, P1SetScorpion.transform.position, P1SetScorpion.transform.rotation) as GameObject;
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
        P1WolfAtk.SetActive(true);

    }

    void ScratchUnable()
    {
        //オオカミの当たり判定を消す
        P1WolfAtk.SetActive(false);
    }

    void BiteSound()
    {
        //音鳴らす
        //LionSrc.Play();
        //atomSrc.Play("Lion_Bite");
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
    public void ImpShockWave()
    {
        GameObject Obj;
        Obj = Instantiate(shockWave, transform.position + transform.up * -10 + transform.forward * -2, transform.rotation) as GameObject;
        Obj.transform.localScale = new Vector3(12.0f, 12.0f, 12.0f);
        Destroy(Obj, 0.8f);
    }

    void WingTiming()
    {
        Wing.SetActive(true);
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
        P1HorseLeg.SetActive(true);
    }

    void KickUnable()
    {
        P1HorseLeg.SetActive(false);
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
  
    void KuwagataNock()
    {
        Rb.AddForce(KuwagataVec * 50, ForceMode.Impulse);
    }
    Vector3 GetAngleVec(GameObject _from, GameObject _to)
    {
        //高さの概念を入れないベクトルを作る
        Vector3 fromVec = new Vector3(_from.transform.position.x, 0, _from.transform.position.z);
        Vector3 toVec = new Vector3(_to.transform.position.x, 0, _to.transform.position.z);
        if (toVec - fromVec == new Vector3(0, 0, 0))
        {
            Vector3 Nock = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
            if (Nock.x == 0 && Nock.z == 0)
            {
                Nock.z = Random.Range(-10, -1);
            }
            return Vector3.Normalize(Nock);
        }
        else
        {
            return Vector3.Normalize(toVec - fromVec);
        }
    }
    void HPdrain()
    {
        if (ContlolePassive2.GetPassive2() == 3)
        {
            if (EnemyHP_2 + (DamageHP1 / 10) < 100)
            {
                EnemyHP_2 += DamageHP1 / 5;
                P2G.transform.position += new Vector3(HP10per * (DamageHP1 / 100), 0, 0);
                P2R.transform.position += new Vector3(HP10per * (DamageHP1 / 100), 0, 0);
                //音鳴らす
                atomSrc.Play("Healing");

                isDrain = true;

            }
        }
    }
    public static float GetP2HP()
    {
        return EnemyHP_2;
    }
    public static int GetBuffCountP1()
    {
        return BuffCountP1;
    }
    public static float GetP1HP()
    {
        return Player1HP;
    }

    private void BlownOff()
    {
        this.Animator.SetBool(isBlown, false);
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
        if (other.gameObject.tag != "floor")
        {
            Rb.isKinematic = false;
            ArmadilloSpeed = 0;
        }
        if (Invincible == false)
        {
            if (Shield == true)
            {
                //シールドを張っているとき
                if (other.gameObject.CompareTag("P2LionAttack"))
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
                if (other.gameObject.CompareTag("P2Impla"))
                {
                    //ダメを食らう時の半分ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, this.gameObject);
                    Rb.AddForce(ToVec * 17, ForceMode.Impulse);
                    ShieldPoint -= 0.3f;
                    //無敵タイム開始 当たり判定が連続しないように
                    Invincible = true;
                    Invoke("InvincibleTime", 0.3f);
                    //AnimalShieldDmgSrc.Play();
                    atomSrc.Play("Animal_Shield_Dmg");
                }

                if (other.gameObject.CompareTag("P2ImplaWave"))
                {
                    //ダメを食らう時の半分ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, this.gameObject);
                    Rb.AddForce(ToVec * 15, ForceMode.Impulse);
                    ShieldPoint -= 0.1f;
                    //無敵タイム開始 当たり判定が連続しないように
                    Invincible = true;
                    Invoke("InvincibleTime", 0.3f);
                    //AnimalShieldDmgSrc.Play();
                    atomSrc.Play("Animal_Shield_Dmg");
                }
                //カエル、サソリ、オオカミ
                if (other.gameObject.CompareTag("P2FlogAttack"))
                {
                    //ダメを食らう時の半分ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, this.gameObject);
                    Rb.AddForce(ToVec * 13, ForceMode.Impulse);
                    ShieldPoint -= 0.015f;
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
                    //AnimalShieldDmgSrc.Play();
                    atomSrc.Play("Animal_Shield_Dmg");
                }
                if (other.gameObject.CompareTag("P2WolfAttack"))
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
                if (other.gameObject.CompareTag("P2ArmadilloAttack"))
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
                if (other.gameObject.CompareTag("P2HorseAttack"))
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
                if (other.gameObject.CompareTag("P2LionAttack"))
                {
                    Player1HP -= 22;
                    DamageHP1 = 22;
                    HPdrain();
                    P1G.transform.position += new Vector3(HP10per * 3, 0, 0);
                    Bloodper = Random.Range(0, 10);
                    if (Bloodper == 0 || Bloodper == 1)
                    {
                        Bloodingtimer = 0;
                    }
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, this.gameObject);
                    Rb.AddForce(ToVec * 50, ForceMode.Impulse);
                    //行動停止
                    AllActionInterval = true;
                    Invoke("ActionInterval", 1.1f);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                    P1ImplaBlock.SetActive(false);
                    //音鳴らす
                    //LionSrc.Play();
                    //AnimalDamage.Play();
                    atomSrc.Play("Animal_Damage");
                    DelayFlog();

                    //ふっとぶ
                    this.Animator.SetBool(isBlown, true);
                    //最後の一撃
                    if (JoyconPlay1.GetP1HP() <= 0)
                    {
                        this.Animator.SetBool(isDown, true);
                        //音鳴らす
                        atomSrc.Play("Down_Finish");
                    }

                    //ヒットエフェクト
                    GameObject Hit;
                    Hit = Instantiate(HitEff, transform.position + transform.forward * 4 + transform.up * 1.8f, transform.rotation) as GameObject;
                    Hit.transform.localScale = new Vector3(3.0f, 3.0f, 3.0f);

                    if (isDrain == true)
                    {
                        GameObject HealObj;
                        HealObj = Instantiate(HealEffect, other.transform.position + other.transform.forward * -2 + other.transform.up * 3.5f, Quaternion.identity);
                        HealObj.transform.localScale = new Vector3(5.0f, 5.0f, 5.0f);
                        Destroy(HealObj, 0.8f);
                    }
                }
                if (other.gameObject.CompareTag("P2Impla"))
                {
                    Player1HP -= 30;
                    DamageHP1 = 30;
                    HPdrain();
                    P1G.transform.position += new Vector3(HP10per * 3, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, this.gameObject);
                    Debug.Log(ToVec);
                    Rb.AddForce(ToVec * 60, ForceMode.Impulse);
                    //行動停止
                    AllActionInterval = true;
                    Invoke("ActionInterval", 1.1f);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                    P1ImplaBlock.SetActive(false);
                    //音鳴らす
                    atomSrc.Play("Impala_Attack");
                    DelayFlog();

                    //ふっとぶ
                    this.Animator.SetBool(isBlown, true);
                    //最後の一撃
                    if (JoyconPlay1.GetP1HP() <= 0)
                    {
                        this.Animator.SetBool(isDown, true);
                        //音鳴らす
                        atomSrc.Play("Down_Finish");
                    }

                    //ヒットエフェクト
                    GameObject Hit;
                    Hit = Instantiate(HitEff, transform.position + transform.forward * 4 + transform.up * 1.8f, transform.rotation) as GameObject;
                    Hit.transform.localScale = new Vector3(3.0f, 3.0f, 3.0f);

                    if (isDrain == true)
                    {
                        GameObject HealObj;
                        HealObj = Instantiate(HealEffect, other.transform.position + other.transform.forward * -2 + other.transform.up * 3.5f, Quaternion.identity);
                        HealObj.transform.localScale = new Vector3(5.0f, 5.0f, 5.0f);
                        Destroy(HealObj, 0.8f);
                    }
                }
                if (other.gameObject.CompareTag("P2ImplaWave"))
                {
                    Player1HP -= 30;
                    DamageHP1 = 10;
                    HPdrain();
                    P1G.transform.position += new Vector3(HP10per, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, this.gameObject);
                    Rb.AddForce(ToVec * 30, ForceMode.Impulse);
                    //行動停止
                    AllActionInterval = true;
                    Invoke("ActionInterval", 1.1f);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                    P1ImplaBlock.SetActive(false);
                    //音鳴らす
                    atomSrc.Play("Impala_Attack");
                    DelayFlog();

                    //ふっとぶ
                    this.Animator.SetBool(isBlown, true);
                    //最後の一撃
                    if (JoyconPlay1.GetP1HP() <= 0)
                    {
                        this.Animator.SetBool(isDown, true);
                        //音鳴らす
                        atomSrc.Play("Down_Finish");
                    }

                    //ヒットエフェクト
                    GameObject Hit;
                    Hit = Instantiate(HitEff, transform.position + transform.forward * 4 + transform.up * 1.8f, transform.rotation) as GameObject;
                    Hit.transform.localScale = new Vector3(3.0f, 3.0f, 3.0f);

                    if (isDrain == true)
                    {
                        GameObject HealObj;
                        HealObj = Instantiate(HealEffect, other.transform.position + other.transform.forward * -2 + other.transform.up * 3.5f, Quaternion.identity);
                        HealObj.transform.localScale = new Vector3(5.0f, 5.0f, 5.0f);
                        Destroy(HealObj, 0.8f);
                    }
                }
                if (other.gameObject.CompareTag("P2WolfAttack"))
                {
                    Player1HP -= 20;
                    DamageHP1 = 20;
                    HPdrain();
                    P1G.transform.position += new Vector3(HP10per * 2f, 0, 0);
                    Bloodper = Random.Range(0, 10);
                    if (Bloodper == 0 || Bloodper == 1)
                    {
                        Bloodingtimer = 0;
                    }
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, this.gameObject);
                    Rb.AddForce(ToVec * 40, ForceMode.Impulse);
                    //行動停止
                    AllActionInterval = true;
                    Invoke("ActionInterval", 1.1f);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                    P1ImplaBlock.SetActive(false);
                    //音鳴らす
                    //AnimalDamage.Play();
                    atomSrc.Play("Animal_Damage");
                    DelayFlog();

                    //ふっとぶ
                    this.Animator.SetBool(isBlown, true);
                    //最後の一撃
                    if (JoyconPlay1.GetP1HP() <= 0)
                    {
                        this.Animator.SetBool(isDown, true);
                        //音鳴らす
                        atomSrc.Play("Down_Finish");
                    }

                    //ヒットエフェクト
                    GameObject Hit;
                    Hit = Instantiate(HitEff, transform.position + transform.forward * 4 + transform.up * 1.8f, transform.rotation) as GameObject;
                    Hit.transform.localScale = new Vector3(3.0f, 3.0f, 3.0f);

                    if (isDrain == true)
                    {
                        GameObject HealObj;
                        HealObj = Instantiate(HealEffect, other.transform.position + other.transform.forward * -2 + other.transform.up * 3.5f, Quaternion.identity);
                        HealObj.transform.localScale = new Vector3(5.0f, 5.0f, 5.0f);
                        Destroy(HealObj, 0.8f);
                    }

                }
                if (other.gameObject.CompareTag("P2FlogAttack"))
                {
                    Player1HP -= 1.5f;
                    DamageHP1 = 1.5f;
                    HPdrain();
                    P1G.transform.position += new Vector3(HP10per * 0.15f, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, this.gameObject);
                    Rb.AddForce(ToVec * 15, ForceMode.Impulse);
                    //行動停止
                    AllActionInterval = true;
                    Invoke("ActionInterval", 0.3f);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 0.6f);
                    P1ImplaBlock.SetActive(false);
                    //音鳴らす
                    //FrogAtkSrc.Play();
                    atomSrc.Play("Frog_Attack");
                    DelayFlog();

                    //怯む
                    this.Animator.SetBool(isFalt, true);
                    //最後の一撃
                    if (JoyconPlay1.GetP1HP() <= 0)
                    {
                        this.Animator.SetBool(isDown, true);
                        //音鳴らす
                        atomSrc.Play("Down_Finish");
                    }

                    //ヒットエフェクト
                    GameObject Hit;
                    Hit = Instantiate(HitEff, transform.position + transform.forward * 4 + transform.up * 1.8f, transform.rotation) as GameObject;
                    Hit.transform.localScale = new Vector3(3.0f, 3.0f, 3.0f);

                    if (isDrain == true)
                    {
                        GameObject HealObj;
                        HealObj = Instantiate(HealEffect, other.transform.position + other.transform.forward * -2 + other.transform.up * 3.5f, Quaternion.identity);
                        HealObj.transform.localScale = new Vector3(5.0f, 5.0f, 5.0f);
                        Destroy(HealObj, 0.8f);
                    }
                }
                if (other.gameObject.CompareTag("PoisonAttack"))
                {
                    Player1HP -= 3;
                    DamageHP1 = 3;
                    HPdrain();
                    Poisontimer = 0;
                    P1G.transform.position += new Vector3(HP10per * 0.3f, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, this.gameObject);
                    Rb.AddForce(ToVec * 15, ForceMode.Impulse);
                    //行動停止
                    AllActionInterval = true;
                    Invoke("ActionInterval", 0.3f);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 0.5f);
                    P1ImplaBlock.SetActive(false);
                    //音鳴らす
                    //AnimalDamage.Play();
                    atomSrc.Play("Animal_Damage");
                    DelayFlog();

                    //怯む
                    this.Animator.SetBool(isFalt, true);
                    //最後の一撃
                    if (JoyconPlay1.GetP1HP() <= 0)
                    {
                        this.Animator.SetBool(isDown, true);
                        //音鳴らす
                        atomSrc.Play("Down_Finish");
                    }

                    //ヒットエフェクト
                    GameObject Hit;
                    Hit = Instantiate(HitEff, transform.position + transform.forward * 4 + transform.up * 1.8f, transform.rotation) as GameObject;
                    Hit.transform.localScale = new Vector3(3.0f, 3.0f, 3.0f);

                    if (isDrain == true)
                    {
                        GameObject HealObj;
                        HealObj = Instantiate(HealEffect, other.transform.position + other.transform.forward * -2 + other.transform.up * 3.5f, Quaternion.identity);
                        HealObj.transform.localScale = new Vector3(5.0f, 5.0f, 5.0f);
                        Destroy(HealObj, 0.8f);
                    }
                }
                if (other.gameObject.CompareTag("P2ArmadilloAttack"))
                {
                    Player1HP -= 25;
                    DamageHP1 = 25;
                    HPdrain();
                    P1G.transform.position += new Vector3(HP10per * 2.5f, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, this.gameObject);
                    Rb.AddForce(ToVec * 50, ForceMode.Impulse);
                    P1ImplaBlock.SetActive(false);
                    //行動停止
                    AllActionInterval = true;
                    Invoke("ActionInterval", 1.1f);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                    //音鳴らす
                    atomSrc.Play("Armadillo_Hit");
                    DelayFlog();

                    //ふっとぶ
                    this.Animator.SetBool(isBlown, true);
                    Invoke("BlownOff", 1.1f);
                    //最後の一撃
                    if (JoyconPlay1.GetP1HP() <= 0)
                    {
                        this.Animator.SetBool(isDown, true);
                        //音鳴らす
                        atomSrc.Play("Down_Finish");
                    }

                    //ヒットエフェクト
                    GameObject Hit;
                    Hit = Instantiate(HitEff, transform.position + transform.forward * 4 + transform.up * 1.8f, transform.rotation) as GameObject;
                    Hit.transform.localScale = new Vector3(3.0f, 3.0f, 3.0f);

                    if (isDrain == true)
                    {
                        GameObject HealObj;
                        HealObj = Instantiate(HealEffect, other.transform.position + other.transform.forward * -2 + other.transform.up * 3.5f, Quaternion.identity);
                        HealObj.transform.localScale = new Vector3(5.0f, 5.0f, 5.0f);
                        Destroy(HealObj, 0.8f);
                    }
                }
                if (other.gameObject.CompareTag("P2HorseAttack"))
                {
                    Player1HP -= 25;
                    DamageHP1 = 25;
                    HPdrain();
                    P1G.transform.position += new Vector3(HP10per * 2.5f, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, this.gameObject);
                    Rb.AddForce(ToVec * 50, ForceMode.Impulse);
                    P1ImplaBlock.SetActive(false);
                    //行動停止
                    AllActionInterval = true;
                    Invoke("ActionInterval", 1.1f);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                    //音鳴らす
                    atomSrc.Play("Horse_Kick");
                    DelayFlog();

                    //ふっとぶ
                    this.Animator.SetBool(isBlown, true);
                    //最後の一撃
                    if (JoyconPlay1.GetP1HP() <= 0)
                    {
                        this.Animator.SetBool(isDown, true);
                        //音鳴らす
                        atomSrc.Play("Down_Finish");
                    }

                    //ヒットエフェクト
                    GameObject Hit;
                    Hit = Instantiate(HitEff, transform.position + transform.forward * 4 + transform.up * 1.8f, transform.rotation) as GameObject;
                    Hit.transform.localScale = new Vector3(3.0f, 3.0f, 3.0f);

                    if (isDrain == true)
                    {
                        GameObject HealObj;
                        HealObj = Instantiate(HealEffect, other.transform.position + other.transform.forward * -2 + other.transform.up * 3.5f, Quaternion.identity);
                        HealObj.transform.localScale = new Vector3(5.0f, 5.0f, 5.0f);
                        Destroy(HealObj, 0.8f);
                    }
                }

                //カウンターダメージ用
                if (other.gameObject.CompareTag("P1LionAttackBack"))
                {
                    Player1HP -= 36;
                    DamageHP1 = 36;
                    HPdrain();
                    P1G.transform.position += new Vector3(HP10per * 2 * 1.2f, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, this.gameObject);
                    Rb.AddForce(ToVec * 55, ForceMode.Impulse);
                    P1ImplaBlock.SetActive(false);
                    //行動停止
                    AllActionInterval = true;
                    Invoke("ActionInterval", 1.1f);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                    DelayFlog();
                }
                if (other.gameObject.CompareTag("P1ImplaBack"))
                {
                    Player1HP -= 36;
                    DamageHP1 = 36;
                    HPdrain();
                    P1G.transform.position += new Vector3(HP10per * 3 * 1.2f, 0, 0);
                    Vector3 ToVec = GetAngleVec(other.gameObject, P1ImplaBlock);
                    P1ImplaBlock.SetActive(false);
                    Rb.AddForce(ToVec * 60, ForceMode.Impulse);
                    //行動停止
                    AllActionInterval = true;
                    Invoke("ActionInterval", 1.1f);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                    DelayFlog();
                }
                if (other.gameObject.CompareTag("P1ImplaWaveBack"))
                {
                    Player1HP -= 12;
                    DamageHP1 = 12;
                    HPdrain();
                    P1G.transform.position += new Vector3(HP10per * 1.2f, 0, 0);
                    //行動停止
                    AllActionInterval = true;
                    Invoke("ActionInterval", 1.1f);
                    //無敵タイム開始
                    P1ImplaBlock.SetActive(false);
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                    DelayFlog();
                }
                if (other.gameObject.CompareTag("P1FlogAttackBack"))
                {
                    Player1HP -= 3f;
                    DamageHP1 = 3;
                    HPdrain();
                    P1G.transform.position += new Vector3(HP10per * 0.3f, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, this.gameObject);
                    Rb.AddForce(ToVec * 20, ForceMode.Impulse);
                    //行動停止
                    AllActionInterval = true;
                    Invoke("ActionInterval", 0.2f);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 0.5f);
                    DelayFlog();
                }
                //オオカミのカウンターのタグに切り替えが未実装
                if (other.gameObject.CompareTag("P1WolfAttackBack"))
                {
                    Player1HP -= 22;
                    DamageHP1 = 22;
                    HPdrain();
                    P1G.transform.position += new Vector3(HP10per * 2.2f, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, this.gameObject);
                    Rb.AddForce(ToVec * 55, ForceMode.Impulse);
                    //行動停止
                    AllActionInterval = true;
                    Invoke("ActionInterval", 1.1f);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                    DelayFlog();
                }
                if (other.gameObject.CompareTag("PoisonAttackBack"))
                {
                    Player1HP -= 3.6f;
                    DamageHP1 = 3.6f;
                    HPdrain();
                    Poisontimer = 0;
                    P1G.transform.position += new Vector3(HP10per * 0.36f, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, this.gameObject);
                    Rb.AddForce(ToVec * 16, ForceMode.Impulse);
                    //行動停止
                    AllActionInterval = true;
                    Invoke("ActionInterval", 1.1f);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                    DelayFlog();
                }
                if (other.gameObject.CompareTag("P1ArmadilloAttackBack"))
                {
                    Player1HP -= 30;
                    DamageHP1 = 30;
                    HPdrain();
                    P1G.transform.position += new Vector3(HP10per * 3f, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, this.gameObject);
                    Rb.AddForce(ToVec * 60, ForceMode.Impulse);
                    //行動停止
                    AllActionInterval = true;
                    Invoke("ActionInterval", 1.1f);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                    DelayFlog();
                }
                if (other.gameObject.CompareTag("P1HorseAttackBack"))
                {
                    Player1HP -= 30;
                    DamageHP1 = 30;
                    HPdrain();
                    P1G.transform.position += new Vector3(HP10per * 3f, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, this.gameObject);
                    Rb.AddForce(ToVec * 60, ForceMode.Impulse);
                    //行動停止
                    AllActionInterval = true;
                    Invoke("ActionInterval", 1.1f);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                    DelayFlog();
                }
            }
            if (other.gameObject.CompareTag("P2KuwagataAttack"))
            {
                Player1HP -= 30;
                DamageHP1 = 30;
                HPdrain();
                P1G.transform.position += new Vector3(HP10per * 3f, 0, 0);
                //ノックバック
                //this.transform.position = new Vector3(this.transform.position.x, other.gameObject.transform.position.y + 2, this.transform.position.z);
                //Vector3 ToVec = GetAngleVec(this.gameObject, other.gameObject);
                KuwagataVec = GetAngleVec(this.gameObject, other.gameObject);
                Rb.AddForce(transform.up * 50, ForceMode.Impulse);
                Invoke("KuwagataNock", 0.5f);
                //Rb.AddForce(ToVec * 50, ForceMode.Impulse);
                //無敵タイム開始
                Invincible = true;
                Invoke("InvincibleTime", 1.5f);
                //行動停止
                AllActionInterval = true;
                Invoke("ActionInterval", 1.2f);
                //音鳴らす
                //AnimalDamage.Play();
                atomSrc.Play("Animal_Damage");
                DelayFlog();

                //ヒットエフェクト
                GameObject Hit;
                Hit = Instantiate(HitEff, transform.position + transform.forward * 4 + transform.up * 1.8f, transform.rotation) as GameObject;
                Hit.transform.localScale = new Vector3(3.0f, 3.0f, 3.0f);
                if (isDrain == true)
                {
                    GameObject HealObj;
                    HealObj = Instantiate(HealEffect, other.transform.position + other.transform.forward * -2 + other.transform.up * 3.5f, Quaternion.identity);
                    HealObj.transform.localScale = new Vector3(5.0f, 5.0f, 5.0f);
                    Destroy(HealObj, 0.8f);
                }
            }
            if (other.gameObject.CompareTag("PalsyBullet2"))
            {
                Player1HP -= 6;
                P1G.transform.position += new Vector3(HP10per * 0.6f, 0, 0);
                //ノックバック
                Vector3 ToVec = GetAngleVec(other.gameObject, this.gameObject);
                Rb.AddForce(ToVec * 20, ForceMode.Impulse);
                //行動停止
                AllActionInterval = true;
                Invoke("ActionInterval", 1.2f);
                DelayFlog();
            }
            if (other.gameObject.CompareTag("PalsyBlock2"))
            {
                AllActionInterval = true;
                Invoke("ActionInterval", 1f);
                DelayFlog();
            }
        }
        else
        {
            this.Animator.SetBool(isFalt, false);
            this.Animator.SetBool(isBlown, false);
        }
    }
}