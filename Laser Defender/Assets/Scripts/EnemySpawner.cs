using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private bool allMembersDead = false;
    public GameObject enemyPrefab;
    public float height = 20;
    private bool movingRight = true;
    public float speed = 1;
    public float width = 8;
    private float xMax;
    private float xMin;
    public float SpawnDelay = 1;

    // Use this for initialization
    private void Start()
    {
        var distanceToCamera = transform.position.z - Camera.main.transform.position.z;
        var leftBoundry = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera));
        var rightBoundry = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceToCamera));
        xMax = rightBoundry.x;
        xMin = leftBoundry.x;

        SpawnUntilFull();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }

    // Update is called once per frame
    private void Update()
    {
        if (movingRight)
            transform.position += Vector3.right * speed * Time.deltaTime;
        else
            transform.position += Vector3.left * speed * Time.deltaTime;

        var rightEdgeOfFormation = transform.position.x + 0.5f * width;
        var leftEdgeOfFormation = transform.position.x - 0.5f * width;

        if (leftEdgeOfFormation < xMin)
            movingRight = true;
        else if (rightEdgeOfFormation > xMax)
            movingRight = false;

        if (AllMembersDead())
        {
            SpawnUntilFull();
        }
    }

    private bool AllMembersDead()
    {
        foreach (Transform childPositionGameObject in transform)
            if (childPositionGameObject.childCount > 0)
                return false;
        return true;
    }

    private void SpawnEnemies()
    {
        foreach (Transform child in transform)
        {
            var enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity);
            enemy.transform.parent = child.transform;
        }
    }

    private void SpawnUntilFull()
    {
        Transform freePosition = NextFreePosition();
        if (freePosition)
        {
            var enemy = Instantiate(enemyPrefab, freePosition.transform.position, Quaternion.identity);
            enemy.transform.parent = freePosition.transform;
        }

        if (freePosition)
        {
            Invoke("SpawnUntilFull", SpawnDelay);
        }
    }

    private Transform NextFreePosition()
    {
        foreach (Transform childPositionGameObject in transform)
            if (childPositionGameObject.childCount <= 0)
                return childPositionGameObject;
        return null;
    }
}