namespace N31_Amaliyot.Models;

public class Student
{
    public int id { get; set; }
    public string first_name { get; set; } = string.Empty;
    public string last_name { get; set; } = string.Empty;
    public string email { get; set; } = string.Empty;
    public string gender { get; set; } = string.Empty;
    public string birth_day { get; set; } = string.Empty;
    public int speciality_id { get; set; }
    public int location_id { get; set; }
}
