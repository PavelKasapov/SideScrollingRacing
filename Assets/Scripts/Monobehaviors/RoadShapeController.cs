using UnityEngine;
using Zenject;
using UnityEngine.U2D;

public class RoadShapeController : MonoBehaviour
{
    private const float roadSectionWidth = 36f;
    private const float roadSectionYAxisPos = -3f;
    public SpriteShapeController spriteShapeController;
    public int RoadSectionIndex { get; private set; }

    public void Render(RoadSection roadSection) 
    {
        transform.position = new Vector3(roadSectionWidth * roadSection.sectionIndex, roadSectionYAxisPos);
        for (int i = 1; i <= 16; i++)
        {
            spriteShapeController.spline.SetPosition(i, roadSection.shapePoints[i-1]);
        }
        RoadSectionIndex = roadSection.sectionIndex;
    }
}
