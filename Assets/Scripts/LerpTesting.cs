using UnityEngine;

public class LerpTesting : MonoBehaviour
{
    private float lerpedValue;
    private float start = 0;
    private float end = 10;

    private float duration = 3f;
    private float timeElapsed;

    void Update()
    {
        if (timeElapsed < duration)
        {
            float t = timeElapsed / duration;
            lerpedValue = Mathf.Lerp(start, end, t);
            Debug.Log(timeElapsed);
            timeElapsed += Time.deltaTime;
        }
    }
}
