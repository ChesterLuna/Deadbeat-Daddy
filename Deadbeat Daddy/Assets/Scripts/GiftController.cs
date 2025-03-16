using UnityEngine;
using UnityEngine.Random;

public class GiftController : MonoBehaviour
{   
    private string giftDescription;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DrawGift()
    {   
        private List<Gift> gifts = GameManager.Instance.gifts;
        Random rand = new Random();
        int index = rand.Next(0, gifts.Count);
        Gift gift = gifts[index];
        string giftDescription = gifts[index].giftDescription;

        

    }
    // void DisplayDiscription();
}
