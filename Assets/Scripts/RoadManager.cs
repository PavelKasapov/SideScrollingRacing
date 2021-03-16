using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RoadManager : MonoBehaviour
{
    public List<RoadShapeController> roadShapePool = new List<RoadShapeController>(3);
    public int genetatedPartsCounter;
    private RoadShapeFactory _roadPartFactory;

    [Inject]
    public void Construct(RoadShapeFactory roadPartFactory)
    {
        _roadPartFactory = roadPartFactory;
        for (int i = 0; i < 3; i++)
        {
            RoadShapeController newPart = _roadPartFactory.Create();
            newPart.transform.parent = transform;
            roadShapePool.Add(newPart);
        }
    }
}
