using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeControl : MonoBehaviour
{
    /* フィールドを追加 */
    //public UnityEngine.UI.Slider BGMvolSlider;
    //使用するSlider
    public UnityEngine.UI.Slider UsevolSlider;
    public string CategoryName;

    private CriAtomSource atomSrc;

    // Start is called before the first frame update
    void Start()
    {
        atomSrc = (CriAtomSource)GetComponent("CriAtomSource");

        //BGMvolSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        //Slider操作で音量が変わる
        UsevolSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });

        //BGMvolSlider.value = CriAtom.GetCategoryVolume("BGM");
        //Sliderの値を音量と同期させる
        UsevolSlider.value = CriAtom.GetCategoryVolume(CategoryName);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PlaySound()
    {
        if (atomSrc != null)
        {
            atomSrc.Play();
        }
    }

    public void PlayAndStopSound()
    {
        if (atomSrc != null)
        {
            CriAtomSource.Status status = atomSrc.status;
            if ((status == CriAtomSource.Status.Stop) || (status == CriAtomSource.Status.PlayEnd))
            {
                atomSrc.Play();
            }
            else
            {
                atomSrc.Stop();
            }
        }
    }

    /* イベントコールバック用関数を追加 */
    public void ValueChangeCheck()
    {
        //atomSrc.volume = BGMvolSlider.value;
        //CriAtomExCategory.SetVolume("BGM", 0.0f);   // BGM カテゴリのボリュームを 0.0f に設定する
        //CriAtom.SetCategoryVolume("BGM", BGMvolSlider.value);
        //音量をSliderの値にする
        CriAtom.SetCategoryVolume(CategoryName, UsevolSlider.value);
    }
}