using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class RoadManager : MonoBehaviour, IInitializable
{
    private const string RoadShapePrefabPath = "Prefabs/Road Shape";
    private List<RoadShapeController> _roadShapePool = new List<RoadShapeController>();
    private List<RoadSection> _road = new List<RoadSection>();
    private RoadSectionGeneratorService _generationService;
    private NewGameService _newGameService;

    [Inject]
    public void Construct( RoadSectionGeneratorService generationService, NewGameService newGameService)
    {
        _generationService = generationService;
        _newGameService = newGameService;
    }

    public void Initialize()
    {
        var roadShapePrefab = Resources.Load(RoadShapePrefabPath, typeof(GameObject)) as GameObject;
        for (int i = 0; i < 3; i++)
        {
            var newRoadShape = Instantiate(roadShapePrefab, Vector3.zero, Quaternion.identity, transform).GetComponent<RoadShapeController>();
            _roadShapePool.Add(newRoadShape);
        }
    }

    private void OnEnable()
    {
        _newGameService.OnNewGame += NewGameHandler;
    }

    private void OnDisable()
    {
        _newGameService.OnNewGame -= NewGameHandler;
    }

    public void RenderRoadSection(int sectionIndex)
    {
        var shapeController = _roadShapePool.FirstOrDefault(i => i.RoadSectionIndex == sectionIndex - 3);
        var roadSectionToRender = _road.FirstOrDefault(i => i.sectionIndex == sectionIndex);
        if (roadSectionToRender == null)
        {
            roadSectionToRender = _generationService.GenerateSecton(sectionIndex);
        }
        shapeController.Render(roadSectionToRender);
    }

    private void NewGameHandler()
    {
        foreach(var roadShape in _roadShapePool)
        {
            roadShape.RoadSectionIndex = null;
        }
        _road.Clear();
        for (int i = -1; i < 2; i++)
        {
            var newRoadSection = _generationService.GenerateSecton(i);
            _road.Add(newRoadSection);
            _roadShapePool.Find(roadShape => roadShape.RoadSectionIndex == null).Render(newRoadSection);
        }
    }
}
