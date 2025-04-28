using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_health : BadGuyHealth
{
    public int bossHelath = 3;
    public UI_Hud hud;
    public GameObject bossBar;
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
                hud.Win();
            }
            return true;
        }
        else
        {
            return false;
        }
    }
}
