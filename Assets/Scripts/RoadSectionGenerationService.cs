using UnityEngine;

public class RoadSectionGenerationService
{
    private Vector3 prevEndPoint = new Vector3(-2f, 2f);
    public RoadSection GenerateSecton(int sectionIndex)
    {
        Vector3[] points = new Vector3[16];
        points[0] = new Vector3(-2f, prevEndPoint.y);
        for (int i = 1; i <= 15; i++)
        {
            points[i] = GeneratePoint(i);
        }
        prevEndPoint = points[15];

        RoadSection newSection = new RoadSection(sectionIndex, points);
        return newSection;
    }

    private Vector3 GeneratePoint(int i)
    {
        float pointXAxis = Mathf.Lerp(-2f, 2f, (float)i/ 15);
        float pointYAxis = Random.Range(1f, 2f);
        Vector3 point = new Vector3(pointXAxis, pointYAxis);

        return point;
    }
}
