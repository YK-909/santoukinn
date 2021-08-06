using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBGMManager : MonoBehaviour
{
    public string TitleBGMcueSheet = "TitleBGM";

    private CriAtomSource atomSource;
    static private TitleBGMManager instance = null;

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
        {
            GameObject.Destroy(this);
            return;
        }

        atomSource = gameObject.AddComponent<CriAtomSource>();
        atomSource.cueSheet = TitleBGMcueSheet;
        atomSource.volume = 0.3f;

        GameObject.DontDestroyOnLoad(this.gameObject);
        instance = this;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static public void PlayCueId(int cueID)
    {
        instance.atomSource.Play("TitleBGM");
    }

    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }
}
