using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSlotManager : MonoBehaviour
{
    [SerializeField] List<GameObject> slots = new List<GameObject>();
    [SerializeField] int nextSlotInd = 0;
    [SerializeField] public int maximumSlots = 0;
    [SerializeField] GameObject cardPrefab;
    [SerializeField] Canvas canvas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        List<Transform> _tempChildren = new List<Transform>(GetComponentsInChildren<Transform>());
        canvas = FindFirstObjectByType<Canvas>();

        foreach (Transform child in _tempChildren)
        {
            slots.Add(child.gameObject);
        }
        slots.Remove(transform.gameObject);

        // slots = new List<GameObject>(GetComponentsInChildren<Transform>());
        maximumSlots = slots.Count;
    }

    public void PlaceInNextSlot(Sprite sprite, Transform positionToPull = null, bool hasAnimation = true)
    {
        if(nextSlotInd >= maximumSlots)
        {
            Debug.Log("Maximum slots reached");
            return;
        }

        GameObject nextSlot = slots[nextSlotInd];
        nextSlotInd++;

        if(hasAnimation)
        {
            Debug.Log("Next location is " + nextSlot.transform.position);
            GameObject cardToPull = Instantiate(cardPrefab, positionToPull.position, Quaternion.identity, canvas.transform);
            cardToPull.GetComponent<Image>().sprite = sprite;
            cardToPull.GetComponent<RectTransform>().sizeDelta = nextSlot.GetComponent<RectTransform>().sizeDelta;
            // StartCoroutine(MoveObjectTo(cardToPull, nextSlot.transform.position, 0.5f));
            StartCoroutine(DrawCardAnimation(cardToPull, nextSlot, sprite, 0.5f));
        }
        else
        {
            Image nextImage = nextSlot.GetComponent<Image>();
            nextImage.sprite = sprite;
            Color whiteAlpha = Color.white;
            nextImage.color = whiteAlpha;
        }

    }

    IEnumerator DrawCardAnimation(GameObject cardToPull, GameObject nextSlot, Sprite sprite, float time)
    {
        Vector3 startingPos = cardToPull.transform.position;
        Vector3 finalPos = nextSlot.transform.position;

        float elapsedTime = 0;

        while (elapsedTime < time)
        {
            cardToPull.transform.position = Vector3.Lerp(startingPos, finalPos, elapsedTime / time);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        Destroy(cardToPull);
        Image nextImage = nextSlot.GetComponent<Image>();
        nextImage.sprite = sprite;
        Color whiteAlpha = Color.white;
        nextImage.color = whiteAlpha;
    }

    // IEnumerator MoveObjectTo(GameObject gameObject, Vector3 finalPos, float time)
    // {
    //     Vector3 startingPos = gameObject.transform.position;

    //     float elapsedTime = 0;

    //     while (elapsedTime < time)
    //     {
    //         gameObject.transform.position = Vector3.Lerp(startingPos, finalPos, elapsedTime / time);
    //         elapsedTime += Time.deltaTime;
    //         yield return null;
    //     }
    //     Destroy(gameObject);
    // }

}
