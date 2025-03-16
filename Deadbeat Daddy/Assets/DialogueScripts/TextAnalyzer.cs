using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextAnalyzer : MonoBehaviour
{

    int i = 0;

    DialogueManager manager;
    string[] lines;

    private void Awake()
    {
        manager = FindFirstObjectByType<DialogueManager>();
    }

    public void AnalyzeText(string txt)
    {
        lines = txt.Split(System.Environment.NewLine.ToCharArray());

        while (i < lines.Length)
        {
            if (!string.IsNullOrEmpty(lines[i]))
            {
                if (lines[i][0] == '#')
                {
                    if(lines[i].Remove(0, 1) == "")
                        manager.names.Enqueue(" ");
                    else
                        manager.names.Enqueue(lines[i].Remove(0, 1));
                }
                if (lines[i][0] == ':')
                {
                    manager.dialogues.Enqueue(lines[i].Remove(0, 1));
                }
                if (lines[i][0] == '@')
                {
                    manager.names.Enqueue(lines[i]);
                }
                if (lines[i][0] == '$')
                {
                    manager.names.Enqueue("Animation");
                }
            }
            i++;
        }
    }

}
