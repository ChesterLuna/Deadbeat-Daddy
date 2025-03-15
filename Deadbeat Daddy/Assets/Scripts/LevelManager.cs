using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] int currentPoints = 0;
    GameManager gameManager = null;
    [SerializeField] Queue<DateEvent> eventsToPlay = new Queue<DateEvent>();


    [Header("References")]
    [SerializeField] Image dateImage = null;
    [SerializeField] Image zombieFace = null;
    [SerializeField] TMP_Text dateDescription = null;

    [SerializeField] Button drawButton = null;
    [SerializeField] Button endButton = null;

    [SerializeField] TMP_Text scoreText = null;

    void Start()
    {
        gameManager = GameManager.Instance;

        // Randomize cards
        List<DateEvent> events = gameManager.GetEvents();
        events.OrderBy(i => Guid.NewGuid()).ToList();
        eventsToPlay = new Queue<DateEvent>(events);


        // Get references
        if(dateImage == null)
        {
            dateImage = GameObject.Find("Date Image").GetComponent<Image>();
        }
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
