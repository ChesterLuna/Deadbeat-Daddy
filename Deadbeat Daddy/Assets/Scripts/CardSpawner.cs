using UnityEngine;
using UnityEngine.UI;

public class CardSpawner : MonoBehaviour
{
    [SerializeField] LevelManager levelManager;

    [SerializeField] GameObject cardObject;
    [SerializeField] RectTransform startPoint;
    [SerializeField] RectTransform endPoint;
    [SerializeField] RectTransform nextPoint;
    [SerializeField] int nextCardMovement = 50;

    [SerializeField] int cardsDisplayed;
    [SerializeField] int maximumCards;

    [SerializeField] int x_delta = 1;
    [SerializeField] int y_delta = 1;
    [SerializeField] int rotation_delta = 1;

    [SerializeField] Button drawButton;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (cardObject == null)
        {
            Debug.Log("The card prefab has not been set!");
        }

        startPoint = GameObject.Find("Start Point").GetComponent<RectTransform>();
        endPoint = GameObject.Find("End Point").GetComponent<RectTransform>();

        levelManager = FindFirstObjectByType<LevelManager>();
        drawButton = GetComponent<Button>();
    }

    public void SpawnCards(int n)
    {
        nextPoint.position = startPoint.position;
        for (int i = 0; i < n; i++)
        {
            int x_placement = Random.Range(-x_delta, x_delta);
            int y_placement = Random.Range(-y_delta, y_delta);
            int rotation_placement = Random.Range(-rotation_delta, rotation_delta);

            Vector3 spawnPoint = nextPoint.position + new Vector3(x_placement, y_placement, 0);
            SpawnCards(spawnPoint, rotation_placement);
            nextPoint.localPosition += new Vector3(0, -nextCardMovement,0);

            if(nextPoint.position.y <= endPoint.position.y)
            {
                nextPoint.position = startPoint.position;
            }
            cardsDisplayed++;
        }
    }

    private void SpawnCards(Vector3 pos, int rotation)
    {
        GameObject cardSpawned = Instantiate(cardObject, pos, Quaternion.identity, this.transform);
        cardSpawned.transform.Rotate(0f, 0f, rotation);
        cardSpawned.transform.SetAsLastSibling();
        drawButton.targetGraphic = cardSpawned.GetComponent<Image>();
    }

    public void DrawCard()
    {
        if (cardsDisplayed <= 0)
        {
            print("Can't draw card because there are no more cards displayed");
        }

        // Draw visual card (Delete gameobject)
        GameObject lastCard = GetLastChild();
        DestroyImmediate(lastCard);
        cardsDisplayed--;
        if (cardsDisplayed == 0)
        {
            // Either change scene or prepare to change scene
        }
        drawButton.targetGraphic = GetLastChild().GetComponent<Image>();

        // Draw and play card
        levelManager.DrawEvent();


    }

    private GameObject GetLastChild()
    {
        return transform.GetChild(transform.childCount - 1).gameObject;
    }
}
