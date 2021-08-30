using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeControl : MonoBehaviour
{
    /* フィールドを追加 */
    public UnityEngine.UI.Slider BGMvolSlider;
    public UnityEngine.UI.Slider SEvolSlider;

    private CriAtomSource atomSrc;

    // Start is called before the first frame update
    void Start()
    {
        atomSrc = (CriAtomSource)GetComponent("CriAtomSource");

        BGMvolSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        SEvolSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });

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
        CriAtomExCategory.SetVolume("BGM", BGMvolSlider.value);
        CriAtomExCategory.SetVolume("SFX", SEvolSlider.value);
    }
}
