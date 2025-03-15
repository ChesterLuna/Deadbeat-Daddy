using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] int currentPoints = 0;
    GameManager gameManager = null;
    [SerializeField] Queue<DateEvent> eventsToPlay = new Queue<DateEvent>();

    void Start()
    {
        gameManager = GameManager.Instance;

        List<DateEvent> events = gameManager.GetEvents();
        events.OrderBy(i => Guid.NewGuid()).ToList();
        
        eventsToPlay = new Queue<DateEvent>(events);
    }

    public void DrawEvent()
    {
        DateEvent nextEvent = null;
        if (eventsToPlay.TryDequeue(out nextEvent) == false)
        {
            Debug.Log("Tried to Dequeue but didn't work");
        }
        PlayEvent(nextEvent);
    }
    public void PlayEvent(DateEvent nextEvent)
    {
        //Show Card, display assets
        //Change text
        //Add Points
    }


    public void EndDate()
    {
        gameManager.ClearEvents();
        gameManager.AddPoints(currentPoints);
    }
}
