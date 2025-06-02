
using Unity.VisualScripting;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    public int Health { get; set; }
    [SerializeField] private GameObject _acid;
    [SerializeField] private float _combatDistance = 5f;

    protected override void Init()
    {
        base.Init();
        Health = base.health;
    }

    protected override void Update()
    {
        Vector3 dir = transform.position - player.position;
        float distance = dir.sqrMagnitude;
        bool inCombat = distance < _combatDistance * _combatDistance;
        //Debug.Log("Name: " + transform.name + " Distance: " + distance);
        if (inCombat)
        {
            animator.SetBool("InCombat", true);
        }
        else
        {
            animator.SetBool("InCombat", false);
        }
        sprite.flipX = dir.x > 0;
    }

    public void Damage()
    {
        if (isDeath)
        {
            return;
        }
        Health--;
        
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


    public void Attack()
    {
        GameObject acid = Instantiate(_acid, transform.position, Quaternion.identity);
        acid.GetComponent<AcidEffect>().AssignAcidDirection(sprite.flipX);
    }

}
