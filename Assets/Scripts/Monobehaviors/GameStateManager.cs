using System.Collections;
using UnityEngine;
using Zenject;

public class GameStateManager : MonoBehaviour
{
    private const float RoadSectionWidth = 36f;
    private float _finishDistance = 500f;
    private VehicleController _vehicle;
    private RoadManager _roadManager;
    private Coroutine _checkPassedDistanceRoutine;
    public int ActiveRoadSection { get; private set; } = 0;
    public float PassedDistance { get; private set; } = 0;

    [Inject]
    public void Construct(VehicleController vehicle, RoadManager roadManager)
    {
        _vehicle = vehicle;
        _roadManager = roadManager;
        OnNewGame();
    }

    IEnumerator CheckPassedDistanceRoutine()
    {
        while (PassedDistance < _finishDistance)
        {
            PassedDistance = _vehicle.transform.position.x;
            if (PassedDistance > (RoadSectionWidth / 2) + ActiveRoadSection * RoadSectionWidth)
            {
                ActiveRoadSection = Mathf.RoundToInt(PassedDistance / RoadSectionWidth);
                _roadManager.RenderRoadSection(ActiveRoadSection + 1);
            }
            yield return null;
        }
        _checkPassedDistanceRoutine = null;
    }

    public void OnNewGame()
    {
        _checkPassedDistanceRoutine = StartCoroutine(CheckPassedDistanceRoutine());
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
