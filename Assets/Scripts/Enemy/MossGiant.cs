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
        if (isDeath)
        {
            return;
        }
        Health--;
        isHit = true;
        animator.SetTrigger("Hit");
        animator.SetBool("InCombat", true);
        //Debug.Log("Combat Mode: "+ animator.GetBool("InCombat"));
        if (Health <= 0)
        {

            isDeath = true;
            animator.SetTrigger("Death");
            SpawnDiamonds();    
        }
    }

    private void SpawnDiamonds()
    {
        if (diamondPrefab == null)
        {
            Debug.LogError("Diamond is null");
            return;
        }

        for (int i = 0; i < gem; i++)
        {
            Vector2 spawnPos = new Vector2(transform.position.x, transform.position.y + spawnHeightOffset);
            GameObject diamond = Instantiate(diamondPrefab, spawnPos, Quaternion.identity);

            Rigidbody2D rb = diamond.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                float randomX = Random.Range(-gemSpawnForceX, gemSpawnForceX);
                rb.AddForce(new Vector2(randomX, gemSpawnForceY), ForceMode2D.Impulse);
            }
            else
            {
                Debug.LogError("Rigidbody of Diamond is null");
            }


        }
    }
}
