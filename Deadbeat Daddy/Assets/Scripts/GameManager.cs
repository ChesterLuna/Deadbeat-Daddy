using UnityEngine;

public class GameManager : MonoBehaviour
{

    GameManager Instance = null;

    [SerializeField] public int lovePoints = 10;
    [SerializeField] public int winCondition = 69;
    



    private void Awake()
    {
        // Make a singleton
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
