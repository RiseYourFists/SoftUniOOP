namespace BuilderDesignPattern
{
    public class PersonBuilder 
    {
        private Person person;

        public PersonBuilder()
        {
            person = new Person();
        }

        public Person Build() => person;

        public PersonBuilder SetAge(int age)
        {
            person.Age = age;
            return this;
        }

        public PersonBuilder SetGender(Gender gender)
        {
            person.Gender = gender;
            return this;
        }

        public PersonBuilder SetName(string name)
        {
            person.Name = name;
            return this;
        }
    }
}
