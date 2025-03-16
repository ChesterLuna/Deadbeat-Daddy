using System.Collections.Generic;
using UnityEngine;

public class GiftManager : MonoBehaviour
{
    [SerializeField] GiftController[] giftsSlots;
    [SerializeField] List<Gift> currentGifts = new List<Gift>();

    void Start()
    {
        currentGifts.Clear();
        if (!GameManager.Instance.giftsChosen)
        {
            DrawGifts();
            PlaceGifts(currentGifts);
            GameManager.Instance.giftsChosen = true;

        }
        else
        {
            currentGifts.AddRange(GameManager.Instance.chosenGifts);
            PlaceGifts(currentGifts);
        }
    }

    void PlaceGifts(List<Gift> nextGifts)
    {
        int i = 0;
        foreach (GiftController slot in giftsSlots)
        {
            print(nextGifts[i]);
            slot.PlaceGift(nextGifts[i]);
            i++;
        }
    }

    List<Gift> DrawGifts()
    {
        foreach (GiftController slot in giftsSlots)
        {
            print("currentGifts");

            print(currentGifts.Count);
            Gift randomGift = DrawGift();
            currentGifts.Add(randomGift);
            GameManager.Instance.chosenGifts.Add(randomGift);
            print(currentGifts.Count);

        }
        return currentGifts;
    }

    Gift DrawGift()
    {
        // Debug.Log("Drawing gift...");
        List<Gift> gifts = GameManager.Instance.gifts;
        int randomIndex = Random.Range(0, gifts.Count);
        // Debug.Log("Random count: " + gifts.Count);
        // Debug.Log("Index chosen: " + randomIndex);
        Gift randomGift = gifts[randomIndex];

        return randomGift;
    }
}
