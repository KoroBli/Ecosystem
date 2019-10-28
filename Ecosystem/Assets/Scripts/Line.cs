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

        gradientPerpendicular = dy / dx;


    }
}
