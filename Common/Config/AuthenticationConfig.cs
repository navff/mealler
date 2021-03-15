namespace Common.Config
{
    public class AuthenticationConfig
    {
        public GoogleAuthConfig Google { get; set; }
        public VkAuthConfig Vk { get; set; }

        public class GoogleAuthConfig
        {
            public string ClientId { get; set; }
            public string ClientSecret { get; set; }
        }

        public class VkAuthConfig
        {
            public string ClientId { get; set; }
            public string ClientSecret { get; set; }
        }
    }
}