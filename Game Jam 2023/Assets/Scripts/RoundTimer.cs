using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoundTimer : MonoBehaviour
{
    public float currentTime = 0f;
    public float startingTime;

    public TextMeshProUGUI roundTimeText;

    private void Start()
    {
        startingTime = 30f;
        currentTime = startingTime;
    }

    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        roundTimeText.text = currentTime.ToString("0");

        if(currentTime <= 10 &&  currentTime > 5)
        {
            roundTimeText.color = Color.yellow;
        }

        else if(currentTime <= 5)
        {
            roundTimeText.color = Color.red;
        }

        if(currentTime <= 0)
        {
            currentTime = 0;
            SceneManager.LoadScene((int)Scene.GameOverDraw);
        }
    }
}
