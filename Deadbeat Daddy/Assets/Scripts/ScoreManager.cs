using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText = GetComponentInChildren<TMP_Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = GameManager.Instance.lovePoints.ToString();
        
    }
}
