using UnityEngine;

public class DayCycle : MonoBehaviour
{
    public float MinutesPerSecond;

    // Update is called once per frame
    private void Update()
    {
        float angeThisFrame = Time.deltaTime / 360 * MinutesPerSecond;
        transform.RotateAround(transform.position, Vector3.forward, angeThisFrame);
    }
}