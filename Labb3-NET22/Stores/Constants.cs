using System;
using System.IO;

namespace Labb3_NET22.Stores;

public static class Constants
{
    public static string QuizlyFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Quizly");
}