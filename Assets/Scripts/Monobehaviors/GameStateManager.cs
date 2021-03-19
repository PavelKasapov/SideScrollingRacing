using System.Collections;
using UnityEngine;
using Zenject;

public class GameStateManager : MonoBehaviour
{
    private const float roadSectionWidth = 36f;
    private float finishDistance = 500f;
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
        while (PassedDistance < finishDistance)
        {
            PassedDistance = _vehicle.transform.position.x;
            if (PassedDistance > (roadSectionWidth/2) + ActiveRoadSection * roadSectionWidth)
            {
                ActiveRoadSection = Mathf.RoundToInt(PassedDistance / roadSectionWidth);
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
