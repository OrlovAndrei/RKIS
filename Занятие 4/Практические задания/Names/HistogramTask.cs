using System;
using System.Collections.Generic;




public class HistogramTask
{
    public int[] PrepareBirthData(List<Person> people, string name)
    {


        int[] frequency = new int[31];



        foreach (var person in people)
        {
            if (person.Name.Equals(name, StringComparison.OrdinalIgnoreCase) && person.BirthDate.Day != 1)
            {
                frequency[person.BirthDate.Day - 1]++;
            }
        }



        return frequency;
    }
}
public class Person
{
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }

}