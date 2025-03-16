using TMPro;
using Unity.XR.GoogleVr;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text dayNumber;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText = transform.GetChild(0).GetComponent<TMP_Text>();
        dayNumber = transform.GetChild(1).GetComponent<TMP_Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance == null)
    {
        Debug.LogError("GameManager.Instance is null!");
        return;
    }
        scoreText.text = GameManager.Instance.lovePoints.ToString();
        dayNumber.text = GameManager.Instance.day.ToString();
        
    }
}
