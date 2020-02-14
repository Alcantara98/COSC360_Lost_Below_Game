using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void LoadLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void LoadControls()
    {
        SceneManager.LoadScene("Controls");
    }

    public void LoadTutorial()
    {
        PlayerOxygen.TankAir = PlayerOxygen.TankSize;
        SceneManager.LoadScene("IntroScene");
        RespawnMaster.playerLife = 3;
    }

    public void LoadLevel1()
    {
        PlayerCollectibles.nglow = 0;
        PlayerCollectibles.hasKnife = false;
        PlayerOxygen.TankAir = PlayerOxygen.TankSize;
        RespawnMaster.playerLife = 3;
        SceneManager.LoadScene("Level_1");
    }

    public void LoadLevel2()
    {
        PlayerCollectibles.nglow = 0;
        PlayerCollectibles.hasKnife = false;
        PlayerOxygen.TankAir = PlayerOxygen.TankSize;
        RespawnMaster.playerLife = 3;
        SceneManager.LoadScene("Level_2");
    }

    public void gtfo()
    {
        SceneManager.LoadScene("Main Menu");
    }

}