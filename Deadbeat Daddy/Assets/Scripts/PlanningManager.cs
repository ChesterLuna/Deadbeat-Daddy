using System.Collections.Generic;
using UnityEngine;

public class PlanningManager : MonoBehaviour
{

    GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuyCard(string type)
    {
        int price = 0;
        switch (type)
        {
            case "star":
                price = 3;
                break;
            case "moon":
                price = 3;
                break;
            case "sun":
                price = 3;
                break;
            default:
                price = 3;
                print("Did not ger correct price");
                break;
        }

        if (gameManager.lovePoints >= price)
        {
            gameManager.lovePoints -= price;
            DrawFromPool(type);
        }
        //TODO play incorrect sound
    }

    public void DrawFromPool(string poolType)
    {
        List<DateEvent> events = null;
        switch (poolType)
        {
        case "star":
            events = gameManager.starEvents;
            break;
        case "moon":
            events = gameManager.moonEvents;
            break;
        case "sun":
            events = gameManager.sunEvents;
            break;
        default:
            events = gameManager.starEvents;
            print("Did not draw from correct pool");
            break;
        }

        int index = Random.Range(0, events.Count);

        DateEvent chosenEvent =  events[index];

        gameManager.AddEvent(chosenEvent);

    }
}
