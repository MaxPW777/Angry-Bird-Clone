using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Unity.Burst;
using UnityEngine;

public class PiggyController : MonoBehaviour
{
    private Gamemanager gamemanager;
    SpriteRenderer spriteRenderer;
    PolygonCollider2D polygonCollider;
    int score;
    bool isAlive = true;
    [SerializeField] private PigSO pigSO;
    [SerializeField] private GameObject terminator;
    [SerializeField] private ParticleSystem _particleSystem;
    private Rigidbody2D _rigidbody2D;
    private PolygonCollider2D collider;

    private void Start() {
        gamemanager = FindObjectOfType<Gamemanager>();
        score = pigSO.score;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = pigSO.sprite;
        polygonCollider = GetComponent<PolygonCollider2D>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        collider = GetComponent<PolygonCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        ContactPoint2D contact = other.GetContact(0); // Obtenez le premier point de contact

        // Convertir les coordonnées du point de contact du monde vers les coordonnées locales de l'objet
        Vector3 pointOfContactLocal = transform.InverseTransformPoint(contact.point);

        if ((other.relativeVelocity.magnitude > 2 || other.gameObject == terminator || pointOfContactLocal.y > 0.3f && other.relativeVelocity.magnitude > 2) && isAlive) 
        {
            isAlive = false; 
            spriteRenderer.sprite = pigSO.deadSprite;
            StartCoroutine(DeathAnimation());
        }
    }

IEnumerator DeathAnimation()
    {
        yield return new WaitForSeconds(3);
        _particleSystem.Play();
        spriteRenderer.enabled = false;
        gamemanager.PigDied(score);
        collider.enabled = false;
        _rigidbody2D.isKinematic = true;
        yield return new WaitForSeconds(1);
        _rigidbody2D.freezeRotation = true;
        _rigidbody2D.velocity = Vector2.zero;
        _rigidbody2D.rotation = 0;
        gameObject.SetActive(false);
    }
}
