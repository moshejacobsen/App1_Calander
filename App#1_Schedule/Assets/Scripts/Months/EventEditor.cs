using UnityEngine;

public class EventEditor : MonoBehaviour
{
    [SerializeField] private float _eventTextOffset;
    [SerializeField] private int _eventIndex;
    [SerializeField] private GameObject _eventPrefab;
    [SerializeField] private GameObject _addEventButton;

    public void AddEvent()
    {
        if(_eventIndex < 4)
        {
            _eventIndex++;
            GameObject temp = Instantiate(_eventPrefab, _addEventButton.transform.parent);
            temp.GetComponent<RectTransform>().localPosition = _addEventButton.transform.localPosition;
            _addEventButton.GetComponent<RectTransform>().localPosition -= Vector3.up * _eventTextOffset;
        }
        else if(_eventIndex == 4)
        {
            GameObject temp = Instantiate(_eventPrefab, _addEventButton.transform.parent);
            temp.GetComponent<RectTransform>().localPosition = _addEventButton.transform.localPosition;
            _addEventButton.SetActive(false);
        }
    }
}
