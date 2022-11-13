using BorderControl.Contracts;


namespace BorderControl
{
    public class Human : IIdentifiable
    {
        public Human(string name, string age, string id)
        {
            Name = name;
            Age = age;
            Id = id;
        }

        public string Name { get; set; }

        public string Age { get; set; }

        public string Id { get; set; }
    }
}
