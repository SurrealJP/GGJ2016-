using UnityEngine;
using System.Collections;

public class Node
{
	public static int node_id = 0;

	private int _id;
	public int Id { get { return _id; } }

	private string _desc;
	public string Description { get { return _desc; } }

	private string[] _responses;
	public string[] Responses { get { return _responses; } }

	public Node(string desc, string[] resps) : base()
	{
		_id = node_id++;
		_desc = desc;
		_responses = resps;
	}
}
