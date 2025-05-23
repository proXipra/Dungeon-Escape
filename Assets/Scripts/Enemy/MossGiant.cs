using UnityEngine;
public class MossGiant : Enemy, IDamageable
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
        Debug.Log("Health: "+ Health);
        Debug.Log("_health: "+ health);
        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
