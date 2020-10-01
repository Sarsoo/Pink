using System;
using UnityEngine.Events;
using UnityEngine;

namespace Pink.Mechanics
{
    public class Health : MonoBehaviour
    {
        public float MaxHealth = 10f;

        [Header("Events")]
        [Space]

        public UnityEvent WasHurt;
        public UnityEvent WasHealed;
        public UnityEvent WasKilled;

        private float currentHealth;
        float CurrentHealth {
            get => currentHealth;
            set => currentHealth = Math.Min(
                                        Math.Max(0f, value), 
                                   MaxHealth);
        }
        public bool IsDead => CurrentHealth == 0;
        public bool IsAlive => CurrentHealth > 0;

        // Start is called before the first frame update
        void Start()
        {
            CurrentHealth = MaxHealth;
        }

        public bool Hurt(float decrement)
        {
            if (IsAlive)
            {
                CurrentHealth -= decrement;
                WasHurt.Invoke();
                if (IsDead)
                    WasKilled.Invoke();
            }
            return IsAlive;
        }

        public bool Hurt()
        {
            return Hurt(MaxHealth / 5);
        }

        public bool Heal(float increment)
        {
            CurrentHealth += increment;
            WasHealed.Invoke();
            return CurrentHealth == MaxHealth;
        }

        public bool Heal()
        {
            CurrentHealth = MaxHealth;
            WasHealed.Invoke();
            return CurrentHealth == MaxHealth;
        }

        public void Kill()
        {
            if (IsAlive)
            {
                Hurt(MaxHealth);
            }
        }

        public void Reset()
        {
            currentHealth = MaxHealth;
        }
    }
}