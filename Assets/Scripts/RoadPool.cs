using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RoadPool : MonoBehaviour
{
    public List<RoadPart> roadParts;
    public int genetatedPartsCounter;
    private RoadPartFactory _roadPartFactory;

    [Inject]
    public void Construct(RoadPartFactory roadPartFactory)
    {
        _roadPartFactory = roadPartFactory;
        for (int i = 0; i < 3; i++)
        {
            RoadPart newPart = _roadPartFactory.Create();
            newPart.transform.parent = transform;
            roadParts.Add(newPart);
        }
    }
}
