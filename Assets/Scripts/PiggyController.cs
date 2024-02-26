using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiggyController : MonoBehaviour
{
    private Gamemanager gamemanager;
    SpriteRenderer spriteRenderer;
    int score;
    bool isAlive = true;
    [SerializeField] private PigSO pigSO;
    [SerializeField] private GameObject terminator;

    private void Start() {
        gamemanager = FindObjectOfType<Gamemanager>();
        score = pigSO.score;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = pigSO.sprite;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if ((other.relativeVelocity.magnitude > 2 || other.gameObject == terminator) && isAlive) 
        {
            gamemanager.addScore(score);
            isAlive = false;
        }
    }
}
