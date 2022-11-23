using System;
using Cinemachine;
using UnityEngine;

public class CinemachineSwitcher : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _worldCamera;
    [SerializeField] private CinemachineVirtualCamera _objectCamera;
    [SerializeField] private Transform _followTarget;
    private bool _isWorldCamera = true;

    private void OnEnable()
    {
        DialogueManager.OnCameraSwitchEvent += SwitchCamera;
    }

    private void OnDisable()
    {
        DialogueManager.OnCameraSwitchEvent -= SwitchCamera;
    }

    private void Start()
    {
        SwitchTarget();
    }

    private void SwitchCamera()
    {
        if(_isWorldCamera)
        {
            _worldCamera.Priority = 0;
            _objectCamera.Priority = 1;
        }
        else
        {
            _worldCamera.Priority = 1;
            _objectCamera.Priority = 0;
        }
        _isWorldCamera = !_isWorldCamera;
    }
    
    [ContextMenu("Switch Camera Target")]
    private void SwitchTarget()
    {
        _objectCamera.Follow = _followTarget;
        _objectCamera.LookAt = _followTarget;
    }
}
