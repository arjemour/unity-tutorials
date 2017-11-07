using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform PlayerSpawnPoints;

    private bool Respawn;
    private Transform[] _spawnPoints;

    // Use this for initialization
    private void Start()
    {
        _spawnPoints = PlayerSpawnPoints.GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(2))
            Respawn = true;

        if (Respawn)
        {
            RespawnPlayer();
            Respawn = false;
        }
    }

    private void RespawnPlayer()
    {
        int i = Random.Range(1, _spawnPoints.Length);
        transform.position = _spawnPoints[i].transform.position;
    }

    private void OnFindClearArea()
    {
        Invoke("DropFlare", 3f);
    }

    private void DropFlare()
    {
        
    }
}