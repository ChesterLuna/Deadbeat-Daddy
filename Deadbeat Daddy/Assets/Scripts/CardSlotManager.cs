using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSlotManager : MonoBehaviour
{
    [SerializeField] List<GameObject> slots = new List<GameObject>();
    [SerializeField] int nextSlotInd = 0;
    [SerializeField] public int maximumSlots = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        List<Transform> _tempChildren = new List<Transform>(GetComponentsInChildren<Transform>());

        foreach (Transform child in _tempChildren)
        {
            slots.Add(child.gameObject);
        }
        slots.Remove(transform.gameObject);

        maximumSlots = slots.Count;
    }

    public void PlaceInNextSlot(Sprite sprite)
    {
        if(nextSlotInd >= maximumSlots)
        {
            Debug.Log("Maximum slots reached");
            return;
        }
        Image nextImage = slots[nextSlotInd].GetComponent<Image>();
        nextImage.sprite = sprite;
        Color whiteAlpha = Color.white;
        nextImage.color = whiteAlpha;
        nextSlotInd++;
    }

}
