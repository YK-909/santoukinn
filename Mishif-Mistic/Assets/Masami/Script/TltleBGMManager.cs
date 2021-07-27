using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TltleBGMManager : MonoBehaviour
{
    public string TltleBGMcueSheet = "TitleBGM";

    private CriAtomSource atomSource;
    static private TltleBGMManager instance = null;

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
        {
            GameObject.Destroy(this);
            return;
        }

        atomSource = gameObject.AddComponent<CriAtomSource>();
        atomSource.cueSheet = TltleBGMcueSheet;
        atomSource.volume = 0.3f;

        GameObject.DontDestroyOnLoad(this.gameObject);
        instance = this;

        
    }

    // Update is called once per frame
    void Update()
    {
        instance.atomSource.Play("TitleBGM");
    }

    static public void PlayCueId(int cueID)
    {
        
    }

    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }
}
