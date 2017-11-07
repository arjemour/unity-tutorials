using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class Lizard : MonoBehaviour
{
    private Animator animator;
    private Attacker attacker;

    // Use this for initialization
    private void Start()
    {
        animator = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject obj = collider.gameObject;

        if (!obj.GetComponent<Defender>())
            return;

        animator.SetBool("IsAttacking", true);
        attacker.Attack(obj);
    }
}