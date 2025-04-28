using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SpeechBubble : MonoBehaviour
{
    public TMP_Text speechBubble;
    public TMP_Text goalSpeechBubble;
    public GameObject player;
    public GameObject goal;

    Vector3 playerDistance; 
    Vector3 goalPosition;
    float Distance;
    public UI_Hud hud;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("disableText", 4f);
        goalSpeechBubble.enabled = false;
        
        
    }

    void disableText() {
        speechBubble.enabled = false;
    }

    void enableText() {
        goalSpeechBubble.enabled = true;
    }

    void loadNextLevel() {
        hud.Win();
    }


    // Update is called once per frame
    void Update()
    {
        playerDistance = player.transform.position;
        goalPosition = goal.transform.position;
        Distance = Vector3.Distance(goalPosition, playerDistance);


        if (Distance <= 5f)
        {
            Invoke("enableText", 1f);
            Invoke("loadNextLevel", 8f);
        }
    }
}
