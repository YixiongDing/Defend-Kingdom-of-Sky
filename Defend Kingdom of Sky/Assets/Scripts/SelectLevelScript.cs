using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SelectLevelScript : MonoBehaviour
{
    public void loadForest()
    {
        SceneManager.LoadScene("ForestLevel");
    }

    public void loadIceWorld()
    {
        SceneManager.LoadScene("IceWorldLevel");
    }

    public void loadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
