using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class DistanceCounter : MonoBehaviour
{
    public Text distanceValue;
    public GameObject FinishPanel;
    private const float RoadSectionWidth = 36f;
    private float _finishDistance = 500f;
    private Coroutine _renderDistanceValueRoutine;
    private Coroutine _checkPassedDistanceRoutine;
    private Vehicle _vehicle;
    private RoadManager _roadManager;
    private NewGameService _newGameService;
    public float PassedDistance { get; private set; } = 0;
    public int ActiveRoadSection { get; private set; } = 0;
    

    [Inject]
    public void Construct(RoadManager roadManager, NewGameService newGameService)
    {
        _roadManager = roadManager;
        _newGameService = newGameService;
    }

    private void OnEnable()
    {
        _newGameService.OnNewGame += NewGameHandler;
    }

    private void OnDisable()
    {
        _newGameService.OnNewGame -= NewGameHandler;
    }

    private void NewGameHandler()
    {
        FinishPanel.SetActive(false);
        if (_vehicle != null)
        {
             GameObject.Destroy(_vehicle.gameObject);
        }
        _vehicle = _newGameService.Vehicle;
        PassedDistance = 0;
        ActiveRoadSection = 0;
        _renderDistanceValueRoutine = StartCoroutine(RenderDistanceValueRoutine());
        _checkPassedDistanceRoutine = StartCoroutine(CheckPassedDistanceRoutine());
       
    }

    public IEnumerator CheckPassedDistanceRoutine()
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
        OnFinish();
        _checkPassedDistanceRoutine = null;
    }

    IEnumerator RenderDistanceValueRoutine()
    {
        while (true)
        {
            int passedDistance = (int)PassedDistance;
            distanceValue.text = passedDistance.ToString() + "m";
            yield return null;
        }
    }

    private void OnFinish()
    {
        FinishPanel.SetActive(true);
        Time.timeScale = 0f;
    }
}
