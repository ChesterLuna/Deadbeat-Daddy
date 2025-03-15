using System;
using UnityEngine;

[CreateAssetMenu(fileName = "DateEvent", menuName = "Scriptable Objects/DateEvent")]
public class DateEvent : ScriptableObject
{
    [SerializeField] public String eventName;
    [SerializeField] public String description;
    [SerializeField] public Sprite icon;
    [SerializeField] public Sprite picture;
    [SerializeField] public int reward;
}
