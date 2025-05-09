using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanningManager : MonoBehaviour
{

    GameManager gameManager;
    CardSlotManager cardSlotManager;
    // SceneLoader sceneLoader;
    [SerializeField] Button dateButton;

    [Header("Sprites")]
    [SerializeField] Sprite starSprite;
    [SerializeField] Sprite moonSprite;
    [SerializeField] Sprite sunSprite;

    [Header("GameObjects")]
    [SerializeField] GameObject starObject;
    [SerializeField] GameObject moonObject;
    [SerializeField] GameObject sunObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameManager.Instance;
        cardSlotManager = FindFirstObjectByType<CardSlotManager>();
        // if(!TryGetComponent<SceneLoader>(out sceneLoader))
        // {
        //     print("Scene Loader was not found");
        // }

        // gameManager.ClearEvents();

        // Re add all events
        foreach (var dateEvent in gameManager.GetEvents())
        {
            cardSlotManager.PlaceInNextSlot(dateEvent.icon, hasAnimation: false);
            dateButton.interactable = true;

        }
    }

    public void BuyCard(string type)
    {
        int price = 0;
        Debug.Log(transform.position);
        switch (type)
        {
            case "star":
                price = 1;
                break;
            case "moon":
                price = 3;
                break;
            case "sun":
                price = 10;
                break;
            default:
                price = 3;
                print("Did not ger correct price");
                break;
        }

        if (gameManager.lovePoints >= price && gameManager.GetEvents().Count < cardSlotManager.maximumSlots)
        {
            gameManager.lovePoints -= price;
            DrawFromPool(type);

            PlaceNextCard(type);

        }
        //TODO play incorrect sound
    }

    private void PlaceNextCard(string type)
    {
        Sprite spriteToPlace;
        switch (type)
        {
            case "star":
                cardSlotManager.PlaceInNextSlot(starSprite, starObject.transform);
                break;
            case "moon":
                cardSlotManager.PlaceInNextSlot(moonSprite, moonObject.transform);
                break;
            case "sun":
                cardSlotManager.PlaceInNextSlot(sunSprite, sunObject.transform);
                break;
            default:
                cardSlotManager.PlaceInNextSlot(starSprite);
                print("Did not get correct place");
                break;
        }
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

        dateButton.interactable = true;

    }
    

    // public void StartDate()
    // {
    //     sceneLoader("");

    // }
}
