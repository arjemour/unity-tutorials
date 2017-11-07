using UnityEngine;

public class Attacker : MonoBehaviour
{
    private float CurrentSpeed;
    public float SpawnRate;
    private GameObject currentTarget;
    private Animator animator;

    // Use this for initialization
    private void Start()
    {
        Rigidbody2D myRigidbody = gameObject.AddComponent<Rigidbody2D>();
        myRigidbody.isKinematic = true;
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector3.left * CurrentSpeed * Time.deltaTime);
        if (!currentTarget)
        {
            animator.SetBool("IsAttacking", false);
        }
    }

    public void SetSpeed(float speed)
    {
        CurrentSpeed = speed;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (!currentTarget)
            return;

        Health health = currentTarget.GetComponent<Health>();

        if (!health)
            return;

        health.DealDamage(damage);
    }

    public void Attack(GameObject obj)
    {
        currentTarget = obj;
    }
}