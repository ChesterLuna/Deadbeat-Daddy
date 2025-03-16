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
    [SerializeField] Image cardImage = null;
    [SerializeField] Image zombieFace = null;
    [SerializeField] TMP_Text dateDescription = null;

    [SerializeField] Button endButton = null;

    [SerializeField] TMP_Text scoreText = null;

    [SerializeField] CardSpawner cardSpawner = null;

    [SerializeField] DialogueManager dialogueManager = null;

    void Start()
    {
        gameManager = GameManager.Instance;

        // Randomize cards
        List<DateEvent> events = gameManager.GetEvents();
        Shuffle(events);
        eventsToPlay = new Queue<DateEvent>(events);


        // Get references
        if (dateImage == null) dateImage = GameObject.Find("Date Image").GetComponent<Image>();
        if (cardImage == null) cardImage = GameObject.Find("Date Card Image").GetComponent<Image>();
        if (zombieFace == null) zombieFace = GameObject.Find("Zombie Face").GetComponent<Image>();
        if (dateDescription == null) dateDescription = GameObject.Find("Date Text").GetComponent<TMP_Text>();
        if (endButton == null) endButton = GameObject.Find("Stop Button").GetComponent<Button>();
        if (scoreText == null) scoreText = GameObject.Find("Score").GetComponent<TMP_Text>();
        if (dialogueManager == null) dialogueManager = FindFirstObjectByType<DialogueManager>();

        cardSpawner = FindFirstObjectByType<CardSpawner>();
        cardSpawner.SpawnCards(events.Count());
    }
    void Update()
    {
        // TODO change it to only run when changed.
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = GetCurrentPoints().ToString();
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
        dateImage.sprite = nextEvent.picture;
        zombieFace.sprite = nextEvent.zombieFace;
        cardImage.sprite = nextEvent.icon;
        //Change text
        dateDescription.text = nextEvent.description;
        //Add Points
        if(nextEvent.importantEvent)
        {

        }
        AddCurrentPoints(nextEvent);
    }

    private void AddCurrentPoints(DateEvent nextEvent)
    {
        currentPoints += nextEvent.reward;

    }

    public int GetCurrentPoints()
    {
        return currentPoints * gameManager.multiplier;
    }

    public void EndDate()
    {
        gameManager.ClearEvents();
        gameManager.AddPoints(currentPoints);
    }

    // Fisher Yates shuffle
    public static void Shuffle<T>(IList<T> list)
    {
        int n = list.Count;
        for (int i = 0; i < (n - 1); i++)
        {
            int r = i + Random.Range(0, n - i);
            T t = list[r];
            list[r] = list[i];
            list[i] = t;
        }
    }

}
