using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Gift", menuName = "Scriptable Objects/Gift")]
public class Gift : ScriptableObject
{
    [SerializeField] public string giftDescription;
    [SerializeField] public Sprite icon;
    [SerializeField] public int price;
    

    void Start()
    {   
       
    }

}
