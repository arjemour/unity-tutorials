using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float Health = 150;
    public GameObject Projectile;
    public float projectileSpeed = 5;
    public float ShotsPerSeconds = 0.5f;
    private ScoreKeeper score;
    private AudioSource sound;

    // Use this for initialization
    private void Start()
    {
        sound = GetComponent<AudioSource>();
        score = GameObject.FindObjectOfType<ScoreKeeper>();
    }

    // Update is called once per frame
    private void Update()
    {
        float prob = Time.deltaTime * ShotsPerSeconds;
        if (Random.value < prob)
            Fire();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Projectile missile = collider.gameObject.GetComponent<Projectile>();
        if (missile)
        {
            Health -= missile.GetDamage();
            missile.Hit();

            if (Health <= 0)
            {
                score.IncreaseScore(1);
                Destroy(gameObject);
            }
                
        }
    }

    private void Fire()
    {
        sound.Play();
        GameObject beam = Instantiate(Projectile, transform.position - new Vector3(0, 1, 0), Quaternion.identity);
        beam.GetComponent<Rigidbody2D>().velocity += Vector2.down * projectileSpeed;
    }
}