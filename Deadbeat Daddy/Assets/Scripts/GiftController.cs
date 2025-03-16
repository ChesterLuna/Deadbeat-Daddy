using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GiftController : MonoBehaviour
{   
    [SerializeField] private string giftDescription;
    [SerializeField] private Image giftImage;
    [SerializeField] private TMP_Text giftText;
    [SerializeField] private TMP_Text giftPrice;
    [SerializeField] private Gift currentGift;
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
        currentGift = randomGift;

    }

    public void GetGift()
    {
        if(GameManager.Instance.lovePoints >= currentGift.price)
        {
            GameManager.Instance.nextGifts.Add(currentGift);
            GameManager.Instance.chosenGifts.Remove(currentGift);
            GameManager.Instance.lovePoints -= currentGift.price;


            giftDescription = " ";
            giftText.text = " ";

            giftImage.sprite = null;

            giftPrice.text = " ";

            currentGift = null;

        }
    }
    // void DisplayDiscription();
}
