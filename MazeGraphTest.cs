using UnityEngine;
using System;
using QuickGraph;
using QuickGraph.Algorithms;


public class MazeGraphTest : MonoBehaviour
{
	static int Main(string[] args){
		AdjacencyGraph<MazeGraphVertex, MazeGraphEdge<MazeGraphVertex>> g = new AdjacencyGraph<MazeGraphVertex, MazeGraphEdge<MazeGraphVertex>> ();
		MazeVertexFactory vFact = new MazeVertexFactory ();
		MazeEdgeFactory<MazeGraphVertex> eFact = new MazeEdgeFactory<MazeGraphVertex> ();
		System.Random rnd = new System.Random ();
		MazeGraphOptions opts = new MazeGraphOptions (6, 10, 3, 3, 3, false);

		MazeGraphFactory.Create (g, vFact.Create, eFact.Create, rnd, opts);
		Console.WriteLine (g.ToString ());
		return 0;
	}

	private void Start(){
		AdjacencyGraph<MazeGraphVertex, MazeGraphEdge<MazeGraphVertex>> g = new AdjacencyGraph<MazeGraphVertex, MazeGraphEdge<MazeGraphVertex>> ();
		MazeVertexFactory vFact = new MazeVertexFactory ();
		MazeEdgeFactory<MazeGraphVertex> eFact = new MazeEdgeFactory<MazeGraphVertex> ();
		System.Random rnd = new System.Random ();
		MazeGraphOptions opts = new MazeGraphOptions (6, 10, 3, 3, 3, false);

		MazeGraphFactory.Create (g, vFact.Create, eFact.Create, rnd, opts);
		Console.WriteLine (g.ToString ());
	}
}

