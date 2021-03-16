using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using System.Linq;

public class RoadPart : MonoBehaviour
{
    private const float roadPartWidth = 18f;
    private RoadPool _roadPool;

    [Inject]
    public void Construct(RoadPool roadPool)
    {
        _roadPool = roadPool;
        ReplacePart();
        RegeneratePart();
        _roadPool.genetatedPartsCounter++;
    }

    private void OnBecameInvisible()
    {
        #if UNITY_EDITOR
            if (Camera.current && Camera.current.name == "SceneCamera") return;
        #endif
        ReplacePart();
        RegeneratePart();
        _roadPool.genetatedPartsCounter++;
    }

    private void ReplacePart() 
    {
        transform.position = new Vector3(roadPartWidth * _roadPool.genetatedPartsCounter, -3f);
    }
    private void RegeneratePart() 
    { 

    }
}
