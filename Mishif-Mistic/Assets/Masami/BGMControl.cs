using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMControl : MonoBehaviour
{
    /* フィールドを追加 */
    public UnityEngine.UI.Slider volSlider;
    public UnityEngine.UI.Slider pitchSlider;

    private CriAtomSource atomSrc;

    // Start is called before the first frame update
    void Start()
    {
        atomSrc = (CriAtomSource)GetComponent("CriAtomSource");
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
    public void OnVolSliderChanged()
    {
        atomSrc.volume = volSlider.value;
    }
}
