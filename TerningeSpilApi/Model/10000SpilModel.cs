namespace TerningeSpilApi.Model
{
    public class Die
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public bool IsActive { get; set; } = true;
        public int Round { get; set; }

    }
}
