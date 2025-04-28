using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Boss_health : BadGuyHealth
{
    public TMP_Text speechBubble;
    public int bossHelath = 3;
    public UI_Hud hud;
    public GameObject bossBar;

    void Start()
    {
        speechBubble.enabled = false;
    }

    void enableText()
    {
        speechBubble.enabled = true;
    }

    void loadNextLevel()
    {
        hud.Win();
    }

    public override bool takeDamige(PlayerAtatckType atatckType)

    {
        if (atatckType == PlayerAtatckType.magic)
        {
            bossHelath--;
            bossBar.transform.localScale -= new Vector3(4, 0, 0);
            bossBar.transform.position -= new Vector3(2, 0, 0);
            if (bossHelath == 0)
            {
                Destroy(gameObject);
                Invoke("enableText", 1f);
                Invoke("loadNextLevel", 3f);
            }
            return true;
        }
        else
        {
            return false;
        }
    }
}
