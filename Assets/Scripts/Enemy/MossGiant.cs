using System.Collections;
using System.Linq;
using UnityEngine;

public class MossGiant : Enemy
{
    [SerializeField] private Transform waypointsParent;
    private Transform[] waypoints;
    private Vector3 _targetPos;
    private Animator _animator;
    private SpriteRenderer _sprite;

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _sprite = GetComponentInChildren<SpriteRenderer>();

        if (waypointsParent != null)
        {
            waypoints = waypointsParent.GetComponentsInChildren<Transform>().Where(t => t != waypointsParent).ToArray();
            foreach (var item in waypoints)
            {
                Debug.Log("Point to Go: " + item);
            }
            transform.position = new Vector3(waypoints[0].position.x, transform.position.y, transform.position.z);
        }
        else
        {
            Debug.LogError("WaypointsParent is null");
        }
    }

    protected override void Update()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsTag("Idle"))
        {
            
            return;
        }

        if (_targetPos == waypoints[0].position)
        {
            _sprite.flipX = true;
        }
        else if (_targetPos == waypoints[1].position)
        {
            _sprite.flipX = false;
        }

        Movement();
    }
    

    private void Movement()
    {
        if (transform.position.x == waypoints[0].position.x)
        {
            _targetPos = waypoints[1].position;
            _animator.SetTrigger("Idle");
            //_sprite.flipX = false;
        }
        else if (transform.position.x == waypoints[1].position.x)
        {
            _targetPos = waypoints[0].position;
            _animator.SetTrigger("Idle");
            //_sprite.flipX = true;
        }


        transform.position = Vector3.MoveTowards(transform.position, _targetPos, _speed * Time.deltaTime);
    }

    protected override void Attack()
    {
        base.Attack();
    }

    
}
