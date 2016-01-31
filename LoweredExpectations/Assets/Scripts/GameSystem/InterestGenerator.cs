using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class InterestGenerator
{
    private static System.Random rngGen = new System.Random();
    // parse the questions with the given lines
    private static List<Interest> GenerateInterests(List<eInterests> interestTypes, string[] lines)
    {
        string[] lineData = new string[0];
        char firstDelimiter = '|';
        char secondDelimiter = ',';
        List<Interest> interests = new List<Interest>();
        for (int i = 0; i < interestTypes.Count; ++i)
        {
            lineData = lines[(int)interestTypes[i]].Split(firstDelimiter);

            string[] verbNoun = lineData[0].Split(secondDelimiter);
            string[] examples = lineData[1].Split(secondDelimiter);
            string[] topics = lineData[2].Split(secondDelimiter);

            Interest newInterest = new Interest(interestTypes[i], verbNoun[0], verbNoun[1], examples[rngGen.Next(0, examples.Length)], topics[rngGen.Next(0, topics.Length)]);
            interests.Add(newInterest);
        }

        return interests;
    }

    public static Paragraph GenerateBiography(string firstName, List<eInterests> interestTypes)
    {
        Paragraph paragraph;
        List<Interest> interests = GenerateInterests(interestTypes, DialogueTree.ExtractLinesFromFile("Interests"));

        for(int i = 0; i < interests.Count; i++)
        {
            Debug.Log(interests[i].Type);
        }
        string[] formatedInterestStrings = DialogueTree.ExtractLinesFromFile("InterestStrings");

        List<string> interestStrings = new List<string>();

        string lineToAdd = "";
        for(int i = 0; i < interests.Count; i++)
        {
            lineToAdd = GetFormatedStringFromInterestType(firstName, interests[i], formatedInterestStrings);
            interestStrings.Add(lineToAdd);
        }

        paragraph = new Paragraph(interestStrings);
        return paragraph;
    }

    private static string GetFormatedStringFromInterestType(string firstName, Interest interest, string[] formatedInterestStrings)
    {
        string interestString = "";
        switch (interest.Type)
        {
            case eInterests.Books:
                // {0} loves to {1}. {0}'s favorite {2} is {3}. {0} thinks the chapters about {4} are amazing.
                interestString = String.Format(formatedInterestStrings[(int)interest.Type], firstName, interest.Verb, interest.Noun, interest.Example, interest.Topic);
                break;
            case eInterests.Hiking:
                // {0} enjoys {1}s. {0} thinks the {2} in {3} are breathtaking.
                interestString = String.Format(formatedInterestStrings[(int)interest.Type], firstName, interest.Verb, interest.Noun, interest.Example, interest.Topic);
                break;
        }

        return interestString;
    }
}

public enum eInterests
{
    Books,
    Hiking,
    Count
}

public class Interest
{
    public eInterests Type;
    public string Verb;
    public string Noun;
    public string Example;
    public string Topic; 

    public Interest(eInterests type, string verb, string noun, string example, string topic)
    {
        Type = type;
        Verb = verb;
        Noun = noun;
        Example = example;
        Topic = topic;
    }
}

public class Paragraph
{
    int LineCount = 0;
    List<string> Text;

    // build a paragrapth with a given input. In this  case, the input is a list of interests.
    public Paragraph(List<string> interests)
    {
        for(int i = 0; i < interests.Count; i++)
        {
            Debug.Log(interests[i]);
        }
    }
}


