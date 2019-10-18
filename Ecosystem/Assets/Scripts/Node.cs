using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public bool walkable;
    public Vector3 worldPosition;
    public int gridX;
    public int gridY;

    public int gCost;
    public int hCost;
    public Node parent;

    public Node(bool m_walkable, Vector3 m_worldPosition, int m_gridX, int m_gridY)
    {
        walkable = m_walkable;
        worldPosition = m_worldPosition;
        gridX = m_gridX;
        gridY = m_gridY;
    }

    public int fCost
    {
        get
        {
            return gCost + hCost;
        }
    }
}
