using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GiftController : MonoBehaviour
{   
    private string giftDescription;
    private Image giftImage;
    private TMP_Text giftText;
    private TMP_Text giftPrice;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        giftText = transform.GetChild(0).GetComponent<TMP_Text>();
        giftImage = GetComponent<Image>();
        giftPrice = transform.GetChild(1).GetComponent<TMP_Text>();

        DrawGift();
        Debug.Log("Grabing Gift Description: " + giftDescription);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DrawGift()
    {
        Debug.Log("Drawing gift...");
        List<Gift> gifts = GameManager.Instance.gifts;
        int randomIndex = Random.Range(0, gifts.Count);
        Debug.Log("Random count: " + gifts.Count);
        Gift randomGift = gifts[randomIndex];
        giftDescription = randomGift.giftDescription;
        giftText.text = giftDescription;

        giftImage.sprite = randomGift.icon;

        giftPrice.text = "$ " + randomGift.price.ToString();

        Debug.Log("Gift drawn: " + giftDescription);
    }
    // void DisplayDiscription();
}
