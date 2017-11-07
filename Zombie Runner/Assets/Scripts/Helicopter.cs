using UnityEngine;

public class Helicopter : MonoBehaviour
{
    private bool _called;
    private Rigidbody _rigidbody;

    // Use this for initialization
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnDispatchHelicopter()
    {
        _called = true;
        _rigidbody.velocity = new Vector3(0, 0, 50f);
    }
}