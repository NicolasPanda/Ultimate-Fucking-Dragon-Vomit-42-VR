using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    
    public event Action<int> EventPointChange;
    private int _point = 0;
    public int Point
    {
        get => _point;
        private set
        {
            _point = value;
            EventPointChange?.Invoke(value);
        }
    } 
    
    public event Action<int> EventLapsChange;
    private int _laps = 0;
    public int Laps
    {
        get => _laps;
        set
        {
            _laps = value;
            EventLapsChange?.Invoke(value);
        }
    }

    private void Awake()
    {
        instance = this;
    }

    public void AddPoint(int value)
    {
        Point += value;
    }
}
