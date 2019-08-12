namespace AElfChain.SDK
{
    public class SdkOption
    {
        public string ServiceUrl { get; set; }
        
        public int FailReTryTimes { get; set; } = 1;
        
        public int TimeoutSeconds { get; set; } = 60;
    }
}