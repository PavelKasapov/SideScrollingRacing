using System.Collections;
using UnityEngine;
using Zenject;

public class GameStateManager : MonoBehaviour
{
    private const float roadSectionWidth = 36f;
    private CarController _car;
    private RoadManager _roadManager;
    private Coroutine _checkPassedDistanceRoutine;
    public int ActiveRoadSection { get; private set; } = 0;
    public float PassedDistance { get; private set; }

    [Inject]
    public void Construct(CarController car, RoadManager roadManager)
    {
        _car = car;
        _roadManager = roadManager;
        if (_checkPassedDistanceRoutine == null)
        {
            _checkPassedDistanceRoutine = StartCoroutine(CheckPassedDistanceRoutine());
        }
    }

    IEnumerator CheckPassedDistanceRoutine()
    {
        while (true)
        {
            PassedDistance = _car.transform.position.x;
            if (PassedDistance > (roadSectionWidth/2) + ActiveRoadSection * roadSectionWidth)
            {
                ActiveRoadSection = Mathf.RoundToInt(PassedDistance / roadSectionWidth);
                _roadManager.RenderRoadSection(ActiveRoadSection + 1);
            }
            yield return null;
        }
    }
}
