using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class RoadManager : MonoBehaviour
{
    private List<RoadShapeController> _roadShapePool = new List<RoadShapeController>();
    private List<RoadSection> _road = new List<RoadSection>();
    private RoadShapeFactory _roadPartFactory;
    private RoadSectionGenerationService _generationService;

    [Inject]
    public void Construct(RoadShapeFactory roadShapeFactory, RoadSectionGenerationService generationService)
    {
        _roadPartFactory = roadShapeFactory;
        _generationService = generationService;
        OnNewGame();
    }

    public void RenderRoadSection(int sectionIndex)
    {
        RoadShapeController shapeController = _roadShapePool.FirstOrDefault(i => i.RoadSectionIndex == sectionIndex - 3);
        RoadSection roadSectionToRender = _road.FirstOrDefault(i => i.sectionIndex == sectionIndex);
        if (roadSectionToRender == null)
        {
            roadSectionToRender = _generationService.GenerateSecton(sectionIndex);
        }
        shapeController.Render(roadSectionToRender);
    }

    private void OnNewGame()
    {
        _roadShapePool.Clear();
        _road.Clear();
        for (int i = -1; i < 2; i++)
        {
            RoadSection newRoadSection = _generationService.GenerateSecton(i);
            _road.Add(newRoadSection);
            RoadShapeController newRoadShape = _roadPartFactory.Create();
            newRoadShape.transform.parent = transform;
            _roadShapePool.Add(newRoadShape);
            newRoadShape.Render(newRoadSection);
        }
    }
}
