using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;

[CustomEditor ( typeof ( Graph ) )]
public class GraphEditor : Editor
{
	
	protected Graph m_Graph;
	protected Node_D m_From;
	protected Node_D m_To;
	protected Follower m_Follower;
	protected Path_D m_Path = new Path_D ();

	void OnEnable ()
	{
		m_Graph = target as Graph;
	}

	void OnSceneGUI ()
	{
		if ( m_Graph == null )
		{
			return;
		}
		for ( int i = 0; i < m_Graph.nodes.Count; i++ )
		{
			Node_D node = m_Graph.nodes [ i ];
			for ( int j = 0; j < node.connections.Count; j++ )
			{
				Node_D connection = node.connections [ j ];
				if ( connection == null )
				{
					continue;
				}
				float distance = Vector3.Distance ( node.transform.position, connection.transform.position );
				Vector3 diff = connection.transform.position - node.transform.position;
				Handles.Label ( node.transform.position + ( diff / 2 ), distance.ToString (), EditorStyles.whiteBoldLabel );
				if ( m_Path.nodes.Contains ( node ) && m_Path.nodes.Contains ( connection ) )
				{
					Color color = Handles.color;
					Handles.color = Color.green;
					Handles.DrawLine ( node.transform.position, connection.transform.position );
					Handles.color = color;
				}
				else
				{
					Handles.DrawLine ( node.transform.position, connection.transform.position );
				}
			}
		}
	}

	public override void OnInspectorGUI ()
	{
		m_Graph.nodes.Clear ();
		foreach ( Transform child in m_Graph.transform )
		{
			Node_D node = child.GetComponent<Node_D> ();
			if ( node != null )
			{
				m_Graph.nodes.Add ( node );
			}
		}
		base.OnInspectorGUI ();
		EditorGUILayout.Separator ();
		m_From = ( Node_D )EditorGUILayout.ObjectField ( "From", m_From, typeof ( Node_D ), true );
		m_To = ( Node_D )EditorGUILayout.ObjectField ( "To", m_To, typeof ( Node_D ), true );
		m_Follower = ( Follower )EditorGUILayout.ObjectField ( "Follower", m_Follower, typeof ( Follower ), true );
		if ( GUILayout.Button ( "Show Shortest Path" ) )
		{
			m_Path = m_Graph.GetShortestPath ( m_From, m_To );
			if ( m_Follower != null )
			{
				m_Follower.Follow ( m_Path );
			}
			Debug.Log ( m_Path );
			SceneView.RepaintAll ();
		}
	}
	
}
