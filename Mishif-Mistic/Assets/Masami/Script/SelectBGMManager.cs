using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectBGMManager : MonoBehaviour
{
    public string SelectBGMcueSheet = "SelectBGMcueSheet";

    private CriAtomSource atomSource;
    static private SelectBGMManager instance = null;

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
        {
            GameObject.Destroy(this);
            return;
        }

        atomSource = gameObject.AddComponent<CriAtomSource>();
        atomSource.cueSheet = SelectBGMcueSheet;

        GameObject.DontDestroyOnLoad(this.gameObject);
        instance = this;

        
    }

    // Update is called once per frame
    void Update()
    {
        instance.atomSource.Play("SelectBGM");
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

