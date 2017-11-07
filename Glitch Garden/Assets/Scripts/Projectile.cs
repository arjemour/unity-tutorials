using System.Xml.Serialization;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Speed;
    public float Damage;

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector3.right * Speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Attacker attacker = collider.gameObject.GetComponent<Attacker>();
        Health health = collider.gameObject.GetComponent<Health>();
        if (attacker && health)
        {
            health.DealDamage(Damage);
            Destroy(gameObject);
        }
    }
}