using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class progress_bar : MonoBehaviour
{
    public GameObject player;
    float oldPositionX;
    float oldPositionY;
    public string sceneName;

    void Start()
    {
        oldPositionX = player.transform.position.x;
        oldPositionY = player.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        // Level1
        if(sceneName == "Level1" && player.transform.position.x != oldPositionX && player.transform.position.x >= -8.95 && player.transform.position.x <= 36.6) {
            this.transform.position = new Vector3(this.transform.position.x + ((player.transform.position.x - oldPositionX) / 3.2536f), this.transform.position.y, 0f);
            oldPositionX = player.transform.position.x;
        }

        //Level2
        if(sceneName == "Level2" && player.transform.position.y != oldPositionY && player.transform.position.y >= -2.45 && player.transform.position.y <= 34.5) {
            this.transform.position = new Vector3(this.transform.position.x + ((player.transform.position.y - oldPositionY) / 2.6393f), player.transform.position.y + 2.45f, 0f);
            oldPositionY = player.transform.position.y;
        }

        // Level3
        if(sceneName == "Level3" && player.transform.position.x != oldPositionX && player.transform.position.x >= -9.21 && player.transform.position.x <= 80.0) {
            this.transform.position = new Vector3(this.transform.position.x + ((player.transform.position.x - oldPositionX) / 6.3721f), this.transform.position.y, 0f);
            oldPositionX = player.transform.position.x;
        }
    }
}
