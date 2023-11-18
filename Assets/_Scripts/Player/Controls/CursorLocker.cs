using UnityEngine;
using System;
using System.Collections;
using Game;

public class CursorLocker : MonoBehaviour
{
    [SerializeField] private bool _lockAtStart = true;
    [SerializeField] private bool _lockAtFocus = true;

    public Action<bool> CursorStateChanged;

    private bool _isLocked;

    public void Initialize()
    {
        SetCursorLock(_lockAtStart);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
            SetCursorLock(!_isLocked);
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus && _lockAtFocus)
            SetCursorLock(true);
    }

    public void SetCursorLock(bool isLocked)
    {
        _isLocked = isLocked;

        if (isLocked)
            Cursor.lockState = CursorLockMode.Locked;
        else
            Cursor.lockState = CursorLockMode.None;

        CursorStateChanged?.Invoke(_isLocked);
    }
}
