using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void Rematch()
    {
        SceneManager.LoadScene((int)Scene.FightingScene);
    }

    public void MainMenuOption()
    {
        SceneManager.LoadScene((int)Scene.MainMenu);
    }
}
