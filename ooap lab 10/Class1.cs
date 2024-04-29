using System;
using System.Collections.Generic;

// Visitor interface
interface IParagraphStyleVisitor
{
    void Visit(SingleLineParagraph paragraph);
    void Visit(MultiLineParagraph paragraph);
}

// Element interface
interface IParagraph
{
    void Accept(IParagraphStyleVisitor visitor);
}

// Concrete Element - SingleLineParagraph
class SingleLineParagraph : IParagraph
{
    public void Accept(IParagraphStyleVisitor visitor)
    {
        visitor.Visit(this);
    }
}

// Concrete Element - MultiLineParagraph
class MultiLineParagraph : IParagraph
{
    public void Accept(IParagraphStyleVisitor visitor)
    {
        visitor.Visit(this);
    }
}

// Concrete Visitor - DialogBox
class DialogBox : IParagraphStyleVisitor
{
    public void Visit(SingleLineParagraph paragraph)
    {
        Console.WriteLine("Setting paragraph style to single line.");
    }

    public void Visit(MultiLineParagraph paragraph)
    {
        Console.WriteLine("Setting paragraph style to multi-line.");
    }
}

// Client
class TextProcessor
{
    private readonly List<IParagraph> paragraphs = new List<IParagraph>();

    public void AddParagraph(IParagraph paragraph)
    {
        paragraphs.Add(paragraph);
    }

    public void ProcessParagraphs(IParagraphStyleVisitor visitor)
    {
        foreach (var paragraph in paragraphs)
        {
            paragraph.Accept(visitor);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        TextProcessor textProcessor = new TextProcessor();

        // Adding paragraphs
        textProcessor.AddParagraph(new SingleLineParagraph());
        textProcessor.AddParagraph(new MultiLineParagraph());

        // Prompt user to choose paragraph style
        Console.WriteLine("Choose paragraph style:");
        Console.WriteLine("1. Single line");
        Console.WriteLine("2. Multi-line");
        string choice = Console.ReadLine();

        // Process paragraphs based on user's choice
        DialogBox dialogBox = new DialogBox();
        if (choice == "1")
        {
            Console.WriteLine("Setting paragraph style to single line.");
            textProcessor.ProcessParagraphs(dialogBox); // Process single line paragraphs
        }
        else if (choice == "2")
        {
            Console.WriteLine("Setting paragraph style to multi-line.");
            textProcessor.ProcessParagraphs(dialogBox); // Process multi-line paragraphs
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
    }
}
