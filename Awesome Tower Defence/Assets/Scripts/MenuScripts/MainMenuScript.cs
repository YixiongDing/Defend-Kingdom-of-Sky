using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("ForestLevel");
    }

    public void OpenInstructions()
    {
        SceneManager.LoadScene("InstructionsScene");
    }

    public void OpenOptions()
    {
        SceneManager.LoadScene("OptionsScene");
    }
    
}
