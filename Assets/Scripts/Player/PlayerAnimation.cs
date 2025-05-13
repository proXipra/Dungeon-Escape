using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _spriteAnim;
    private Animator _swordAnim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _spriteAnim = transform.GetChild(0).GetComponent<Animator>();
        _swordAnim = transform.GetChild(1).GetComponent<Animator>();
    }

    public void Move(float move)
    {
        _spriteAnim.SetFloat("Move", Mathf.Abs(move));
    }

    public void UpdateBool(string name, bool value)
    {
        _spriteAnim.SetBool(name, value);
    }

    public void Attack()
    {
        _spriteAnim.SetTrigger("Attack");
        _swordAnim.SetTrigger("SwordAnimation");
    }
}
