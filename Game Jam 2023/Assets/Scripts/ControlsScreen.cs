using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlsScreen : MonoBehaviour
{
    public void BackButton()
    {
        SceneManager.LoadScene((int)Scene.MainMenu);
    }
}
