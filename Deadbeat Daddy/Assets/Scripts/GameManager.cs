using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    [SerializeField] public int lovePoints = 10;
    [SerializeField] public int winCondition = 69;
    [SerializeField] bool endGame;

    [SerializeField] List<DateEvent> nextEvents= new List<DateEvent>();
    [SerializeField] public List<Gift> gifts = new List<Gift>();

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


    public void ClearEvents()
    {
        nextEvents.Clear();
    }

    public void AddEvents(List<DateEvent> events)
    {
        nextEvents.AddRange(events);
    }

    void AddEvent(DateEvent dateEvent)
    {
        nextEvents.Add(dateEvent);
    }

    public List<DateEvent> GetEvents()
    {
        return nextEvents;
    }

    public void AddPoints(int points)
    {
        lovePoints += points;

        CheckEndingCondition();

    }

    public bool CheckEndingCondition()
    {
        if (lovePoints >= winCondition || lovePoints <= 0)
        {
            endGame = true;
            return true;
        }
        endGame = false;
        return false;
    }


    public bool CheckWinningCondition()
    {
        if (lovePoints >= winCondition)
        {
            endGame = true;
            return true;
        }
        return false;
    }

}
