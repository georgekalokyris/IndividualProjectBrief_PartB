namespace IndividualProjectBrief_PartB
{
    class SelectItem
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


