using System.Collections;
using UnityEngine;
using Zenject;

public class GameStateManager : MonoBehaviour
{
    private const float roadSectionWidth = 36f;
    private VehicleController _vehicle;
    private RoadManager _roadManager;
    private Coroutine _checkPassedDistanceRoutine;
    public int ActiveRoadSection { get; private set; } = 0;
    public float PassedDistance { get; private set; }

    [Inject]
    public void Construct(VehicleController vehicle, RoadManager roadManager)
    {
        _vehicle = vehicle;
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
            PassedDistance = _vehicle.transform.position.x;
            if (PassedDistance > (roadSectionWidth/2) + ActiveRoadSection * roadSectionWidth)
            {
                ActiveRoadSection = Mathf.RoundToInt(PassedDistance / roadSectionWidth);
                _roadManager.RenderRoadSection(ActiveRoadSection + 1);
            }
            yield return null;
        }
    }
}
