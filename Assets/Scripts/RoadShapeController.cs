using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using System.Linq;
using UnityEngine.U2D;

public class RoadShapeController : MonoBehaviour
{
    private const float roadPartWidth = 18f;
    private RoadManager _roadManager;
    public SpriteShapeController spriteShapeController;
    Spline spline;

    [Inject]
    public void Construct(RoadManager roadManager)
    {
        _roadManager = roadManager;
        Render();
        _roadManager.genetatedPartsCounter++;
    }

    private void OnBecameInvisible()
    {
        #if UNITY_EDITOR
            if (Camera.current && Camera.current.name == "SceneCamera") return;
        #endif  
        Render();
        _roadManager.genetatedPartsCounter++;
    }

    private void Render() 
    {
        transform.position = new Vector3(roadPartWidth * _roadManager.genetatedPartsCounter, -3f);
        for (int i = 2; i <= 15; i++)
        {
            spriteShapeController.spline.InsertPointAt(i, new Vector3(Mathf.Lerp(-2f, 2f, (float)(i - 1) / 15), Random.Range(1f, 2f)));
        }
        spriteShapeController.spline.SetPosition(1, new Vector3(-2f, 1.5f));
        spriteShapeController.spline.SetPosition(16, new Vector3(2f, 1.5f));
    }
    
}
