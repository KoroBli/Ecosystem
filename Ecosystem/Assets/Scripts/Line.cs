using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Line
{
    const float verticalLineGradient = 1e5f; // Lo igualamos a 10 elevado a 5

    float gradient;
    float y_Intercept;

    float gradientPerpendicular;

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
    }
}
