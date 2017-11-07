using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private readonly float padding = 0.5f;
    public GameObject Projectile;
    public float projectileSpeed = 5;
    public float speed = 15f;
    private float xMax;
    public float FiringRate = 0.2f;
    public float Health = 300;
    private AudioSource sound;
    public AudioClip Laser;
    public AudioClip GameOver;
    private bool dead = false;

    private float xMin;

    // Use this for initialization
    private void Start()
    {
        sound = GetComponent<AudioSource>();
        var distance = transform.position.z - Camera.main.transform.position.z;
        var leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        var rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xMin = leftMost.x + padding;
        xMax = rightMost.x - padding;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!dead)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
                transform.position += Vector3.left * speed * Time.deltaTime;
            else if (Input.GetKey(KeyCode.RightArrow))
                transform.position += Vector3.right * speed * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
                InvokeRepeating("Fire", 0, FiringRate);
            if (Input.GetKeyUp(KeyCode.Space))
                CancelInvoke("Fire");

            var newX = Mathf.Clamp(transform.position.x, xMin, xMax);
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        }
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
                dead = true;
                GetComponent<SpriteRenderer>().sprite = null;
                AudioSource.PlayClipAtPoint(GameOver, new Vector3());
                GetComponent<ScoreKeeper>().Reset();
                Destroy(gameObject);
            }
        }
    }

    private void Fire()
    {
        sound.PlayOneShot(Laser);
        var beam = Instantiate(Projectile, transform.position, Quaternion.identity);
        beam.GetComponent<Rigidbody2D>().velocity += Vector2.up * projectileSpeed;
    }
}