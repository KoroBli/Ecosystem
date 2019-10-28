using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Line
{
    const float verticalLineGradient = 1e5f; // Lo igualamos a 10 elevado a 5

    float gradient;
    float y_Intercept;
    Vector2 pointOnLine_1;
    Vector2 pointOnLine_2;

    float gradientPerpendicular;
    bool aproachSide;

    public Line(Vector2 pointOnLine, Vector2 pointPerpendicularToLine)
    {
        float dx = pointOnLine.x - pointPerpendicularToLine.x;
        float dy = pointOnLine.y - pointPerpendicularToLine.y;

        if (dx == 0)
        {
            gradientPerpendicular = verticalLineGradient;
        }
        else gradientPerpendicular = dy / dx;

        if (gradientPerpendicular == 0)
        {
            gradient = verticalLineGradient;
        }
        else gradient = -1 / gradientPerpendicular;

        y_Intercept = pointOnLine.y - gradient * pointOnLine.x;
        pointOnLine_1 = pointOnLine;
        pointOnLine_2 = pointOnLine + new Vector2(1, gradient);

        aproachSide = false;
        aproachSide = GetSide(pointPerpendicularToLine);
    }

    bool GetSide(Vector2 p)
    {
        return (p.x - pointOnLine_1.x) * (pointOnLine_2.y - pointOnLine_1.y) > (p.y - pointOnLine_1.y) * (pointOnLine_2.x - pointOnLine_1.x);
    }

    public bool HasCrossedLine(Vector2 p)
    {
        return GetSide(p) != aproachSide;
    }
}
