using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    public int Health { get; set; }

    protected override void Init()
    {
        base.Init();
        Health = base._health;
    }
    public void Damage()
    {
        Health--;
        isHit = true;
        _animator.SetTrigger("Hit");
        _animator.SetBool("InCombat", true);
        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
