using System;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public bool AutoPlay = false;

    private Ball ball;

    // Use this for initialization
    private void Start()
    {
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!AutoPlay)
            MoveWithMouse();
        else
            Play();
    }

    private void Play()
    {
        gameObject.transform.position = new Vector3(ball.transform.position.x, transform.position.y, transform.position.z);
    }

    private void MoveWithMouse()
    {
        var mousePosInBlocks = Input.mousePosition.x / Screen.width * 16 - 7.5f;
        gameObject.transform.position = new Vector3(Mathf.Clamp(mousePosInBlocks, -7.5f, 7.5f), transform.position.y,
            transform.position.z);
    }
}