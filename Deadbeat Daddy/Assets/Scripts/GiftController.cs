using System.Collections.Generic;
using UnityEngine;

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
        List<Gift> gifts = GameManager.Instance.gifts;
        int index = Random.Range(0, gifts.Count);
        Gift gift = gifts[index];
        string giftDescription = gifts[index].giftDescription;
        

    }
    // void DisplayDiscription();
}
