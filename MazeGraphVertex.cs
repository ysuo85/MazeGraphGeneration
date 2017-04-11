using System;
using QuickGraph;

namespace QuickGraph
{
	public class MazeGraphVertex
	{
		private bool startingPoint;

		public Guid ID { get; set;}
		public bool StartingPoint {
			get {
				return startingPoint;
			}
			set {
				startingPoint = value;
				Discovered = value;
			}
		}
		public bool HasTreasure { get; set; }
		public bool Discovered { get; set; }
		public int Score { get; set; }

		public MazeGraphVertex() {
			this.ID = System.Guid.NewGuid ();
			this.StartingPoint = false;
			this.HasTreasure = false;
			this.Score = 0;
		}
	}
}

