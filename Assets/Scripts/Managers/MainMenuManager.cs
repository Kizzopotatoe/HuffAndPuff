using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{

    public void Play()
    {     
        SceneManager.LoadScene("Level 1");
    }

    public void Quit()
    {
        Application.Quit();
    } 

}
