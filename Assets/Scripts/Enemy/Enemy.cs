using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected int _health;
    [SerializeField] protected int _speed;
    protected int _gem;

    protected virtual void Attack()
    {

    }

    protected abstract void Update();
}
