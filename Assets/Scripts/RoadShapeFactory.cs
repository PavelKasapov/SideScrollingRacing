using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RoadShapeFactory : IFactory<RoadShapeController>
{
    private const string RoadShapePrefabPath = "Prefabs/Road Shape";
    private DiContainer _diContainer;
    private GameObject _roadShapePrefab;
    public RoadShapeFactory(DiContainer diContainer)
    {
        _diContainer = diContainer;
        Load();
    }

    private void Load()
    {
        _roadShapePrefab = Resources.Load(RoadShapePrefabPath, typeof(GameObject)) as GameObject;
    }

    public RoadShapeController Create()
    {
        var newPart = _diContainer.InstantiatePrefabForComponent<RoadShapeController>(_roadShapePrefab, Vector3.zero, Quaternion.identity, null);
        return newPart;
    }
}
