using UnityEngine;
using UnityEngine.U2D;

public class RoadShapeController : MonoBehaviour
{
    private const float RoadSectionWidth = 36f;
    private const float RoadSectionYAxisPos = -10f;
    public SpriteShapeController spriteShapeController;
    public int? RoadSectionIndex { get; set; }

    public void Render(RoadSection roadSection) 
    {
        transform.position = new Vector3(RoadSectionWidth * roadSection.sectionIndex, RoadSectionYAxisPos);
        for (int i = 1; i <= 16; i++)
        {
            spriteShapeController.spline.SetPosition(i, roadSection.shapePoints[i-1]);
        }
        RoadSectionIndex = roadSection.sectionIndex;
    }
}
