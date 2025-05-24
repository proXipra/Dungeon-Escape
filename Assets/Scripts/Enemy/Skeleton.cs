using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    public int Health { get; set; }

    protected override void Init()
    {
        base.Init();
        Health = base.health;
    }


    public void Damage()
    {
        Health--;
        isHit = true;
        animator.SetTrigger("Hit");
        animator.SetBool("InCombat", true);
        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
