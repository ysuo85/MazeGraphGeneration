using System;
using System.Collections.Generic;
using QuickGraph;

namespace QuickGraph
{
	public class MazeEdgeFactory<TVertex>
	{
		public MazeGraphEdge<TVertex> Create(TVertex source, TVertex target){
			MazeGraphEdge<TVertex> edge = new MazeGraphEdge<TVertex> (source, target);
			return edge;
		}
	}
}

