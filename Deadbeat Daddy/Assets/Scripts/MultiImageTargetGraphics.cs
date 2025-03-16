using UnityEngine;
using UnityEngine.UI;

public class MultiImageTargetGraphics : MonoBehaviour
{
    [SerializeField] Image[] targetImages;

    public Image[] GetTargetImages => targetImages;
}