using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
    }

    public void Move(float move)
    {
        _anim.SetFloat("Move", Mathf.Abs(move));
    }

    public void UpdateBool(string name, bool value)
    {
        _anim.SetBool(name, value);
    }

    public void InitiateTrigger(string name)
    {
        _anim.SetTrigger(name);
    }
}
