using System.Collections;
using UnityEngine;
using Zenject;

public class CameraController : MonoBehaviour
{
    private CarController _car;
    private Coroutine _folowCarRoutine;

    [Inject]
    public void Construct(CarController car)
    {
        _car = car;
        if (_folowCarRoutine == null)
        {
            _folowCarRoutine = StartCoroutine(FollowCar());
        }
    }

    IEnumerator FollowCar()
    {
        while (true){
            transform.position = new Vector3(_car.transform.position.x + 10f, transform.position.y, -10);
            yield return null;
        }
    }
}
