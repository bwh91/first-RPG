using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {

    public Text dialogText;
    public Text nameText;
    public GameObject dialogBox;
    public GameObject nameBox;

    public string[] dialogLines;

    public int currentLine;

    public static DialogManager instance;

    private bool justStarted;

    private string questToMark;
    private bool MarkQuestComplete;
    private bool shouldMarkQuest;

	// Use this for initialization
	void Start () {
        instance = this;
        //dialogText.text = dialogLines[currentLine];
	}
	
	// Update is called once per frame
	void Update () {
		

        //if the dialog is active this allows user to click through the text
        if (dialogBox.activeInHierarchy)
        {
            if (Input.GetButtonUp("Fire1"))
            {
                if (!justStarted)
                {
                    currentLine++;

                    if (currentLine >= dialogLines.Length)
                    {
                        dialogBox.SetActive(false);
                        GameManager.instance.dialogActive = false;

                        if (shouldMarkQuest)
                        {
                            shouldMarkQuest = false;
                            if (MarkQuestComplete)
                            {
                                QuestManager.instance.MarkQuestComplete(questToMark);
                            }
                            else
                            {
                                QuestManager.instance.MarkQuestIncomplete(questToMark);
                            }
                        }
                    }
                    else
                    {
                        CheckIfName();
                        dialogText.text = dialogLines[currentLine];
                    }
                }
                else
                {
                    justStarted = false;
                }
 
            }
        }

	}

    // show dialog and set up text and stop player from moving
    public void ShowDialog(string[] newLines, bool isPerson)
    {
        currentLine = 0;
        dialogLines = newLines;

        CheckIfName();

        dialogText.text = dialogLines[currentLine];
        dialogBox.SetActive(true);

        justStarted = true;

        nameBox.SetActive(isPerson);

        GameManager.instance.dialogActive = true; // dont allow player to move while dialog is open

    }

    //function to determin if a line in the text array is a character name or text to display
    private void CheckIfName()
    {
        if (dialogLines[currentLine].StartsWith("n-"))
        {
            nameText.text = dialogLines[currentLine].Replace("n-", "");
            currentLine++;
        }
    }


    public void ShouldActivateQuestAtEnd(string questName, bool markComplete)
    {
        questToMark = questName;
        MarkQuestComplete = markComplete;

        shouldMarkQuest = true;
    }
}
