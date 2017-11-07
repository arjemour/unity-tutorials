using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Ball ball;
    private Vector3 _offset;

    // Use this for initialization
    private void Start()
    {
        _offset = transform.position - ball.transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if (ball.transform.position.z < 1829)
        {
            transform.position = ball.transform.position + _offset;
        }
    }
}