using Cinemachine;
using UnityEngine;

public class CinemachineSwitcher : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _worldCamera;
    [SerializeField] private CinemachineVirtualCamera _objectCamera;
    private bool _isWorldCamera = true;
    
    [ContextMenu("Switch Camera")]
    private void SwtichCamera()
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
}
