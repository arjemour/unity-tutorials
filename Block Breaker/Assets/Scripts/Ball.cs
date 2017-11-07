using UnityEngine;

public class Ball : MonoBehaviour
{
    private new AudioSource audio;
    public AudioClip BoingClip;
    public AudioClip BrickClip;
    private bool hasStarted;
    private Paddle paddle;
    private Vector3 paddleToBallVector;

    // Use this for initialization
    private void Start()
    {
        audio = FindObjectOfType<AudioSource>();
        paddle = FindObjectOfType<Paddle>();
        paddleToBallVector = gameObject.transform.position - paddle.transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!hasStarted)
            gameObject.transform.position = paddle.transform.position + paddleToBallVector;


        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 10);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(0, 0.2f), Random.Range(0, 0.2f));

        if (hasStarted)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity += tweak;
            if (collision.gameObject.tag == "Breakable")
                audio.PlayOneShot(BrickClip, 0.3f);
            else
                audio.PlayOneShot(BoingClip, 0.1f);
        }
    }
}