using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;    // enemy damage
    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private GameObject deathParticleEffect; 
    [SerializeField]
    private AudioClip deathSound; // sound
    private AudioSource audioSource;

    private void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision detected with: " + collision.tag); // debug

        // enemy hit tag Player
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Hit Player");
            collision.GetComponent<PlayerHP>().TakeDamage(damage);
            OnDie();
        }
        // enemy hit by projectile
        else if (collision.CompareTag("Projectile"))
        {
            Debug.Log("Hit by Projectile");
            OnDie();
            Destroy(collision.gameObject);
        }
    }

    public void OnDie()
    {
        PlayDeathEffects();
        // object destroy
        Destroy(gameObject, 0.5f); // after sound destroy
    }

    private void PlayDeathEffects()
    {
        // particle effect
        if (deathParticleEffect != null)
        {
            Instantiate(deathParticleEffect, transform.position, Quaternion.identity);
        }

        // sound play
        if (audioSource != null && deathSound != null)
        {
            audioSource.PlayOneShot(deathSound);
        }
    }
}
