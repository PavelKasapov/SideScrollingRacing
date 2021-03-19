using UnityEngine;

public class RoadSection
{
    public int sectionIndex; 
    public Vector3[] shapePoints;
    public RoadSection(int index, Vector3[] points)
    {
        sectionIndex = index;
        shapePoints = points;
    }
}
