using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UI_Hud : MonoBehaviour
{
    // [SerializeField] makes things not public but you can change them in the editer 
    [SerializeField] GameObject pause_menu;
    [SerializeField] GameObject helth1;
    [SerializeField] GameObject helth2;
    [SerializeField] GameObject helth3;
    [SerializeField] GameObject dead1;
    [SerializeField] GameObject dead2;
    [SerializeField] GameObject dead3;
    [SerializeField] TMP_Text Score;
    [SerializeField] TMP_Text Timetext;
    private int score = 0;
    private float time = 0;
    public bool gameispaused = false;

    void Update()
    {
        time += Time.deltaTime;
        Score.text = "score:" + score;
        Timetext.text ="time:"+((float)((int)(time*10)))/10;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameispaused)
            {
                resumeGame();
            }
            else { 
            pasueGame();
            }
        }
        
    }
    //changes the health desplad in UI
    public void healthchange(int health)
    {
        bool h1 = health >= 1;
        bool h2 = health >= 2;
        bool h3 = health >= 3;
        helth1.SetActive(h1);
        helth2.SetActive(h2);
        helth3.SetActive(h3);
        dead1.SetActive(!h1);
        dead2.SetActive(!h2);
        dead3.SetActive(!h3);
    }
    //add value to the score
    public void addScore(int score)
    {
        this.score += score;
    }
    
    // pauses the game 
    public void pasueGame()
    {
        gameispaused = true;
        pause_menu.SetActive(true);
        Time.timeScale = 0;
    }
    // un pauses the game 
    public void resumeGame()
    {
        gameispaused=false;
        pause_menu.SetActive(false);
        Time.timeScale = 1;
    }
}
