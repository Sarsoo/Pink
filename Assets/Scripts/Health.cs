using System;
using UnityEngine.Events;
using UnityEngine;

namespace Pink.Mechanics
{
    public class Health : MonoBehaviour
    {
        public float MaxHealth = 10f;

        public UnityEvent WasHurt;
        public UnityEvent WasHealed;

        private float currentHealth;
        float CurrentHealth {
            get => currentHealth;
            set => currentHealth = Math.Min(
                                        Math.Max(0f, value), 
                                   MaxHealth);
        }
        public bool IsDead => CurrentHealth > 0;

        // Start is called before the first frame update
        void Start()
        {
            CurrentHealth = MaxHealth;
        }

        public bool Hurt(float decrement)
        {
            CurrentHealth -= decrement;
            WasHurt.Invoke();
            return !IsDead;
        }

        public bool Heal(float increment)
        {
            CurrentHealth += increment;
            WasHealed.Invoke();
            return CurrentHealth == MaxHealth;
        }
    }
}