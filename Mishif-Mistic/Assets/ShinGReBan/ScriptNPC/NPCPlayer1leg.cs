using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCPlayer1leg : MonoBehaviour
{
    //各部分のスプライト
    [SerializeField]
    private Sprite FlyPanSprite;
    [SerializeField]
    private Sprite ImpalaSprite;
    [SerializeField]
    private Sprite WolfSprite;

    //スプライトを表示する用のゲームオブジェクト(UI->Image)    
    [SerializeField]
    private GameObject[] Animaru = new GameObject[5];

    //表示する用のオブジェクト(UI->Image)のImageを設定する変数
    private Image[] AnimaruImage = new Image[5];

    //表示する用のオブジェクト(UI->Image)の位置・スケールを設定する変数
    //UIなので、RectTransformを使用
    private RectTransform[] AnimaruRect = new RectTransform[5];

    //武器選択UIの真ん中に表示している動物画像の座標   
    private Vector2 Main = new Vector2(-287f, 152f);

    //0 : 動物画像を透明にする基準座標
    //1 : 動物画像を逆の端に移動する基準座標
    private Vector2 Up0 = new Vector2(-287f, -49f);
    private Vector2 Up1 = new Vector2(-287f, -250f);
    private Vector2 Down0 = new Vector2(-287f, 353f);
    private Vector2 Down1 = new Vector2(-287f, 554f);

    //動物画像をスライド(変更)させた後の座標(目的地の座標)
    private Vector2[] Target = new Vector2[5];

    //スライド(変更)する前の座標(現在の座標) 
    private Vector2[] AnimaruRectPos = new Vector2[5];

    //スライド(変更)をするかのフラグ
    private bool SlideFlag;

    //スライド(変更)する前の座標(現在の座標)を保存するためのフラグ
    //現在の座標を保存するためには、スライドするためのループ処理の一回目だけ座標を保存する処理をする必要がある    
    private bool PosFlag = true;

    //現在設定している動物の数
    private int AnimaruLevel = 3;

    /*
    スライドする方向
     0 : 左方向
     1 : 右方向
    */
    private int Dir = 0;

    private bool _flag;

    public int WeponType { private set; get; }

    //ADX設定
    public CriAtomSource SwitchSlotUDSrc;

    //AnimaruLevelが3の時の設定
    public void SetLevelThree()
    {
        for (int i = 0; i < Animaru.Length; i++)
        {
            AnimaruImage[i] = Animaru[i].GetComponent<Image>();
            AnimaruRect[i] = Animaru[i].GetComponent<RectTransform>();

            //動物画像が初期状態からバラバラになっている可能性があるので、上から下に動物画像0～4を整列させる
            AnimaruRect[i].localPosition = new Vector2(-287f, 420f - i * 134);

            //真ん中以外の動物画像のサイズを 1/1.8 にする
            if (i == 2)
            {
                AnimaruRect[i].localScale = new Vector3(2.0f, 2.0f, 1);
            }
            else
            {
                AnimaruRect[i].localScale = new Vector3(1 / 1.2f, 1 / 1.2f, 1 / 1.2f);
            }

            /*
             * 真ん中の左隣にナイフ
             * 真ん中にフライパン
             * 真ん中の右隣りにハンドガン
             * 左端には真ん中の右隣りの動物
             * 右端には真ん中の左隣りの動物
             */
            switch (i)
            {
                case 1:
                    AnimaruImage[i].sprite = FlyPanSprite;
                    break;
                case 2:
                    AnimaruImage[i].sprite = ImpalaSprite;
                    break;
                case 3:
                    AnimaruImage[i].sprite = WolfSprite;
                    break;
                case 4:
                    AnimaruImage[0].sprite = AnimaruImage[3].sprite;
                    AnimaruImage[i].sprite = AnimaruImage[(i + 3) % 6].sprite;
                    break;
            }

            /*
             * 両端の動物画像を透明、真ん中3つの画像はそのまま
             */
            if (i == 0 || i == 4) AnimaruImage[i].color = new Color(255, 255, 255, 0);
            else AnimaruImage[i].color = new Color(255, 255, 255, 255);
        }
    }

    //動物画像を上、もしくは下にスライドさせる
    public void SlideWepon()
    {
        if (SlideFlag)
        {

            //動物画像の数(5個)全てをスライドさせる
            for (int i = 0; i < Animaru.Length; i++)
            {
                if (PosFlag)
                {
                    AnimaruRectPos[i] = AnimaruRect[i].localPosition;
                }

                //上にスライドさせる場合
                if (Dir == 0)
                {
                    //スライド後(目的地)の座標を指定
                    Target[i] = new Vector2(AnimaruRectPos[i].x, AnimaruRectPos[i].y - 134f);

                    /*
                     * 動物画像を目的地に移動させる
                     * 移動座標がDown0を超えたら動物画像を透明から元に戻す
                     * 移動座標がUp0を超えたら動物画像を透明にする
                     * 移動座標がUp1(上)になったら下に瞬間移動させる
                     */
                    AnimaruRect[i].localPosition = Vector2.MoveTowards(AnimaruRect[i].localPosition, Target[i], Time.deltaTime * 300);
                    if (AnimaruRect[i].localPosition.y <= Down0.y)
                    {
                        AnimaruImage[i].color = new Color(255, 255, 255, 255);
                    }
                    if (AnimaruRect[i].localPosition.y <= Up0.y)
                    {
                        AnimaruImage[i].color = new Color(255, 255, 255, 0);
                    }
                    if (AnimaruRect[i].localPosition.y == Up1.y)
                    {
                        AnimaruRect[i].localPosition = new Vector2(Down1.x, Down1.y - 134f);
                    }
                }
                else
                {
                    /*
                     * スライド後(目的地)の座標を指定
                     */
                    Target[i] = new Vector2(AnimaruRectPos[i].x, AnimaruRectPos[i].y + 134f);
                    /*
                     * 動物画像を目的地に移動させる
                     * 移動座標がUp0を超えたら武器画像を透明から元に戻す
                     * 移動座標がDown0を超えたら武器画像を透明にする
                     * 移動座標がDown1(下)になったら上端に瞬間移動させる
                     */
                    AnimaruRect[i].localPosition = Vector2.MoveTowards(AnimaruRect[i].localPosition, Target[i], Time.deltaTime * 300);
                    if (AnimaruRect[i].localPosition.y >= Up0.y)
                    {
                        AnimaruImage[i].color = new Color(255, 255, 255, 255);
                    }
                    if (AnimaruRect[i].localPosition.y >= Down0.y)
                    {
                        AnimaruImage[i].color = new Color(255, 255, 255, 0);
                    }

                    if (AnimaruRect[i].localPosition.y == Down1.y)
                    {
                        AnimaruRect[i].localPosition = new Vector2(Up1.x, Up1.y + 134f);
                    }
                }

                //動物画像が目的地まで移動できたらスライドを終了する                
                if (AnimaruRect[i].localPosition.y == Target[i].y)
                {
                    SlideFlag = false;
                }


                //武器画像のどれかが真ん中の座標に移動した場合               
                if (AnimaruRect[i].localPosition.y == Main.y)
                {
                    /*
                     *  カメ     :  WeponTypeを0にする
                     *  サソリ   :  WeponTypeを1にする
                     *  フライパン :  WeponTypeを2にする
                     */
                    if (AnimaruImage[i].sprite == ImpalaSprite)
                    {
                        WeponType = 0;
                    }
                    else if (AnimaruImage[i].sprite == WolfSprite)
                    {
                        WeponType = 1;
                    }
                    else
                    {
                        WeponType = 2;
                    }
                    /*
                     * 武器画像の大きさを1にする(他は1/1.8)
                     */
                    AnimaruRect[i].localScale = new Vector3(2.0f, 2.0f, 1);

                    /*
                     * WeponLevel別に武器選択UIの配置を設定する
                     *      WeponLevel 2 : 現在装備中(真ん中に配置している)の武器画像を両端に設定する
                     *      WeponLevel 3 : 真ん中の右隣の武器画像を左端に設定する
                     *                     真ん中の左隣の武器画像を右端に設定する
                     */
                    if (AnimaruLevel == 2)
                    {
                        AnimaruImage[(i + 2) % 5].sprite = AnimaruImage[i].sprite;
                        AnimaruImage[(i + 3) % 5].sprite = AnimaruImage[i].sprite;
                    }
                    if (AnimaruLevel == 3)
                    {
                        AnimaruImage[(i + 2) % 5].sprite = AnimaruImage[(i + 4) % 5].sprite;
                        AnimaruImage[(i + 3) % 5].sprite = AnimaruImage[(i + 1) % 5].sprite;
                    }
                    /*
                     * 真ん中以外の武器画像のサイズを 1/1.8 にする
                     */
                }
                else
                {
                    AnimaruRect[i].localScale = new Vector3(1 / 1.2f, 1 / 1.2f, 1 / 1.2f);
                }
            }
            PosFlag = false;
        }
    }

    // Use this for initialization
    void Start()
    {
        SetLevelThree();
    }

    // Update is called once per frame
    void Update()
    {
        if (_flag)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && !SlideFlag)
            {
                SlideFlag = true;
                PosFlag = true;
                Dir = 0;

                //音鳴らす
                SwitchSlotUDSrc.Play();
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) && !SlideFlag)
            {
                SlideFlag = true;
                PosFlag = true;
                Dir = 1;

                //音鳴らす
                SwitchSlotUDSrc.Play();
            }

            SlideWepon();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ChooseArea"))
        {
            _flag = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ChooseArea"))
        {
            _flag = false;
        }
    }
}
