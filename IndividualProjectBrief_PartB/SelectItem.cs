namespace IndividualProjectBrief_PartB
{
    class SelectItem //Used in presenting the id and value of an object (e.g. 1 - Advanced Software Engineering)
    {
        public int Id { get; }

        public string Value { get; }
        public SelectItem(int id, string value)
        {
            Id = id;
            Value = value;
        }
        public override string ToString()
        {
            return $"{Id} - {Value}";
        }
    }


}


