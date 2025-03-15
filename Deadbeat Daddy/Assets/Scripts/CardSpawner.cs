using UnityEngine;

public class CardSpawner : MonoBehaviour
{
    [SerializeField] GameObject cardObject;
    [SerializeField] RectTransform startPoint;
    [SerializeField] int nextCardMovement;

    [SerializeField] int cardsDisplayed;
    [SerializeField] int maximumCards;

    [SerializeField] int x_delta = 1;
    [SerializeField] int y_delta = 1;
    [SerializeField] int rotation_delta = 1;

    public void SpawnCards(int n)
    {
        RectTransform nextPoint = startPoint;
        for (int i = 0; i < n; i++)
        {
            int x_placement = Random.Range(-x_delta, x_delta);
            int y_placement = Random.Range(-y_delta, y_delta);
            int rotation_placement = Random.Range(-rotation_delta, rotation_delta);

            Vector3 spawnPoint = nextPoint.position + new Vector3(x_placement, y_placement, 0);
            SpawnCards(spawnPoint);
            nextPoint
        }
    }

    private void SpawnCards(Vector3 pos)
    {
        Instantiate(cardObject, pos, Quaternion.identity, this.transform);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(cardObject == null)
        {
            Debug.Log("The card prefab has not been set!");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
