using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

class Task
{
    public string taskName = "";
    public SpaceCadet[] data = new SpaceCadet[] { };
}

class SpaceCadet
{
    public string name = "";
    public string group = "";
    public string discipline = "";
    public double mark = 0;
}

class Program
{
    static IEnumerable<Newtonsoft.Json.Linq.JObject> GetStudentsWithHighestGPA(Task json)
    {
        var max = json.data.GroupBy(c => c.name).Max(c => c.Average(x => x.mark));
        var studentsWithHighestGPA = json.data
        .GroupBy(c => c.name)
        .Where(c => c.Average(x => x.mark) == max)
        .Select(c => new JObject(new JProperty("Cadet", c.Key), new JProperty("GPA", c.Average(x => x.mark))));

        return studentsWithHighestGPA;
    }

    static IEnumerable<Newtonsoft.Json.Linq.JObject> CalculateGPAByDiscipline(Task json)
    {
        var GPAByDiscipline = json.data
        .GroupBy(c => c.discipline)
        .Select(d => new JObject(new JProperty(d.Key, d.Average(c => c.mark))));

        return GPAByDiscipline;
    }

    static IEnumerable<Newtonsoft.Json.Linq.JObject> GetBestGroupsByDiscipline(Task json)
    {
        var bestGroupsByDiscipline = json.data
        .GroupBy(c => new { c.discipline, c.group })
        .Select(d => new { Discipline = d.Key.discipline, Group = d.Key.group, GPA = d.Average(c => c.mark) })
        .GroupBy(d => d.Discipline)
        .Select(s => new JObject(new JProperty("Discipline", s.Key),
                new JProperty("Group", s.OrderByDescending(c => c.GPA).FirstOrDefault().Group),
                new JProperty("GPA", s.Max(c => c.GPA))));

        return bestGroupsByDiscipline;
    }

    static void Main(string[] args)
    {
        string inpPath = args[0];
        string outpPath = args[1];

        var json = JsonConvert.DeserializeObject<Task>(File.ReadAllText(inpPath));

        if (json.taskName == "GetStudentsWithHighestGPA")
        {
            IEnumerable<Newtonsoft.Json.Linq.JObject> ans = GetStudentsWithHighestGPA(json);
            var result = new JObject(new JProperty("Response", ans));
            File.WriteAllText(outpPath, JsonConvert.SerializeObject(result, Formatting.Indented));
        }
        else if (json.taskName == "CalculateGPAByDiscipline")
        {
            IEnumerable<Newtonsoft.Json.Linq.JObject> ans = CalculateGPAByDiscipline(json);
            var result = new JObject(new JProperty("Response", ans));
            File.WriteAllText(outpPath, JsonConvert.SerializeObject(result, Formatting.Indented));
        }
        else if (json.taskName == "GetBestGroupsByDiscipline")
        {
            IEnumerable<Newtonsoft.Json.Linq.JObject> ans = GetBestGroupsByDiscipline(json);
            var result = new JObject(new JProperty("Response", ans));
            File.WriteAllText(outpPath, JsonConvert.SerializeObject(result, Formatting.Indented));
        }
    }
}