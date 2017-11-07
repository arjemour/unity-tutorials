using UnityEngine;

public class ClearArea : MonoBehaviour
{
    private float _timeSinceLastTrigger = 0;
    private bool _foundClearArea = false;

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        _timeSinceLastTrigger += Time.deltaTime;
        if (_timeSinceLastTrigger > 1 && Time.realtimeSinceStartup > 10 && !_foundClearArea)
        {
            SendMessageUpwards("OnFindClearArea");
            _foundClearArea = true;
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.tag != "Player")
        {
            _timeSinceLastTrigger = 0;
        }
    }
}