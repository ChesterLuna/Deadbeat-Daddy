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

    }

    public void PlaceGift(Gift randomGift)
    {
        giftDescription = randomGift.giftDescription;
        giftText.text = giftDescription;

        giftImage.sprite = randomGift.icon;

        giftPrice.text = "$ " + randomGift.price.ToString();

        Debug.Log("Gift drawn: " + giftDescription);

    }
    // void DisplayDiscription();
}
