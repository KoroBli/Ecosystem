using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public bool walkable;
    public Vector3 worldPosition;

    public Node(bool m_walkable, Vector3 m_worldPosition)
    {
        walkable = m_walkable;
        worldPosition = m_worldPosition;
    }
}
