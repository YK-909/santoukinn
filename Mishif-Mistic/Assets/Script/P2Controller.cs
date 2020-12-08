using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P2Controller : MonoBehaviour
{
    [SerializeField] public float Speed; //プレイヤーの移動速度の変数
    [SerializeField]public GameObject GameClear; //YouWinテキストの変数
    [SerializeField]public Button ReAlchemy; //再錬金テキストの変数

    public int PlayerHP2;//体力の現在の数値
    public Text PlayerHPtext2;//体力の数値を表示
    public Slider SliderGreen2;//HPバー緑
    public Slider SliderBlack2;//HPバー黒

    private GameObject Cam2Obj; //P2カメラを入れる変数
    private Camera Cam2; //P2カメラの変数

    bool isMove2P = false;
    bool isTouch = false;

    float w = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        Cam2Obj = GameObject.Find("2PCamera"); //2Pカメラ
        Cam2 = Cam2Obj.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーの操作
        float x = Input.GetAxisRaw("Horizontal2") * Time.deltaTime * Speed;
        float z = Input.GetAxisRaw("Vertical2") * Time.deltaTime * Speed;

        transform.position += transform.right * z + transform.forward * x;

        if (isMove2P)
        {
             //SwitchTo2P(); //ここを無効にすることで１Pカメラのみにできる

        }
        //勝敗が決まったら
        if (isTouch)
        {
            GameSet();
        }
        //HPテキストの表示
        PlayerHPtext2.text = string.Format("HP:{0}", PlayerHP2);
        //HPの継続的な減少
        if (PlayerHP2 * 2 < SliderBlack2.value)
        {
            SliderBlack2.value -= 1;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("P1"))
        {
            //現時点ではここで減らす量を調整する必要がある
            //数値的に減らす
            PlayerHP2 -= 20;
            //HPゲージを減らす
            //ゆっくりゲージが減るようにゲージの最大値が200になっている
            SliderGreen2.value -= 40;
            if (PlayerHP2 <= 0)//体力の値が0になった時
            {
                isMove2P = true;
                isTouch = true;
                Time.timeScale = 0;
            }
        }
    }

    private void GameSet()
    {
        GameClear.SetActive(true);
        ReAlchemy.gameObject.SetActive(true);
    }

    public void SwitchTo2P() 
    {
        //P2のみのカメラになる
        Cam2.rect = new Rect(0.0f, 0.0f, 1.0f, 1.0f);
        
    }
}
