using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class progress_bar : MonoBehaviour
{
    public GameObject player;
    float oldPositionX;
    float oldPositionY;
    public string sceneName;
    public GameObject bar;

    void Start()
    {
        oldPositionX = player.transform.position.x;
        oldPositionY = player.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        // Level1
        if(sceneName == "Level1" && player.transform.position.x != oldPositionX && player.transform.position.x >= -8 && player.transform.position.x <= 36.3) {
            this.transform.position = new Vector3(this.transform.position.x + ((player.transform.position.x - oldPositionX) / 3.1643f), this.transform.position.y, 0f);
            oldPositionX = player.transform.position.x;
        }

        //Level2
        if(sceneName == "Level2" && player.transform.position.y != oldPositionY && player.transform.position.y >= -4 && player.transform.position.y <= 33.8) {
            this.transform.position = new Vector3(this.transform.position.x + ((player.transform.position.y - oldPositionY) / 2.7f), bar.transform.position.y, 0f);
            oldPositionY = player.transform.position.y;
        }

        // Level3
        if(sceneName == "Level3" && player.transform.position.x != oldPositionX && player.transform.position.x >= -8 && player.transform.position.x <= 80.0) {
            this.transform.position = new Vector3(this.transform.position.x + ((player.transform.position.x - oldPositionX) / 6.2857f), this.transform.position.y, 0f);
            oldPositionX = player.transform.position.x;
        }
    }
}
