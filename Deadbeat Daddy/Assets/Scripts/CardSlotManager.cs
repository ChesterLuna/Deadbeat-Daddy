using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSlotManager : MonoBehaviour
{
    [SerializeField] List<Image> slots = new List<Image>();
    [SerializeField] int nextSlotInd = 0;
    [SerializeField] public int maximumSlots = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slots = new List<Image>(GetComponentsInChildren<Image>());
        maximumSlots = slots.Count;
    }

    public void PlaceInNextSlot(Sprite sprite)
    {
        if(nextSlotInd >= maximumSlots)
        {
            Debug.Log("Maximum slots reached");
            return;
        }
        slots[nextSlotInd].sprite = sprite;
        Color whiteAlpha = Color.white;
        slots[nextSlotInd].color = whiteAlpha;
        nextSlotInd++;
    }

}
