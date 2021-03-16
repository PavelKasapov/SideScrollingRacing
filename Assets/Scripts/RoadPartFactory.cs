using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RoadPartFactory : IFactory<RoadPart>
{
    private DiContainer _diContainer;
    private GameObject _roadPartPrefab;
    public RoadPartFactory(DiContainer diContainer)
    {
        _diContainer = diContainer;
        Load();
    }

    private void Load()
    {
        _roadPartPrefab = Resources.Load("Prefabs/Road Part", typeof(GameObject)) as GameObject;
    }

    public RoadPart Create()
    {
        RoadPart newPart = _diContainer.InstantiatePrefabForComponent<RoadPart>(_roadPartPrefab, Vector3.zero, Quaternion.identity, null);
        return newPart;
    }
}
