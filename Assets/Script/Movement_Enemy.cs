using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Enemy : MonoBehaviour
{
    public float moveSpeed = 3f;          
    public float detectionRange = 5f;      
    public Transform detectionPoint;       
    public Transform player;               
    public float facingAngleOffset = -90f;
    public float chaseTimeAfterLost = 2f;

    private Rigidbody2D rb;
    private Vector2 movement;
    private float lastSeenTimer = 0f;
    private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (player == null || detectionPoint == null) return;

        float distanceToPlayer = Vector2.Distance(detectionPoint.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            movement = direction;

            lastSeenTimer = chaseTimeAfterLost;
        }
        else if (lastSeenTimer > 0f)
        {

            lastSeenTimer -= Time.deltaTime;
        }
        else
        {

            movement = Vector2.zero;
        }

        animator.SetBool("IsMoving", movement != Vector2.zero);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        if (movement != Vector2.zero)
        {
            float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
            rb.rotation = angle + facingAngleOffset;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (detectionPoint != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(detectionPoint.position, detectionRange);
        }
    }
}
