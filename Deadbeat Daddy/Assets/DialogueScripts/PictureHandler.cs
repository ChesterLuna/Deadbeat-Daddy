using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PictureHandler : MonoBehaviour
{
    [SerializeField] Sprite[] character1Portraits;
    //[SerializeField] GameObject[] portraitStands;
    [SerializeField] GameObject portrait1Stand;

    [SerializeField] GameObject picture1Displayed;
    [SerializeField] bool picture1Shown = false;

    [SerializeField] Sprite[] character2Portraits;
    //[SerializeField] GameObject[] portraitStands;
    [SerializeField] GameObject portrait2Stand;

    [SerializeField] GameObject picture2Displayed;
    [SerializeField] bool picture2Shown = false;

    public void UpdatePortrait1(int index)
    {
        portrait1Stand.GetComponent<Image>().sprite = character1Portraits[index];
    }

    public void UpdatePortrait2(int index)
    {
        portrait2Stand.GetComponent<Image>().sprite = character2Portraits[index];
    }


    // public void DisplayPicture()
    // {
    //     if (pictureShown == false)
    //     {
    //         pictureDisplayed.SetActive(true);
    //         pictureShown = true;
    //         return;
    //     }
    //     if (pictureShown == true)
    //     {
    //         pictureDisplayed.SetActive(false);
    //         pictureShown = false;
    //         return;
    //     }
    // }

}
