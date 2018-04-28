using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Health : MonoBehaviour
{

    public const int maxHealth = 100;
    public int currentHealth;
    public int ScoreValue = 15;

    //public Slider healthBar;
    ParticleSystem hitParticles;
    public GameObject Player;

    public float ParticleTime = 3f;
    private float ParticleReamainingTime;
    bool IsHit;

    private void Start()
    {
        currentHealth = maxHealth;
        hitParticles = GetComponentInChildren<ParticleSystem>();
        hitParticles.Pause();
        IsHit = false;
    }

    private void Update()
    {
        if (ParticleReamainingTime < 0 && IsHit)
        {
            hitParticles.Pause();
            IsHit = false;
        }
        else
        {
            ParticleReamainingTime -= Time.deltaTime;
        }
    }

    public void TakeDamage(int amount, Vector3 hitPoint)
    {
        IsHit = true;
        ParticleReamainingTime = ParticleTime;
        currentHealth -= amount;

        // Set the position of the particle system to where the hit was sustained.
        hitParticles.transform.position = hitPoint;

        // And play the particles.
        hitParticles.Play();

        if (currentHealth <= 0)
        {
            Player.GetComponent<MovementController>().Score += ScoreValue;
            Destroy(gameObject);
        }
    }

}