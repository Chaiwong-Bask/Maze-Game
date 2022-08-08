using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// The Node.
/// </summary>
public class Node_D : MonoBehaviour
{

    /// <summary>
    /// The connections (neighbors).
    /// </summary>
    [SerializeField]
    protected List<Node_D> m_Connections = new List<Node_D>();

    /// <summary>
    /// Gets the connections (neighbors).
    /// </summary>
    /// <value>The connections.</value>
    public virtual List<Node_D> connections
    {
        get
        {
            return m_Connections;
        }
    }

    public Node_D this[int index]
    {
        get
        {
            return m_Connections[index];
        }
    }

}
