using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class Fox : MonoBehaviour
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

        if (obj.GetComponent<Stone>())
        {
            animator.SetTrigger("Jump Trigger");
        }
        else
        {
            animator.SetBool("IsAttacking", true);
            attacker.Attack(obj);
        }
    }
}