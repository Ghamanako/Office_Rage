using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _dialogueText;
    [SerializeField] private Button _continueButton;
    private Queue<string> _sentences;

    private void Awake()
    {
        _sentences = new Queue<string>();
        _continueButton.onClick.AddListener(DisplayNextSentence);
    }
    
    public void StartDialogue(Dialogue dialogue)
    {
        _nameText.text = dialogue.name;

        _sentences.Clear();
        
        foreach (var sentence in dialogue.sentences)
        {
            _sentences.Enqueue(sentence);
        }
        
        DisplayNextSentence();
    }
    
    public void DisplayNextSentence()
    {
        if (_sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        
        string sentence = _sentences.Dequeue();
        _dialogueText.text = sentence;
    }
    
    private void EndDialogue()
    {
        Debug.Log("End of conversation");
    }
}
