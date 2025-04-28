using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_follow : MonoBehaviour
{
    public GameObject player;
    float oldPositionX;
    float oldPositionY;
    public string sceneName;
    bool boss = false;

    void Start()
    {
        oldPositionX = player.transform.position.x;
        oldPositionY = player.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        // Level1
        if(sceneName == "Level1" && player.transform.position.x >= 1.25 && player.transform.position.x <= 28.45) {
            this.transform.position = new Vector3(player.transform.position.x, this.transform.position.y, -10f);
        }

        //Level2
        if(sceneName == "Level2" && player.transform.position.y >= -2.45 && player.transform.position.y <= 34.5) {
            this.transform.position = new Vector3(this.transform.position.x, player.transform.position.y + 2.45f, -10f);
        }

        // Level3
        if(sceneName == "Level3" && player.transform.position.x >= 1.25 && player.transform.position.x <= 78.5) {
            if(boss == false)
            {
                this.transform.position = new Vector3(player.transform.position.x, this.transform.position.y, -10f);
            }
            if(player.transform.position.x > 78.4)
            {
                boss = true;
            }
        }
    }
}
