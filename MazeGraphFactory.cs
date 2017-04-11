using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using QuickGraph;

namespace QuickGraph.Algorithms
{
	public static class MazeGraphFactory
	{
		public static TVertex GetVertex<TVertex,TEdge>(IVertexListGraph<TVertex,TEdge> g, Random rnd)
			where TEdge : IEdge<TVertex>
		{
			Contract.Requires(g != null);
			Contract.Requires(rnd != null);
			Contract.Requires(g.VertexCount > 0);

			return GetVertex<TVertex,TEdge>(g.Vertices, g.VertexCount, rnd);
		}

		public static TVertex GetVertex<TVertex,TEdge>(IEnumerable<TVertex> vertices, int count, Random rnd)
			where TEdge : IEdge<TVertex>
		{
			Contract.Requires(vertices != null);
			Contract.Requires(rnd != null);
			Contract.Requires(count > 0);

			int i = rnd.Next(count);
			foreach (var v in vertices)
			{
				if (i == 0)
					return v;
				else
					--i;
			}

			// failed
			throw new InvalidOperationException("Could not find vertex");
		}

		public static TEdge GetEdge<TVertex, TEdge>(IEdgeSet<TVertex, TEdge> g, Random rnd)
			where TEdge : IEdge<TVertex>
		{
			Contract.Requires(g != null);
			Contract.Requires(rnd != null);
			Contract.Requires(g.EdgeCount > 0);

			int i = rnd.Next(g.EdgeCount);
			foreach (var e in g.Edges)
			{
				if (i == 0)
					return e;
				else
					--i;
			}

			// failed
			throw new InvalidOperationException("Could not find edge");
		}

		public static TEdge GetEdge<TVertex,TEdge>(IEnumerable<TEdge> edges, int count, Random rnd)
			where TEdge : IEdge<TVertex>
		{
			Contract.Requires(edges != null);
			Contract.Requires(rnd != null);
			Contract.Requires(count > 0);

			int i = rnd.Next(count);
			foreach (var e in edges)
			{
				if (i == 0)
					return e;
				else
					--i;
			}

			// failed
			throw new InvalidOperationException("Could not find edge");
		}

		public static void Create<TEdge>(
			IMutableVertexAndEdgeListGraph<MazeGraphVertex, TEdge> g,
			VertexFactory<MazeGraphVertex> vertexFactory,
			EdgeFactory<MazeGraphVertex,TEdge> edgeFactory,
			Random rnd,
			MazeGraphOptions opts
			) where TEdge : IEdge<MazeGraphVertex>
		{
			Contract.Requires(g != null);
			Contract.Requires(vertexFactory != null);
			Contract.Requires(edgeFactory != null);
			Contract.Requires(rnd != null);
			Contract.Requires(opts.vertexCount > 0);
			Contract.Requires(opts.edgeCount >= 0);
			Contract.Requires(
				!(!g.AllowParallelEdges && !opts.selfEdges) ||
				opts.edgeCount <= opts.vertexCount * (opts.vertexCount -1) // directed graph
			);

			var vertices = new MazeGraphVertex[opts.vertexCount];
			for (int i = 0; i < opts.vertexCount; ++i)
				g.AddVertex(vertices[i] = vertexFactory());

			var freeVertices = new List<MazeGraphVertex> (vertices);

			MazeGraphVertex a;
			MazeGraphVertex b;
			int j, k;
			j = k = 0;
			while (j < opts.edgeCount)
			{
				a = freeVertices[rnd.Next(opts.vertexCount - k)];
				do
				{
					b = vertices[rnd.Next(opts.vertexCount)];
				}
				while (opts.selfEdges == false && a.Equals(b));

				if (g.AddEdge (edgeFactory (a, b))) {
					if (g.OutDegree (a) >= opts.branchingFactor) {
						freeVertices.Remove (a);
						++k;
					}
					++j;
				}
			}

			j = k = 0;
			while (j < opts.treasures) {
				a = MazeGraphFactory.GetVertex(g, rnd);
				if (!(a.HasTreasure)) {
					a.HasTreasure = true;
					++k;
				}
			}

			while (k < opts.startingPoints) {
				b = MazeGraphFactory.GetVertex(g, rnd);
				if (!(b.StartingPoint)) {
					b.StartingPoint = true;
					++k;
				}
			}
		}
	}
}
