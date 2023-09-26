using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public float startingTime;

    void Start()
    {
        startingTime = 30f;
    }

    public void BackOption()
    {
        SceneManager.LoadScene(0);
    }

    public void RoundTimer30()
    {
        startingTime = 30f;
    }

    public void RoundTimer60()
    {
        startingTime = 60f;
    }

    public void RoundTimer90()
    {
        startingTime = 90f;
    }
}
