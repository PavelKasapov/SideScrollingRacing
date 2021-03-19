using System.Collections;
using UnityEngine;
using Zenject;

public class CameraController : MonoBehaviour
{
    private VehicleController _vehicle;
    private Coroutine _folowCarRoutine;

    [Inject]
    public void Construct(VehicleController vehicle)
    {
        _vehicle = vehicle;
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
