using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public event Action<int> EventDamagePlayer;
    public event Action<int> EventLapsAdd;

    public event Action<int> EventHealthChange;
    private int _health = 5;
    public int Health
    {
        get => _health;
        private set
        {
            _health = value;
            EventHealthChange?.Invoke(value);
        }
    }
    
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
        private set
        {
            _laps = value;
            EventLapsChange?.Invoke(value);
        }
    }

    private void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// Heal the player
    /// </summary>
    /// <param name="value">Value to add to the health</param>
    public void AddHealth(int value)
    {
        Health += value;
    }

    /// <summary>
    /// Damage player health
    /// </summary>
    /// <param name="value">Value to damage player health</param>
    public void DamagePlayer(int value)
    {
        Health -= value;
        EventDamagePlayer?.Invoke(value);
    }

    public void AddPoint(int value)
    {
        Point += value;
    }

    public void AddLaps()
    {
        Laps += 1;
        EventLapsAdd?.Invoke(Laps);
    }
}
