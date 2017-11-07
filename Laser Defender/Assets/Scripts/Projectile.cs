using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Damage = 100;

    public void Hit()
    {
        Destroy(gameObject);
    }

    public float GetDamage()
    {
        return Damage;
    }
}