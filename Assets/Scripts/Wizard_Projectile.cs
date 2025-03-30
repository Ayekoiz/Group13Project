using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard_Projectile : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject touched = collision.gameObject;
        if (touched.GetComponent<Player_Controler>() != null)
        {
            touched.GetComponent<Player_Controler>().hurt(transform.position);
        }
        Destroy(this.gameObject);
    }
}
