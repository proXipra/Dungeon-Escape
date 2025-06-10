using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("GameManger is Null!");
            }
            return _instance;   
        }
    }

    public bool HasCard { get; set; }
    private void Awake()
    {
        _instance = this;
    }
}
