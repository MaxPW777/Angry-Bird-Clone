using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Gamemanager : MonoBehaviour
{
    private int score;
    private int AlivePigs;

    [SerializeField] private TextMeshProUGUI scoreText;
    
    public void Start(){
        AlivePigs = FindObjectsOfType<PiggyController>().Length;
    }

    public void pigDied(int amount){
        score += amount;
        UpdateScore();
        AlivePigs--;
    }
    private void UpdateScore(){
        scoreText.text = score.ToString();
    }
}
