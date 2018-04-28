using Assets.MyWork.Scripts;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.MyWork.Enemy
{
    class EnemeyAttack : MonoBehaviour
    {

        public float TimeBetweenAttacks = 0.5f;
        private int AttackDamage = 10;
        PlayerHealth playerHealth;
        Health EnemeyHealth;
        GameObject Player;
        
        bool PlayerInRange;
        float Timer;

        private void Awake()
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            playerHealth = Player.GetComponent<PlayerHealth>();
            EnemeyHealth = GetComponent<Health>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject == Player)
            {
                PlayerInRange = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject == Player)
            {
                PlayerInRange = false;
            }
        }

        private void Update()
        {
            Timer += Time.deltaTime;
            if (Timer >= TimeBetweenAttacks && PlayerInRange && EnemeyHealth.currentHealth > 0)
            {
                Attack();
            }
        }

        void Attack()
        {
            Timer = 0f;

            if (playerHealth.Health > 0)
            {
                playerHealth.TakeDamage(AttackDamage);
            }
        }

    }
}
