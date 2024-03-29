using UnityEngine;

public class PlayerController : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth;
    public float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        GameManager.instance.SetHealthUI(currentHealth, maxHealth);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        GameManager.instance.SetHealthUI(currentHealth, maxHealth);
        StartCoroutine(GameManager.instance.FlashScreenRed());
        if (currentHealth <= 0) GameManager.instance.GameOver();
    }

    public void AddHealth(float health)
    {
        currentHealth += health;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        GameManager.instance.SetHealthUI(currentHealth, maxHealth);
    }
}