using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Gamemanager : MonoBehaviour
{
    private int score;
    private int AlivePigs;

    [SerializeField] private TextMeshProUGUI scoreText;

    public void Start()
    {
        AlivePigs = FindObjectsOfType<PiggyController>().Length;
    }

    public void PigDied(int amount)
    {
        score += amount;
        UpdateScore();
        AlivePigs--;
        if (AlivePigs == 0)
        {
            SceneManager.LoadScene(1);
        }

    }

    private void UpdateScore()
    {
        scoreText.text = score.ToString();
    }
}
