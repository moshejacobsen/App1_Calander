using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventEditorButton : MonoBehaviour
{
    [SerializeField] private GameObject _eventEditor;

    public void OpenEventEditor()
    {
        _eventEditor.SetActive(true);
    }
    public void CloseEventEditor()
    {
        _eventEditor.SetActive(false);
    }
}
