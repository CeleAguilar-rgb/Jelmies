using UnityEngine;

public class Health : MonoBehaviour
{
    public float CurrentHealth { get; private set; }

    private InformacionDePersonaje data;

    public void Initialize(InformacionDePersonaje informacionDePersonaje)
    {
        data = informacionDePersonaje;
        CurrentHealth = data.maxHealth;
    }

    public void TakeDamage(float amount)
    {
        CurrentHealth -= amount;

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}