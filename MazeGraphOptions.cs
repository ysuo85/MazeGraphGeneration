using System;

namespace QuickGraph
{
	public struct MazeGraphOptions
	{
		public int vertexCount;
		public int edgeCount;
		public int branchingFactor;
		public int startingPoints;
		public int treasures;
		public bool selfEdges;

		public MazeGraphOptions(int v, int e, int bf, int starts, int treasures, bool self){
			this.vertexCount = v;
			this.edgeCount = e;
			this.branchingFactor = bf;
			this.startingPoints = starts;
			this.treasures = treasures;
			this.selfEdges = self;
		}
	}
}

