using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _dialogueText;
    [SerializeField] private Button _continueButton;
    [SerializeField] private Transform[] _objectZoomTargets;
    [SerializeField] private List<int> _tutorialTriggerIndex = new List<int>();
    [SerializeField] private int _currentDialogueIndex;
    private bool _isZoomActive = false;

    public delegate void OnCameraSwitch();

    public delegate void OnTargetSwitch(Transform target);
    public static event OnCameraSwitch OnCameraSwitchEvent;
    public static event OnTargetSwitch OnCameraTargetChangedEvent;
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
        
        _currentDialogueIndex = 0;
        DisplayNextSentence();
    }
    
    public void DisplayNextSentence()
    {
        if (_sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        if (_isZoomActive)
        {
            OnCameraSwitchEvent?.Invoke();
        }

        string sentence = _sentences.Dequeue();
        _dialogueText.text = sentence;
        
        _currentDialogueIndex++;
        TriggerZoom();
    }

    private void TriggerZoom()
    {
        _isZoomActive = false;
        
        for (int i = 0; i < _tutorialTriggerIndex.Count; i++)
        {
            if(_currentDialogueIndex == _tutorialTriggerIndex[i])
            {
                if (!_isZoomActive)
                {
                    OnCameraSwitchEvent?.Invoke();
                    _isZoomActive = true;
                }
                
                OnCameraTargetChangedEvent?.Invoke(_objectZoomTargets[i]);
            }
        }
    }
    
    private void EndDialogue()
    {
        Debug.Log("End of conversation");
        this.gameObject.SetActive(false);
        if (!_isZoomActive)
        {
            return;
        }
        OnCameraSwitchEvent?.Invoke();
        _isZoomActive = false;
    }
}
