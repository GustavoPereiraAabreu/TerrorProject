using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; } //Singleton

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
