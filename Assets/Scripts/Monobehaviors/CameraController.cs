using System.Collections;
using UnityEngine;
using Zenject;

public class CameraController : MonoBehaviour
{
    private Vehicle _vehicle;
    private Coroutine _folowCarRoutine;
    private NewGameService _newGameService;

    [Inject]
    public void Construct(NewGameService newGameService)
    {
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

    public void NewGameHandler()
    {
        _vehicle = _newGameService.Vehicle;
        if (_folowCarRoutine == null)
        {
            _folowCarRoutine = StartCoroutine(FollowCar());
        }
    }

    IEnumerator FollowCar()
    {
        while (true){
            transform.position = new Vector3(_vehicle.transform.position.x + 10f, transform.position.y, -10);
            yield return null;
        }
    }
}
