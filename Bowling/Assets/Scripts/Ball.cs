using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector3 LaunchVelocity;
    public bool InPlay = false;

    private Rigidbody _rigidbody;
    private AudioSource _audioSource;
    private Vector3 _ballStartPos;

    // Use this for initialization
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();

        _rigidbody.useGravity = false;

        _ballStartPos = transform.position;
    }

    public void Launch(Vector3 velocity)
    {
        InPlay = true;

        _rigidbody.useGravity = true;
        _rigidbody.velocity = velocity;
        
        _audioSource.Play();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void Reset()
    {
        InPlay = false;
        transform.position = _ballStartPos;
        transform.rotation = Quaternion.Euler(Vector3.zero);
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
        _rigidbody.useGravity = false;
    }
}