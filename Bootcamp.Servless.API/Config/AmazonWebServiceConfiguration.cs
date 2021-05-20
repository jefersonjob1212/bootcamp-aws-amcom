namespace Bootcamp.Servless.API.Config
{
    public class AmazonWebServiceConfiguration
    {
        public const string Configure = "AWSConfiguration";
        
        public string AccessKey { get; set; }
        public string SecretKey { get; set; }
        public string BucketName { get; set; }
    }
}