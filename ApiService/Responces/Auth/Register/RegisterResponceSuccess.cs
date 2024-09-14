namespace ApiService.Responces.Auth.Register
{
    public class RegisterResponceSuccess : RegisterResponceBase
    {
        public override int status { get; set; }


        public RegisterResponceSuccesBody body { get; set; }
        public override string type { get ; set ; }
    }

    public class RegisterResponceSuccesBody
    {


        public string message;
    }
}
