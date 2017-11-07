using UnityEngine;

public class Health : MonoBehaviour
{
    public float HealthPoints;

    public void DealDamage(float damage)
    {
        HealthPoints -= damage;
        if (HealthPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}