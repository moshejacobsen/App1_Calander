using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindEventEditorWindowManager : MonoBehaviour
{
    private EventEditorButton _eventEditorButton;

    private void OnEnable()
    {
        _eventEditorButton = FindObjectOfType<EventEditorButton>();
    }

    public void OpenEventEditor()
    {
        _eventEditorButton.OpenEventEditor();
    }
}
