using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

//using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI charNameText;
    [SerializeField] TextMeshProUGUI dialogueText;
    int animationsDone = 0;
    [SerializeField] GameObject fader;
    [SerializeField] GameObject dialogueCanvas;
    [SerializeField] TextAnalyzer textAnalyzer;

    public Queue<string> names = new Queue<string>();
    public Queue<string> dialogues = new Queue<string>();
    public bool finishedDialogue = false;


    private void Start()
    {

        if (fader == null)
        {
            if (GameObject.Find("Fader") != null)
            {
                fader = GameObject.Find("Fader");
            }
        }

        dialogueCanvas = GameObject.Find("Conv Canvas");


        textAnalyzer = FindFirstObjectByType<TextAnalyzer>();
    }

    public void StartDialogue(string text)
    {
        dialogueCanvas.SetActive(true);

        textAnalyzer.AnalyzeText(text);

        if (finishedDialogue == false)
        {
            Debug.Log("Start Dialogue");

            DisplayNextSentence();
        }
    }

    public void DisplayNextSentence()
    {
        if(finishedDialogue == true)
        {
            return;
        }
        if (dialogues.Count == 0 )
        {
            EndDialogue();
            return;
        }

        string nextName = names.Dequeue();
        string nextSentence = dialogues.Dequeue();


        while(true)
        {
            if (nextName[0] == '@')
            {
                FindObjectOfType<PictureHandler>().UpdatePortrait((int)Char.GetNumericValue(nextName[1]));
                nextName = names.Dequeue();
                continue;
            }
            if (nextName == "Animation")
            {
                DisplayNextAnimation();
                nextName = names.Dequeue();

                continue;
            }
            break;
        }

        // nextName = ChangeName(nextName);
        // nextSentence = ChangeName(nextSentence);
        // nextName = nextName.Replace("Y/N", GameSession.Instance.NameOfProtagonist);
        // nextSentence = nextSentence.Replace("Y/N", GameSession.Instance.NameOfProtagonist);


        charNameText.text = nextName;
        dialogueText.text = nextSentence;
    }

    public void DisplayNextAnimation()
    {
        //string theChoice = "Decision " + choicesDone.ToString();
        GameObject[] objectsWithAnimation = GameObject.FindGameObjectsWithTag("Animation");

        foreach (GameObject theObject in objectsWithAnimation)
        {
            List<string> states = new List<string>();
            foreach (AnimationState state in theObject.GetComponent<Animation>())
            {
                states.Add(state.name);
            }
            //Debug.Log(states[0]);
            //Debug.Log(states[1]);
            theObject.GetComponent<Animation>().Play(states[0]);
        }
        animationsDone++;
        //choiceCanvas.transform.Find("Background Choice").GameObject().SetActive(true);
        //choiceCanvas.transform.Find(theChoice).GameObject().SetActive(true);

    }


    public void EndDialogue()
    {

        // string neutralNameScene = SceneManager.GetActiveScene().name;

        dialogueCanvas.SetActive(false);

    }

    public static IEnumerator StartFadeOut(GameObject fader, float duration, float alpha)
    {
        float currentTime = 0;
        float currentAlpha = fader.GetComponent<Image>().color.a;
        float targetValue = Mathf.Clamp(alpha, 0.0001f, 1f);
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;

            float newAlpha = Mathf.Lerp(currentAlpha, targetValue, currentTime / duration);
            fader.GetComponent<Image>().color =
            new Color(fader.GetComponent<Image>().color.r, fader.GetComponent<Image>().color.g, fader.GetComponent<Image>().color.b, newAlpha);
            yield return null;
        }
        yield break;
    }


    // private void LoadMainMenu()
    // {        
    //     GameSession.Instance.resetGame();
    //     GameSession.Instance = null;
    //     SceneManager.LoadScene("Main Menu");

    // }
    // private void LoadHouseMap()
    // {
    //     SceneManager.LoadScene("House Map");
    // }
}
