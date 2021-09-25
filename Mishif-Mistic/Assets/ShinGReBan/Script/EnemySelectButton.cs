using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySelectButton : MonoBehaviour
{
    public GameObject NPCCanvas;
    public GameObject SelectCanvas1;
    public GameObject SelectCanvas2;
    public GameObject SelectCanvas3;
    public GameObject Kimera1;
    public GameObject Kimera2;
    public GameObject Kimera3;
    public GameObject Stand;

    public static int head2;
    public static int body2;
    public static int leg2;
    public static int passive2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NPCSelectButton()
    {
        NPCCanvas.SetActive(false);
        SelectCanvas1.SetActive(true);
        Kimera1.SetActive(false);
        Kimera2.SetActive(false);
        Kimera3.SetActive(false);
        Stand.SetActive(true);

        head2 = 1;
        body2 = 2;
        leg2 = 2;
    }

    public void NPCSelectButton2()
    {
        NPCCanvas.SetActive(false);
        SelectCanvas2.SetActive(true);
        Kimera1.SetActive(false);
        Kimera2.SetActive(false);
        Kimera3.SetActive(false);
        Stand.SetActive(true);

        head2 = 3;
        body2 = 3;
        leg2 = 3;
    }

    public void NPCSelectButton3()
    {
        NPCCanvas.SetActive(false);
        SelectCanvas2.SetActive(true);
        Kimera1.SetActive(false);
        Kimera2.SetActive(false);
        Kimera3.SetActive(false);
        Stand.SetActive(true);

        head2 = 2;
        body2 = 1;
        leg2 = 2;
    }
    public static int GetHead2()
    {
        return head2;
    }
    public static int GetBody2()
    {
        return body2;
    }
    public static int GetLeg2()
    {
        return leg2;
    }
}
