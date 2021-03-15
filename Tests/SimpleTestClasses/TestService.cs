namespace Tests.SimpleTestClasses
{
    public class TestService
    {
        private readonly InlineService _inlineService;

        public TestService(InlineService inlineService)
        {
            _inlineService = inlineService;
        }

        public string Invoke()
        {
            return _inlineService.GetString();
        }
    }
}