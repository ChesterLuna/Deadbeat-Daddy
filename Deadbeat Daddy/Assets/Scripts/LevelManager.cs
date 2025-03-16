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
    [SerializeField] DateEvent defaultEvent;

    [SerializeField] List<int> pointsAdded = new List<int>();


    [Header("References")]
    [SerializeField] Image dateImage = null;
    [SerializeField] Image cardImage = null;
    [SerializeField] Image zombieFace = null;
    [SerializeField] TMP_Text dateDescription = null;

    [SerializeField] Button endButton = null;

    [SerializeField] TMP_Text scoreText = null;

    [SerializeField] CardSpawner cardSpawner = null;

    [SerializeField] DialogueManager dialogueManager = null;

    [SerializeField] SceneLoader sceneLoader = null;

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
        if (scoreText == null) scoreText = GameObject.Find("Score").transform.GetChild(0).GetComponent<TMP_Text>();
        if (dialogueManager == null) dialogueManager = FindFirstObjectByType<DialogueManager>();
        if (sceneLoader == null) sceneLoader = GetComponent<SceneLoader>();

        cardSpawner = FindFirstObjectByType<CardSpawner>();
        cardSpawner.SpawnCards(events.Count());
        SetDefaultScreen();

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
        if(nextEvent.importantEvent && nextEvent.dialogueFile != null)
        {
            dialogueManager.StartDialogue(nextEvent.dialogueFile.ToString());
            SetDefaultScreen();
        }
        else
        {
            //Show Card, display assets
            dateImage.sprite = nextEvent.picture;
            zombieFace.sprite = nextEvent.zombieFace;
            cardImage.sprite = nextEvent.icon;
            //Change text
            dateDescription.text = nextEvent.description;
        }
        //Add Points
        AddCurrentPoints(nextEvent);
    }

    private void SetDefaultScreen()
    {
        //Show Card, display assets
        dateImage.sprite = defaultEvent.picture;
        zombieFace.sprite = defaultEvent.zombieFace;
        cardImage.sprite = defaultEvent.icon;
        //Change text
        dateDescription.text = defaultEvent.description;
    }

    private void AddCurrentPoints(DateEvent nextEvent)
    {
        pointsAdded.Add(nextEvent.reward);
        // currentPoints += nextEvent.reward;

    }

    public int GetCurrentPoints()
    {
        currentPoints = 0;
        foreach (int value in pointsAdded)
        {
            currentPoints += value;
        }
        currentPoints *= gameManager.multiplier;
        return currentPoints;
    }

    public void EndDate()
    {
        NextDay();
        gameManager.ClearEvents();
        gameManager.AddPoints(currentPoints);

        ClearGifts();

        bool isEnding = gameManager.CheckEndingCondition();

        if(isEnding)
        {
            if(gameManager.CheckWinningCondition())
            {
                sceneLoader.LoadScene("WinningScene");
            }
            else
            {
                sceneLoader.LoadScene("LosingScene");

            }
        }
        else
        {
            sceneLoader.LoadScene("DatePlanning");
        }
    }

    private void ClearGifts()
    {
        gameManager.nextGifts.Clear();
        gameManager.chosenGifts.Clear();
        gameManager.giftsChosen = false;
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

    // proceed to the next day
    void NextDay()
    {
        gameManager.day++;
    }

}
