class Journal
{
    private readonly List<Entry> _entries = new List<Entry>();
    private const char Separator = '|';

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
            Console.WriteLine();
        }
    }

    public void SaveToFile(string filename)
    {
        using StreamWriter outputFile = new StreamWriter(filename);

        foreach (Entry entry in _entries)
        {
            outputFile.WriteLine(string.Join(Separator, entry._date, entry._prompt, entry._response, entry._mood));
        }
    }

    public void LoadFromFile(string filename)
    {
        _entries.Clear();

        foreach (string line in File.ReadLines(filename))
        {
            string[] parts = line.Split(Separator);
            if (parts.Length == 4)
            {
                _entries.Add(new Entry(parts[0], parts[1], parts[2], parts[3]));
            }
        }
    }
}