using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_bar : MonoBehaviour
{
	public GameObject player;
    bool boss = false;
    public GameObject bossBar;
    public GameObject bossHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(boss == true)
            {
                bossBar.SetActive(true);
                bossHealth.SetActive(true);
            }
        if(player.transform.position.x > 78.4)
        {
            boss = true;
        }
    }
}
