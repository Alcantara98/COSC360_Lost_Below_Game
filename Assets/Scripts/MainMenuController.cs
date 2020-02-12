using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void LoadLevelSelector()
    {
        //SceneManager.LoadScene("level selector");
        Debug.Log("Loading level selector");
    }

    public void LoadControls()
    {
        SceneManager.LoadScene("Controls");
        Debug.Log("Loading controls...");
    }
}