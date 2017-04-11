using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;

namespace QuickGraph
{
	/// <summary>
	/// The default <see cref="IEdge&lt;TVertex&gt;"/> implementation.
	/// </summary>
	/// <typeparam name="TVertex">The type of the vertex.</typeparam>
	#if !SILVERLIGHT
	[Serializable]
	#endif
	[DebuggerDisplay("{Source}->{Target}")]
	public class MazeGraphEdge<TVertex> 
		: Edge<TVertex>
	{
		public int Score { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="Edge&lt;TVertex&gt;"/> class.
		/// </summary>
		/// <param name="source">The source.</param>
		/// <param name="target">The target.</param>
		public MazeGraphEdge(TVertex source, TVertex target) : base(source, target)
		{
			Contract.Requires(source != null);
			Contract.Requires(target != null);
			Contract.Ensures(this.Source.Equals(source));
			Contract.Ensures(this.Target.Equals(target));

			this.Score = 0;
		}

		public MazeGraphEdge(TVertex source, TVertex target, int score) : base(source, target)
		{
			this.Score = score;
		}

		/// <summary>
		/// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
		/// </returns>
		public override string ToString()
		{
			return base.ToString() + "Score: " + this.Score;
		}
	}
}
