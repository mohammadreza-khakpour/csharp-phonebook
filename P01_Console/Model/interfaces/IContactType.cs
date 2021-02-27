namespace P01_Console
{
    interface IContactType
    {
        int Id { get; set; }
        string ContactTitle { get; set; }
        string ContactValue { get; set; }
        int Add();
        int Delete();
    }
}