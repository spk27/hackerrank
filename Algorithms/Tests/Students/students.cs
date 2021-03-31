using System;
using System.Collections.Generic;
using System.Linq;

public class LanguageStudent
{
    public List<string> Languages { get; set; } = new List<string>();

    public void AddLanguage(string language)
    {
        if(!Languages.Where(l => l == language).Any())
            Languages.Add(language);
    }
}

public class LanguageTeacher : LanguageStudent
{
    public bool Teach(LanguageStudent student, string language)
    {
        student.Languages.Add(language);

        if(Languages.Where(l => l == language).Any())
        {
            return true;
        }

        return false;
    }

}

public class Program
{
    public static void Main(string[] args)
    {
        LanguageTeacher teacher = new LanguageTeacher();
        teacher.AddLanguage("English");

        LanguageStudent student = new LanguageStudent();
        teacher.Teach(student, "English");

        foreach (var language in student.Languages)
            Console.WriteLine(language);
    }
}