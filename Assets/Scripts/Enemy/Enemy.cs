using System;
using System.Linq;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int _health;
    [SerializeField] protected float _speed;
    [SerializeField] protected int _gem;

    [SerializeField] protected Transform waypointsParent;
    protected Transform[] waypoints;
    protected Vector3 _targetPos;
    protected Animator _animator;
    protected SpriteRenderer _sprite;

    protected virtual void Init()
    {
        waypoints = waypointsParent != null ? waypointsParent.GetComponentsInChildren<Transform>().
            Where(i => i != waypointsParent).ToArray() : throw new Exception("Waypoint Parent is null!");

        _animator = GetComponentInChildren<Animator>() ??
            throw new MissingComponentException("Animator is NULL!");
        _sprite = GetComponentInChildren<SpriteRenderer>() ??
            throw new MissingComponentException("SpriteRenderer is NULL");
    }

    private void Start()
    {
        Init();
    }

    protected virtual void Update()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsTag("Idle"))
        {
            return;
        }

        Movement();
    }

    protected virtual void Movement()
    {
        _sprite.flipX = _targetPos == waypoints[0].position;

        if (transform.position.x == waypoints[0].position.x)
        {
            _targetPos = waypoints[1].position;
            //_animator.SetTrigger("Idle");
        }
        else if (transform.position.x == waypoints[1].position.x)
        {
            _targetPos = waypoints[0].position;
            //_animator.SetTrigger("Idle");
        }

        transform.position = Vector3.MoveTowards(transform.position, _targetPos, _speed * Time.deltaTime);

        if (transform.position.x == waypoints[0].position.x || transform.position.x == waypoints[1].position.x)
        {
            _animator.SetTrigger("Idle");

        }
    }

}
