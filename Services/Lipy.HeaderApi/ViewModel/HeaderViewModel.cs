namespace Lipy.HeaderApi.ViewModel
{
    public class HeaderViewModel
    {
        public string Title { get; set; }
        public string Link { get; set; }

        public bool IsValid => Title != null && Link != null;
    }
}
