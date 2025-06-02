using UnityEngine;

public class SpiderAnimationEvent : MonoBehaviour
{
    private Spider _spider;

    private void Start()
    {
        _spider = GetComponentInParent<Spider>() ?? 
            throw new MissingComponentException("Spider component is NULL");
    }


    void Fire()
    {
        _spider.Attack();
    }

}
