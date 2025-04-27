using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_health : BadGuyHealth
{
    public int bossHelath = 3;
    public UI_Hud hud;
    public override bool takeDamige(PlayerAtatckType atatckType)
    {
        if (atatckType == PlayerAtatckType.magic)
        {
            bossHelath--;
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
