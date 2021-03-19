using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class DistanceCounterController : MonoBehaviour
{
    public Text distanceValue;
    private GameStateManager _gameController;
    private Coroutine _renderDistanceValueRoutine;

    [Inject]
    public void Construct(GameStateManager gameStateManager)
    {
        _gameController = gameStateManager;
        if (_renderDistanceValueRoutine == null)
        {
            _renderDistanceValueRoutine = StartCoroutine(RenderDistanceValueRoutine());
        }
    }

    IEnumerator RenderDistanceValueRoutine()
    {
        while (true)
        {
            int passedDistance = (int)_gameController.PassedDistance;
            distanceValue.text = passedDistance.ToString() + "m";
            yield return null;
        }
    }
}
