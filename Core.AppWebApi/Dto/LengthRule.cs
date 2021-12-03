namespace Core.AppWebApi
{
    public class LengthRule
    {
        public int min { get; set; } = 1;
        public int max {  get; set; }

        public string message { get; set;  }
    }
}
