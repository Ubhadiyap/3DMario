using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.MyWork.Scripts
{
    class PlayerHealth : MonoBehaviour
    {

        public int MaxHealth = 100;
        public int Health;
        public Slider HealthSlider;

        MovementController movementController;

        private bool Damaged;
        private bool IsDead;

        private void Awake()
        {
            movementController = GetComponent<MovementController>();
            Health = MaxHealth;
            HealthSlider.value = Health;
            Damaged = false;
            IsDead = false;
        }

        public void TakeDamage(int Damage)
        {
            Damaged = true;
            Health = Health - Damage;
            HealthSlider.value = Health;

            if (Health <= 0 && !IsDead)
            {
                Die();
            }
        }

        private void Die()
        {
            IsDead = true;

            movementController.enabled = false;
        }

    }
}
