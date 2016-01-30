using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DirectedGraph
{
	private List<NodeList> _adjacencyList;
	private int _currentNodeIndex;

	private Node _header;
	public Node Header { get { return _header; } }

	private class NodeList
	{
		public List<Node> nodes;

		public NodeList()
		{
			nodes = new List<Node>();
		}
	}
		
	public DirectedGraph()
	{
		int arbitrarySize = 20;
		_adjacencyList = new List<NodeList>(arbitrarySize);
		for (int i = 0; i < arbitrarySize; ++i)
		{
			_adjacencyList.Add(new NodeList());
		}

		_currentNodeIndex = 0;
	}

	// set the head of node
	public void SetHeader(Node n)
	{
		_header = n;
	}

	// add a node to a nodelist at the given index
	public void Add(int indexToAdd, Node node)
	{
		_adjacencyList[indexToAdd].nodes.Add(node);
	}

	// get the next node to the current based on the index of the next
	// the next index is relative to the number of edges the current node has
	// example: node A (index 0) has 3 other nodes it points to (B, C, D)
	// if next index is 1, next node is C
	public Node Next(int nextNodeIndex)
	{
		int numEdges = _adjacencyList[_currentNodeIndex].nodes.Count;
		if (nextNodeIndex < numEdges)
		{
			Node next = _adjacencyList[_currentNodeIndex].nodes[nextNodeIndex];
			_currentNodeIndex = next.Id;
			return next;
		}
		else
		{
			return null;
		}
	}
}
