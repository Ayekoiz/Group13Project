using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Change_Scene_buttion : MonoBehaviour
{
    public int SceneNum;
    //changes the Scene the Scene of the given number set in build setings
    public void change_Scene()
    {
        SceneManager.LoadScene(SceneNum);
    }
}
