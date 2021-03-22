using UnityEngine;

public class RoadSectionGeneratorService
{
    private const float minYAxis = 1f;
    private const float maxYAxis = 10f;
    private Vector3 prevEndPoint = new Vector3(-2f, 2f);
    private float prevYAxis = 2f;
    public RoadSection GenerateSecton(int sectionIndex)
    {
        var points = new Vector3[16];
        points[0] = new Vector3(-2f, prevEndPoint.y);
        for (int i = 1; i <= 15; i++)
        {
            points[i] = GeneratePoint(i);
        }
        prevEndPoint = points[15];

        return new RoadSection(sectionIndex, points);
    }

    private Vector3 GeneratePoint(int i)
    {
        float pointXAxis = Mathf.Lerp(-2f, 2f, (float)i/ 15);
        float pointYAxis = Random.Range(prevYAxis - 1f, prevYAxis + 1f);
        pointYAxis = pointYAxis > maxYAxis ? maxYAxis : pointYAxis;
        pointYAxis = pointYAxis < minYAxis ? minYAxis : pointYAxis;
        prevYAxis = pointYAxis;

        return new Vector3(pointXAxis, pointYAxis);
    }
}
