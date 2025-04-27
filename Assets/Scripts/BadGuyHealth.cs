using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuyHealth : MonoBehaviour
{
    public bool isImmuneStab = false;
    public bool isImmunestomp = false;
    public bool isImmuneAirSlash = false;
    virtual public bool takeDamige(PlayerAtatckType atatckType)
    {
        //Debug.Log("oof");
        switch (atatckType)
        {
            case PlayerAtatckType.Stab:
                if (isImmuneStab)
                {
                    return false;
                }
                else
                {
                    Destroy(gameObject);
                    return true;
                }
            case PlayerAtatckType.Stomp:
                if (isImmunestomp)
                {
                    return false;
                }
                else
                {
                    Destroy(gameObject);
                    return true;
                }
            case PlayerAtatckType.AirSlash:
                if (isImmuneAirSlash)
                {
                    return false;
                }
                else
                {
                    Destroy(gameObject);
                    return true;
                }
            case PlayerAtatckType.magic:
                Destroy(gameObject);
                return true;
            default:
                return false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("hit");
        GameObject touched = collision.gameObject;
        if (touched.GetComponent<Player_Controler>() != null)
        {
            if ((touched.GetComponent<Transform>().position.y > transform.position.y+0.5)&&!isImmunestomp)
            {
                takeDamige(PlayerAtatckType.Stomp);
                touched.GetComponent<Player_Controler>().bounce();
                touched.GetComponent<Player_Controler>().score(true);
                return;
            }
            touched.GetComponent<Player_Controler>().hurt(transform.position);
        }
    }
    
}
public enum PlayerAtatckType
{
    Stab,
    Stomp,
    AirSlash,
    magic,
}
