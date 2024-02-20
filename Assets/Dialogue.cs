using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static Dialogue;

public class Dialogue : MonoBehaviour
{
    public GameObject dialogue;
    public Text textName;
    public Text textComponent;
    public TextAsset textJson;
    public float textSpeed;
    private int index;
    private List<DialogueNode> dialogueLines;
    private static Dialogue instance;
    public Button[] choiceButtons;
    public PlayerMovement playerMovement;
    public GameObject mainUI;
    private string nodeName = "";

    public static Dialogue Instance { get => instance; set => instance = value; }
    public string NodeName { get => nodeName; set => nodeName = value; }

    [System.Serializable]
    public class DialogueNode
    {
        public string speaker;
        public string dialogue;
        public Choice[] choices;
        public string node;
        public bool isLastNode;
    }

    [System.Serializable]
    public class Choice
    {
        public string text;
        public string nextNode;
    }

    [System.Serializable]
    public class DialogueData
    {
        public List<DialogueNode> dialogueTree;
    }
    void Start()
    {
        Dialogue.instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogue.activeSelf)
        {
            playerMovement.enabled = false;
        }
        else 
        {
            playerMovement.enabled = true;
        }
        if (Input.GetMouseButtonDown(0) && dialogue.activeSelf && !isButtonEnable())
        {
            if (textComponent.text == dialogueLines[index].dialogue)
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = dialogueLines[index].dialogue;
                ShowChoiceButtons();
            }
        }
    }

    private bool isButtonEnable()
    {
        foreach (Button button in choiceButtons)
        {
            if (button.IsActive()) return true;
        }
        return false;
    }

    void LoadDialogueFromJSON(TextAsset json)
    {
        DialogueData data = JsonUtility.FromJson<DialogueData>(json.text);
        dialogueLines = data.dialogueTree;
    }
    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }
    IEnumerator TypeLine()
    {
        textName.text = dialogueLines[index].speaker;
        foreach (char c in dialogueLines[index].dialogue.ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        ShowChoiceButtons();
    }

    private void ShowChoiceButtons()
    {
        if (dialogueLines[index].choices.Length > 0)
        {
            for (int i = 0; i < choiceButtons.Length; i++)
            {
                if (i < dialogueLines[index].choices.Length)
                {
                    choiceButtons[i].gameObject.SetActive(true);
                    choiceButtons[i].GetComponentInChildren<Text>().text = dialogueLines[index].choices[i].text;

                    int choiceIndex = i;
                    string nextNode = dialogueLines[index].choices[choiceIndex].nextNode;

                    choiceButtons[i].onClick.RemoveAllListeners();
                    choiceButtons[i].onClick.AddListener(() => OnChoiceClicked(nextNode));
                }
                else
                {
                    choiceButtons[i].gameObject.SetActive(false);
                }
            }
        }
    }
    private void NextLine()
    {
        if(index < dialogueLines.Count - 1 && !dialogueLines[index].isLastNode)
        {
            index++;
            textComponent.text = string.Empty;
            StopAllCoroutines();
            StartCoroutine(TypeLine());
        }
        else
        {
            dialogue.SetActive(false);
            mainUI.SetActive(true);
            index = 0;
        }
    }

    public int FindNodeByNodeName(string nodeName)
    {
        int index = 0;
        foreach (DialogueNode dialogue in dialogueLines)
        {
            if (dialogue.node.Equals(nodeName))
            {
                return index;
            }
            index++;
        }
        return -1;
    }
    private void OnChoiceClicked(string nextNode)
    {
        int dialogPos = FindNodeByNodeName(nextNode);
        nodeName = nextNode;
        if (dialogPos >= 0)
        {
            index = dialogPos;
            textComponent.text = string.Empty;
            DisableChoiceButton();
            StopAllCoroutines();
            StartCoroutine(TypeLine());
        }
        else
        {
            Debug.LogError("Next node not found: " + nextNode);
        }
    }
    private void DisableChoiceButton()
    {
        foreach (Button button in choiceButtons)
        {
            if (button.enabled) button.gameObject.SetActive(false);
        }
    }
    public void SetDialogueJson(TextAsset json)
    {
        if (json != null)
        {
            textComponent.text = string.Empty;
            LoadDialogueFromJSON(json);
            StartDialogue();
        }
    }

    public void ShowDialogue()
    {
        dialogue.SetActive(true);
        mainUI.SetActive(false);
    }
}
