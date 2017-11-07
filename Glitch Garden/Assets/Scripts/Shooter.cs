using UnityEngine;

public class Shooter : MonoBehaviour
{
    private Animator animator;
    public GameObject Gun;
    private Spawner laneSpawner;
    public GameObject Projectile;

    private GameObject projectileParent;

    private void Start()
    {
        animator = GetComponent<Animator>();

        projectileParent = GameObject.Find("Projectiles");
        if (!projectileParent)
            projectileParent = new GameObject("Projectiles");

        SetLaneSpawner();
    }

    private void Update()
    {
        if (IsAttackerAheadOfLane())
            animator.SetBool("IsAttacking", true);
        else
            animator.SetBool("IsAttacking", false);
    }

    private bool IsAttackerAheadOfLane()
    {
        if (laneSpawner.transform.childCount <= 0)
            return false;

        foreach (Transform child in laneSpawner.transform)
            if (child.transform.position.x > transform.position.x)
                return true;

        return false;
    }

    private void SetLaneSpawner()
    {
        Spawner[] spawnerArray = FindObjectsOfType<Spawner>();
        foreach (Spawner spawner in spawnerArray)
            if (spawner.transform.position.y == transform.position.y)
            {
                laneSpawner = spawner;
                return;
            }
    }

    private void FireGun()
    {
        GameObject newProjectile = Instantiate(Projectile);
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = Gun.transform.position;
    }
}