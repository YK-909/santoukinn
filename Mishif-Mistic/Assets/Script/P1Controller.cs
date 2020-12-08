using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P1Controller : MonoBehaviour
{
    [SerializeField] public float Speed; //プレイヤーの移動速度の変数
    [SerializeField] public GameObject GameClear; //YouWinテキストの変数
    [SerializeField] public Button ReAlchemy; //再錬金テキストの変数
                                              
    public int PlayerHP;//体力の現在の数値
    public Text PlayerHPtext;//体力の数値を表示
    public Slider SliderGreen;//HPバー緑
    public Slider SliderBlack;//HPバー黒

    private GameObject Cam2Obj; //P2カメラを入れる変数
    private Camera Cam; //P1カメラの変数
    private Camera Cam2; //P2カメラの変数

    bool isMove1P = false;
    bool isTouch = false;

    // Start is called before the first frame update
    void Start()
    {
        Cam = Camera.main; //1Pカメラ

        Cam2Obj = GameObject.Find("2PCamera"); //2Pカメラ
        Cam2 = Cam2Obj.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーの操作
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * Speed;
        float z = Input.GetAxisRaw("Vertical") * Time.deltaTime * Speed;

        transform.position += transform.right * z + transform.forward * x;

        if (isMove1P)
        {
            SwitchTo1P();
        }
        //勝敗が決まったら
        if (isTouch)
        {
            GameSet();
        }
        //HPテキストの表示
        PlayerHPtext.text = string.Format("HP:{0}", PlayerHP);
        //HPの継続的な減少
        if (PlayerHP * 2 < SliderBlack.value)
        {
            SliderBlack.value -= 1;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("P2"))
        {
            //現時点ではここで減らす量を調整する必要がある
            //数値的に減らす
            PlayerHP -= 15;
            //HPゲージを減らす
            //ゆっくりゲージが減るようにゲージの最大値が200になっている
            SliderGreen.value -= 30;
            if (PlayerHP <= 0)//体力の値が0になった時
            {
                isMove1P = true;
                isTouch = true;

                Time.timeScale = 0;
            }
        }
    }

    private void GameSet() 
    {
        GameClear.SetActive(true); //YouWinを表示
        ReAlchemy.gameObject.SetActive(true); //再錬金を表示
    }

    public void SwitchTo1P() 
    {
        //P1のみのカメラになる
        Cam.rect = new Rect(0.0f, 0.0f, 1.0f, 1.0f);
        Cam2.rect = new Rect(0.0f, 0.0f, 1.0f, 0.0f);
    }
}
