using UnityEngine;

[RequireComponent(typeof(Ball))]
public class DragLaunch : MonoBehaviour
{
    private Vector3 _dragStart;
    private Vector3 _dragEnd;
    private float _startTime;
    private float _endTime;
    private Ball _ball;

    // Use this for initialization
    private void Start()
    {
        _ball = GetComponent<Ball>();
    }

    public void DragStart()
    {
        if( _ball.InPlay)
            return;
        
        _dragStart = Input.mousePosition;
        _startTime = Time.time;
    }

    public void DragEnd()
    {
        if (_ball.InPlay)
            return;

        _dragEnd = Input.mousePosition;
        _endTime = Time.time;

        float dragDuration = _endTime - _startTime;
        float launchSpeedX = (_dragEnd.x - _dragStart.x) / dragDuration;
        float launchSpeedZ = (_dragEnd.y - _dragStart.y) / dragDuration;

        Vector3 launchVelocity = new Vector3(launchSpeedX, 0, launchSpeedZ);
        _ball.Launch(launchVelocity);
    }

    public void MoveStart(float amount)
    {
        if (!_ball.InPlay)
        {
            _ball.transform.Translate(new Vector3(amount, 0));
        }
    }
}