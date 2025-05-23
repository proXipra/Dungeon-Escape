using System;
using System.Linq;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected float speed;
    [SerializeField] protected int gem;

    [SerializeField] protected Transform waypointsParent;
    protected Transform[] waypoints;
    protected Vector3 targetPosition;
    protected Animator animator;
    protected SpriteRenderer sprite;

    protected bool isHit;
    private Transform _player;

    protected virtual void Init()
    {
        waypoints = waypointsParent != null ? waypointsParent.GetComponentsInChildren<Transform>().
            Where(i => i != waypointsParent).ToArray() : throw new Exception("Waypoint Parent is null!");

        animator = GetComponentInChildren<Animator>() ??
            throw new MissingComponentException("Animator is NULL!");
        sprite = GetComponentInChildren<SpriteRenderer>() ??
            throw new MissingComponentException("SpriteRenderer is NULL");

        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>() ??
                         throw new MissingComponentException("Animator is NULL!");
    }

    private void Start()
    {
        Init();
    }

    protected virtual void Update()
    {
        if (isHit == true)
        {
            float distance = Vector3.Distance(transform.position, _player.position);
            if (distance > 2f)
            {
                isHit = false;
                animator.SetBool("InCombat", false);
            }
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Idle"))
        {
            return;
        }

        Movement();
    }

    protected virtual void Movement()
    {
        sprite.flipX = targetPosition == waypoints[0].position;

        if (transform.position.x == waypoints[0].position.x)
        {
            targetPosition = waypoints[1].position;
            //_animator.SetTrigger("Idle");
        }
        else if (transform.position.x == waypoints[1].position.x)
        {
            targetPosition = waypoints[0].position;
            //_animator.SetTrigger("Idle");
        }

        if (isHit == false)  
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }

        if (transform.position.x == waypoints[0].position.x || transform.position.x == waypoints[1].position.x)
        {
            animator.SetTrigger("Idle");
        }
    }

}
