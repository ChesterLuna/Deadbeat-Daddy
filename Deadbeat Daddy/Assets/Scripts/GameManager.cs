using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    GameManager Instance = null;

    [SerializeField] public int lovePoints = 10;
    [SerializeField] public int winCondition = 69;
    [SerializeField] bool endGame;

    [SerializeField] List<DateEvent> nextEvents= new List<DateEvent>();

    private void Awake()
    {
        // Make a singleton
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }


    void ClearEvents()
    {
        nextEvents.Clear();
    }

    void AddEvents(List<DateEvent> events)
    {
        nextEvents.AddRange(events);
    }

    void AddEvent(DateEvent dateEvent)
    {
        nextEvents.Add(dateEvent);
    }

    List<DateEvent> GetEvents()
    {
        return nextEvents;
    }

    void AddPoints(int points)
    {
        lovePoints += points;

        CheckEndingCondition();

    }

    bool CheckEndingCondition()
    {
        if (lovePoints >= winCondition || lovePoints <= 0)
        {
            endGame = true;
            return true;
        }
        endGame = false;
        return false;
    }


    bool CheckWinningCondition()
    {
        if (lovePoints >= winCondition)
        {
            endGame = true;
            return true;
        }
        return false;
    }

}
