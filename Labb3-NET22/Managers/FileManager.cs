using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Windows.Documents;
using System.Windows.Input;
using Labb3_NET22.DataModels;

namespace Labb3_NET22.Managers;

public class FileManager
{
    private readonly string _folderPath;
    public static readonly string _quizlyFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Quizly");

    public FileManager()
    {
        _folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Quizly");
    }

    
}