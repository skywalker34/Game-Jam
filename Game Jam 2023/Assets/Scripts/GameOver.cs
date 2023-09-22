using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void Rematch()
    {
        SceneManager.LoadScene(2);
    }

    public void MainMenuOption()
    {
        SceneManager.LoadScene(0);
    }
}
