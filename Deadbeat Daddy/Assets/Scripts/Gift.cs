using UnityEngine;

[CreateAssetMenu(fileName = "Gift", menuName = "Scriptable Objects/Gift")]
public class Gift : ScriptableObject
{
    [SerializeField] public string giftDescription;
}
