using System.Collections.Generic;
using System.Text;

class Video
{
    private string _title;
    private string _author;
    private int _length;
    private List<Comment> _comments;

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    public string GetDisplayText()
    {
        StringBuilder output = new StringBuilder();
        output.AppendLine($"Title: {_title}");
        output.AppendLine($"Author: {_author}");
        output.AppendLine($"Length: {_length} seconds");
        output.AppendLine($"Number of comments: {GetNumberOfComments()}");
        output.AppendLine("Comments:");

        foreach (Comment comment in _comments)
        {
            output.AppendLine(comment.GetDisplayText());
        }

        return output.ToString().TrimEnd();
    }
}
