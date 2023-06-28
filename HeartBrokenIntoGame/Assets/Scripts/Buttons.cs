using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour 
{
    public void LoadScene(string sceneName){
        SceneManager.LoadScene(sceneName);
    }

    public void CloseApplication()
    {
        Application.Quit();
    }


}