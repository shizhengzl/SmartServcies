namespace Core.AppWebApi
{
    public class RequiredRule
    {
        public bool required { get; set; } = true;

        public string message { get; set; }

        public string trigger { get; set; } = "blur";
    }
}
