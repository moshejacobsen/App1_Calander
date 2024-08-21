using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class MonthDisplay : MonoBehaviour
{
    private DateTime _currentDateTime = DateTime.Now;

    private int _daysInMonth;
    private int _firstDayInMonth;

    private List<GameObject> _daysInMonthObjects = new();
    [SerializeField] private GameObject _dayObject;
    [SerializeField] private Transform _objectParents;
    [SerializeField] private TextMeshProUGUI _monthAndYearNameText;
    private readonly Vector2 _dayObjectPosition = new(-165, 110);
    private readonly string[] _monthNames = new string[12] {"January", "Fabruary", "March", "April", "May",
        "June", "July", "August", "September", "October", "November", "December"};

    private int _placementOffset = 55;



    private DateTime GetNextMonthDateTime(DateTime dateTime)
    {
        int nextMonth = dateTime.Month + 1;
        if (nextMonth > 12)
        {
            return GetNextYearDateTime(dateTime);
        }
        return new(dateTime.Year, nextMonth, dateTime.Day);
    }

    private DateTime GetPreviousMonthDateTime(DateTime dateTime)
    {
        int previousMonth = dateTime.Month - 1;
        if (previousMonth < 1)
        {
            return GetPreviousYearDateTime(dateTime);
        }
        return new(dateTime.Year, dateTime.Month - 1, dateTime.Day);
    }

    private DateTime GetNextYearDateTime(DateTime dateTime)
    {
        return new(dateTime.Year + 1, 1, 1);
    }

    private DateTime GetPreviousYearDateTime(DateTime dateTime)
    {
        return new(dateTime.Year - 1, 12, 1);
    }

    private int GetDaysInMonth(DateTime dateTime)
    {
        return DateTime.DaysInMonth(dateTime.Year, dateTime.Month);
    }

    private int GetFirstDayInMonth(DateTime dateTime)
    {
        DateTime firstDayInMonthDate = new(dateTime.Year, dateTime.Month, 1);
        return (int)firstDayInMonthDate.DayOfWeek;
    }

    private void GetMonthDetails()
    {
        _daysInMonth = GetDaysInMonth(_currentDateTime);
        _firstDayInMonth = GetFirstDayInMonth(_currentDateTime);
    }

    private void ChooseTextDate()
    {
        _daysInMonthObjects[^1].GetComponentInChildren<TextMeshProUGUI>().text = _daysInMonthObjects.Count.ToString();
    }

    private void ChangeMonthAndYearText()
    {
        _monthAndYearNameText.text = _monthNames[_currentDateTime.Month - 1] + " " + _currentDateTime.Year;
    }

    private void LoadCalanderVisuals()
    {
        GetMonthDetails();
        int horizontalLineIndex = _firstDayInMonth;
        int verticalLineIndex = 0;
        bool firstLoop = true;
        for (int i = _firstDayInMonth; i < _daysInMonth + _firstDayInMonth; i++)
        {
            if (!firstLoop)
            {
                if (i % 7 == 0)
                {
                    verticalLineIndex++;
                    horizontalLineIndex = 0;
                }
                else if (i > 0)
                {
                    horizontalLineIndex++;
                }
            }
            firstLoop = false;
            Vector3 position = new(_dayObjectPosition.x + _placementOffset * horizontalLineIndex, _dayObjectPosition.y - _placementOffset * verticalLineIndex, 0);
            _daysInMonthObjects.Add(Instantiate(_dayObject, _objectParents));
            _daysInMonthObjects[^1].GetComponent<RectTransform>().localPosition = position;
            ChooseTextDate();
            ChangeMonthAndYearText();
        }
    }

    private void DeloadCalanderVisuals()
    {
        for (int i = 0; i < _daysInMonthObjects.Count; i++)
        {
            Destroy(_daysInMonthObjects[i]);
        }
        _daysInMonthObjects.Clear();
    }

    private void Start()
    {
        LoadCalanderVisuals();
    }

    public void NextMonthButton()
    {
        DeloadCalanderVisuals();
        _currentDateTime = GetNextMonthDateTime(_currentDateTime);
        LoadCalanderVisuals();
    }

    public void PreviousMonthButton()
    {
        DeloadCalanderVisuals();
        _currentDateTime = GetPreviousMonthDateTime(_currentDateTime);
        LoadCalanderVisuals();
    }
}
