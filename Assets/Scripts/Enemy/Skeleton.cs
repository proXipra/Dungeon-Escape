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
        Debug.Log("Health: " + Health);
        Debug.Log("_health: " + _health);
        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
