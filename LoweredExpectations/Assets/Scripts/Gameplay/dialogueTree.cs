using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class DialogueTree
{
	private DirectedGraph _conversation;

	// TODO 
	// need to read in a conversation (set of questions and responses)
	// initialize conversation with size (# questions)
	// loop through the questions and create new question objects with descriptions and responses and add those to the conversation
	// set up a tester scipt to go through the conversation

	public DialogueTree(string filename)
	{
		_conversation = new DirectedGraph();
		ParseQuestions(ExtractLinesFromFile(filename));
		Node currentQuestion = _conversation.Header;

		// Test!
		Debug.Log("Test Start!");
		Debug.Log(currentQuestion.Description);
		Debug.Log("   > answering with " + currentQuestion.Responses[0] + "(0)");
		currentQuestion = _conversation.Next(0);
		Debug.Log(currentQuestion.Description);
		Debug.Log("   > answering with " + currentQuestion.Responses[1] + "(1)");
		currentQuestion = _conversation.Next(1);
		Debug.Log(currentQuestion.Description);
		Debug.Log("   > answering with " + currentQuestion.Responses[0] + "(0)");
		currentQuestion = _conversation.Next(0);
		if (currentQuestion == null)
		{
			Debug.Log("DONE");
		}
	}

	// parses a conversation file for a list of questions and possible responses
	// format: int(question type), string(question), string(response), string(response), ...
	private string[] ExtractLinesFromFile(string filename)
	{
		TextAsset data = Resources.Load("Text/" + filename) as TextAsset;
		return data.text.Split("\n"[0]);
	}

	// parse the questions with the given lines
	private void ParseQuestions(string[] lines)
	{
		string[] lineData;
		char contentDelimiter = ',';
		char responseDelimiter = '|';

		Debug.Log("---- Questions ----");
		for (int i = 0; i < lines.Length; ++i)
		{
			lineData = lines[i].Split(contentDelimiter);

			// maybe use conversation type eventually?
			int nodeListIndex = Int32.Parse(lineData[0]);
			string question = lineData[1];
			string[] responses = lineData[2].Split(responseDelimiter);

			Node q = new Node(question, responses);
			if (nodeListIndex == -1)
			{
				_conversation.SetHeader(q);
			}
			else
			{
				_conversation.Add(nodeListIndex, q);
			}
		}
	}
}
