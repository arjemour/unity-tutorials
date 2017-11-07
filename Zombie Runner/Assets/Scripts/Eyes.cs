using UnityEngine;

public class Eyes : MonoBehaviour
{
    private float _defaultFOV;
    private Camera _eyes;

    // Use this for initialization
    private void Start()
    {
        _eyes = GetComponent<Camera>();
        _defaultFOV = _eyes.fieldOfView;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButton("Zoom"))
            _eyes.fieldOfView = _defaultFOV / 1.5f;
        else
            _eyes.fieldOfView = _defaultFOV;
    }
}