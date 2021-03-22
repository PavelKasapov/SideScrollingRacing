using System;
using UnityEngine;

public class NewGameService
{
    public event Action OnNewGame;
    private Vehicle.Factory _vehicleFactory;
    public Vehicle Vehicle { get; private set; }
    public NewGameService(Vehicle.Factory vehicleFactory)
    {
        _vehicleFactory = vehicleFactory;
    }

    public void StartNewGame(string VehiclePrefabPath)
    {
        Vehicle = _vehicleFactory.Create(VehiclePrefabPath);
        Time.timeScale = 1f;
        OnNewGame?.Invoke();
    }
}
