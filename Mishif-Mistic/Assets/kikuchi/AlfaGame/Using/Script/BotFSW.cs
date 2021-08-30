using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotFSW : MonoBehaviour
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
    //外装
    //1=加速 2=吸血　わざと１
    private int Exterior = 0;
    //移動速度
    private float Speed = 40.0f;

    //シールド　※カメとの変数に注意　調整中無視していいよ
    private bool Shield = false;
    public GameObject ShieldObj;
    [Range(0f, 1f)]
    private float ShieldPoint = 1.0f;
 
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
    private float ArmadilloSpeed = 0.0f;
    private int ArmadilloMode = 0;
    private bool ArmadilloSwitch = true;
    public GameObject ArmadilloBlock;
    private bool OnceArma = true;

    //馬の攻撃
    public GameObject P2HorseLeg;
    private bool HorseSwitch = true;

    //クワガタの攻撃
    public GameObject KuwagataBlock;
    private bool KuwagataSwitch = true;

    private bool AllActionInterval = false;
    private bool CalledOncePoint = false;

    //加速するための
    private float BuffSpeed = 1.0f;
    //外部に数値を持っていく
    private static int BuffCountP2 = 3;
    public float BuffTimer = 0;

    //吸血
    private float DamageHP2 = 0;
    private static float EnemyHP_1 = 100;
    public GameObject P1G;
    public GameObject P1R;

    //リジェネ
    private float RejeTime = 0;

    //キャラの向きを常に一定に
    private GameObject EnemyObj;
    private Vector3 Enemy;

    //ヒットエフェクト
    public GameObject HitEff;
    public GameObject HealEffect;
    bool isDrain;

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

    //ボット化のための
    private int Value = 1;
    private float Distance;

    void Start()
    {
        P2FlogTongue.SetActive(false);
        P2Lionhead.SetActive(false);
        P2TurtleGard.SetActive(false);
        P2WolfAtk.SetActive(false);
        Rb = GetComponent<Rigidbody>();
        Rb.isKinematic = true;
        EnemyObj = GameObject.Find("P1camera");
        ShieldObj.SetActive(false);
        if (Exterior == 1)
        {
            BuffSpeed = 0.8f;
            
        }

        Animator = GetComponent<Animator>();

        atomSrc = (CriAtomSource)GetComponent<CriAtomSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Gamemode = Timerbotgame.GetGamemode();
        P2TurtleGard.transform.position = this.transform.position + transform.forward * 5 + transform.up * -2;
        DamageHP2 = 0;

        //ボット用 この数値が短いほど正確な動き
        StartCoroutine(DelayMethod(4));
        StartCoroutine(DirectionMethod(7));
        Enemy = new Vector3(EnemyObj.transform.position.x, this.transform.position.y, EnemyObj.transform.position.z);
        transform.LookAt(Enemy);

        if (Gamemode == 1)
        {
            if (AllActionInterval == false)
            {
                EnemyHP_1 = KeyBordPlay1.GetP1HP();
                if (Exterior == 2)
                {
                    Player2HP = KeyBordPlay1.GetP2HP();

                }
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

                            if (NormalJump == false)
                            {
                                Speed = 40.0f * BuffSpeed;
                            }
                            else
                            {
                                Speed = 15f * BuffSpeed;
                            }

                            //距離要調整

                            if (Value == 1 || Value == 2)
                            {
                            }
                            else
                            {
                                float dis= Vector3.Distance(transform.position, EnemyObj.transform.position);
                                if (dis >= 15)
                                {
                                    //前方に移動する
                                    transform.position += transform.forward * Speed * Time.deltaTime;
                                    if (Speed == 40.0)
                                    {
                                        //音鳴らす
                                        atomSrc.Play("Garden_Footsteps");
                                    }

                                    //走る
                                    this.Animator.SetBool(isRun, true);
                                }
                                else 
                                {
                                    this.Animator.SetBool(isRun, false);
                                }
                            }
                        }
                    }

                    if (Invincible == false)
                    {
                        if (NormalJump == false)
                        {

                            if (Head == 1)
                            {
                                //カエル
                                if (Distance < 10)
                                {
                                    this.Animator.SetBool(isRun, false);
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
                                else
                                {
                                    if (FlogSwitch == false)
                                    {
                                        P2FlogAnimator.SetBool("FlogAtkFinP1", true);
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

                            if (FlogSwitch == true)
                            {

                                if (Body == 1)
                                {
                                }
                                else if (Body == 2)
                                {
                                    //サソリ
                                    if (60 < Distance && Distance < 70)
                                    {
                                        this.Animator.SetBool(isRun, false);
                                        //音鳴らす
                                        //ScorpionSrc.Play();

                                        if (ScorpionAtk == true)
                                        {
                                            AllActionInterval = true;
                                            ScorpionAtk = false;
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

                if (Invincible == false)
                {
                    if (FlogSwitch == true)
                    {
                        if (NormalJump == false)
                        {

                            if (Leg == 1)
                            {
                            }
                            else if (Leg == 2)
                            {
                                //オオカミ
                                if (Distance <= 30)
                                {
                                    this.Animator.SetBool(isRun, false);
                                    //音鳴らす
                                    //WolfSrc.Play();
                                    Invoke("ScratchSound", 0.5f);

                                    if (WolfSwitch == true)
                                    {
                                        //音鳴らす
                                        //WolfSrc.Play();
                                        Invoke("ScratchSound", 0.5f);

                                        AllActionInterval = true;
                                        P2WolfAtk.tag = "P2WolfAttack";
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
            P2R.transform.position += new Vector3(10f, 0, 0) * Time.deltaTime;
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
        Rb.AddForce(-transform.up * 60, ForceMode.Impulse);
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
        //カエルの攻撃がボタン押しているときに被ダメした時のため
        P2FlogAnimator.SetBool("FlogAtkFinP1", true);
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

    Vector3 GetAngleVec(GameObject _from, GameObject _to)
    {
        //高さの概念を入れないベクトルを作る
        Vector3 fromVec = new Vector3(_from.transform.position.x, 0, _from.transform.position.z);
        Vector3 toVec = new Vector3(_to.transform.position.x, 0, _to.transform.position.z);
        return Vector3.Normalize(toVec - fromVec);
    }

    void HPdrain()
    {
        if (NPCP1ContlolePassive.GetPassive() == 3)
        {
            if (EnemyHP_1 + (DamageHP2 / 10) < 100)
            {
                EnemyHP_1 += DamageHP2 / 10;
                P2G.transform.position += new Vector3(HP10per * (DamageHP2 / 100), 0, 0);
                P2R.transform.position += new Vector3(HP10per * (DamageHP2 / 100), 0, 0);

                isDrain = true;
            }
        }
    }
    public static float GetP2HP()
    {
        return Player2HP;
    }
    public static int GetBuffCountP2()
    {
        return BuffCountP2;
    }
    public static float GetP1HP()
    {
        return EnemyHP_1;
    }

    private IEnumerator DelayMethod(int delayFrameCount)
    {
        yield return new WaitForSeconds(delayFrameCount);
        Distance = Vector3.Distance(transform.position, EnemyObj.transform.position);
        Debug.Log(Distance);
    }
    private IEnumerator DirectionMethod(int delayFrameCount)
    {
        yield return new WaitForSeconds(delayFrameCount);
        Value = Random.Range(0, 11);
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
            ArmadilloSpeed = 0;
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
                    DamageHP2 = 30;
                    HPdrain();
                    P2G.transform.position += new Vector3(HP10per * 3, 0, 0);
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
                    P2ImplaBlock.SetActive(false);
                    //音鳴らす
                    //LionSrc.Play();
                    //AnimalDamage.Play();
                    atomSrc.Play("Animal_Damage");
                    DelayFlog();

                    //ふっとぶ
                    this.Animator.SetBool(isBlown, true);
                    //最後の一撃
                    if (BotFSW.GetP2HP() <= 0)
                    {
                        this.Animator.SetBool(isDown, true);
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
                if (other.gameObject.CompareTag("P1Impla"))
                {
                    Player2HP -= 30;
                    DamageHP2 = 30;
                    HPdrain();
                    P2G.transform.position += new Vector3(HP10per * 3, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, this.gameObject);
                    Debug.Log(ToVec);
                    Rb.AddForce(ToVec * 60, ForceMode.Impulse);
                    P2ImplaBlock.SetActive(false);
                    //行動停止
                    AllActionInterval = true;
                    Invoke("ActionInterval", 1.1f);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);

                    //音鳴らす
                    atomSrc.Play("Impala_Attack");
                    DelayFlog();

                    //ふっとぶ
                    this.Animator.SetBool(isBlown, true);
                    //最後の一撃
                    if (BotFSW.GetP2HP() <= 0)
                    {
                        this.Animator.SetBool(isDown, true);
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
                if (other.gameObject.CompareTag("P1ImplaWave"))
                {
                    Player2HP -= 10;
                    DamageHP2 = 10;
                    HPdrain();
                    P2G.transform.position += new Vector3(HP10per, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, this.gameObject);
                    Rb.AddForce(ToVec * 30, ForceMode.Impulse);
                    P2ImplaBlock.SetActive(false);
                    //行動停止
                    AllActionInterval = true;
                    Invoke("ActionInterval", 1.1f);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                    //音鳴らす
                    atomSrc.Play("Impala_Attack");
                    DelayFlog();

                    //ふっとぶ
                    this.Animator.SetBool(isBlown, true);
                    //最後の一撃
                    if (BotFSW.GetP2HP() <= 0)
                    {
                        this.Animator.SetBool(isDown, true);
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
                if (other.gameObject.CompareTag("P1WolfAttack"))
                {
                    Player2HP -= 20;
                    DamageHP2 = 20;
                    HPdrain();
                    P2G.transform.position += new Vector3(HP10per * 2f, 0, 0);
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
                    P2ImplaBlock.SetActive(false);
                    //音鳴らす
                    //AnimalDamage.Play();
                    atomSrc.Play("Animal_Damage");
                    DelayFlog();

                    //ふっとぶ
                    this.Animator.SetBool(isBlown, true);
                    //最後の一撃
                    if (BotFSW.GetP2HP() <= 0)
                    {
                        this.Animator.SetBool(isDown, true);
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
                if (other.gameObject.CompareTag("P1FlogAttack"))
                {
                    Player2HP -= 1.5f;
                    DamageHP2 = 1.5f;
                    HPdrain();
                    P2G.transform.position += new Vector3(HP10per * 0.15f, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, this.gameObject);
                    Rb.AddForce(ToVec * 15, ForceMode.Impulse);
                    //行動停止
                    AllActionInterval = true;
                    Invoke("ActionInterval", 0.3f);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 0.6f);
                    P2ImplaBlock.SetActive(false);
                    //音鳴らす
                    //FrogAtkSrc.Play();
                    atomSrc.Play("Frog_Attack");
                    DelayFlog();

                    //怯む
                    this.Animator.SetBool(isFalt, true);
                    //最後の一撃
                    if (BotFSW.GetP2HP() <= 0)
                    {
                        this.Animator.SetBool(isDown, true);
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
                    Player2HP -= 3;
                    DamageHP2 = 3;
                    HPdrain();
                    Poisontimer = 0;
                    P2G.transform.position += new Vector3(HP10per * 0.3f, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, this.gameObject);
                    Rb.AddForce(ToVec * 15, ForceMode.Impulse);
                    //行動停止
                    AllActionInterval = true;
                    Invoke("ActionInterval", 0.3f);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 0.5f);
                    P2ImplaBlock.SetActive(false);

                    //音鳴らす
                    //AnimalDamage.Play();
                    atomSrc.Play("Animal_Damage");
                    DelayFlog();

                    //怯む
                    this.Animator.SetBool(isFalt, true);
                    //最後の一撃
                    if (BotFSW.GetP2HP() <= 0)
                    {
                        this.Animator.SetBool(isDown, true);
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
                if (other.gameObject.CompareTag("P1ArmadilloAttack"))
                {
                    Player2HP -= 25;
                    DamageHP2 = 25;
                    HPdrain();
                    P2G.transform.position += new Vector3(HP10per * 2.5f, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, this.gameObject);
                    Rb.AddForce(ToVec * 50, ForceMode.Impulse);
                    //行動停止
                    AllActionInterval = true;
                    Invoke("ActionInterval", 1.1f);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                    P2ImplaBlock.SetActive(false);

                    //音鳴らす
                    //AnimalDamage.Play();
                    atomSrc.Play("Armadillo_Hit");
                    Debug.Log("鳴った");
                    DelayFlog();

                    //ふっとぶ
                    this.Animator.SetBool(isBlown, true);
                    //最後の一撃
                    if (BotFSW.GetP2HP() <= 0)
                    {
                        this.Animator.SetBool(isDown, true);
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
                if (other.gameObject.CompareTag("P1HorseAttack"))
                {
                    Player2HP -= 25;
                    DamageHP2 = 25;
                    HPdrain();
                    P2G.transform.position += new Vector3(HP10per * 2.5f, 0, 0);
                    //ノックバック
                    Vector3 ToVec = GetAngleVec(other.gameObject, this.gameObject);
                    Rb.AddForce(ToVec * 50, ForceMode.Impulse);
                    //行動停止
                    AllActionInterval = true;
                    Invoke("ActionInterval", 1.1f);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                    P2ImplaBlock.SetActive(false);

                    //音鳴らす
                    //AnimalDamage.Play();
                    atomSrc.Play("Horse_Kick");
                    Debug.Log("鳴った");
                    DelayFlog();

                    //ふっとぶ
                    this.Animator.SetBool(isBlown, true);
                    //最後の一撃
                    if (BotFSW.GetP2HP() <= 0)
                    {
                        this.Animator.SetBool(isDown, true);
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
                if (other.gameObject.CompareTag("P2LionAttackBack"))
                {
                    Player2HP -= 36;
                    DamageHP2 = 36;
                    HPdrain();
                    P2G.transform.position += new Vector3(HP10per * 3 * 1.2f, 0, 0);
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
                if (other.gameObject.CompareTag("P2ImplaBack"))
                {
                    Player2HP -= 36;
                    DamageHP2 = 36;
                    HPdrain();
                    P2G.transform.position += new Vector3(HP10per * 3 * 1.2f, 0, 0);
                    Vector3 ToVec = GetAngleVec(other.gameObject, P2ImplaBlock);

                    Rb.AddForce(ToVec * 60, ForceMode.Impulse);
                    //行動停止
                    AllActionInterval = true;
                    Invoke("ActionInterval", 1.1f);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                    P2ImplaBlock.SetActive(false);
                    DelayFlog();
                }
                if (other.gameObject.CompareTag("P2ImplaWaveBack"))
                {
                    Player2HP -= 12;
                    DamageHP2 = 12;
                    HPdrain();
                    P2G.transform.position += new Vector3(HP10per * 1.2f, 0, 0);
                    //行動停止
                    AllActionInterval = true;
                    Invoke("ActionInterval", 1.1f);
                    //無敵タイム開始
                    Invincible = true;
                    Invoke("InvincibleTime", 1.5f);
                    P2ImplaBlock.SetActive(false);
                    DelayFlog();
                }
                if (other.gameObject.CompareTag("P2FlogAttackBack"))
                {
                    Player2HP -= 3f;
                    DamageHP2 = 3;
                    HPdrain();
                    P2G.transform.position += new Vector3(HP10per * 0.3f, 0, 0);
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
                if (other.gameObject.CompareTag("P2WolfAttackBack"))
                {
                    Player2HP -= 22;
                    DamageHP2 = 22;
                    HPdrain();
                    P2G.transform.position += new Vector3(HP10per * 2.2f, 0, 0);
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
                    Player2HP -= 3.6f;
                    DamageHP2 = 3.6f;
                    HPdrain();
                    Poisontimer = 0;
                    P2G.transform.position += new Vector3(HP10per * 0.36f, 0, 0);
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
                if (other.gameObject.CompareTag("P2ArmadilloAttackBack"))
                {
                    Player2HP -= 30;
                    DamageHP2 = 30;
                    HPdrain();
                    P2G.transform.position += new Vector3(HP10per * 3f, 0, 0);
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
                if (other.gameObject.CompareTag("P2HorseAttackBack"))
                {
                    Player2HP -= 30;
                    DamageHP2 = 30;
                    HPdrain();
                    P2G.transform.position += new Vector3(HP10per * 3f, 0, 0);
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
            if (other.gameObject.CompareTag("P1KuwagataAttack"))
            {
                Player2HP -= 30;
                DamageHP2 = 30;
                HPdrain();
                P2G.transform.position += new Vector3(HP10per * 3f, 0, 0);
                //ノックバック
                this.transform.position = new Vector3(this.transform.position.x, other.gameObject.transform.position.y + 2, this.transform.position.z);
                Vector3 ToVec = GetAngleVec(this.gameObject, other.gameObject);
                Rb.AddForce(transform.up * 20, ForceMode.Impulse);
                Rb.AddForce(ToVec * 40, ForceMode.Impulse);
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
        }
        else
        {
            this.Animator.SetBool(isFalt, false);
            this.Animator.SetBool(isBlown, false);
        }
    }
}