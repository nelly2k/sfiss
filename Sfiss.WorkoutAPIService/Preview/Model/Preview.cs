namespace Sfiss.WorkoutAPIService.Preview.Model
{
    public class PreviewItem
    {
        public string Title { get; set; }
        
        public string Completion { get; set; }

        public string Type { get; set; }

        public byte[] Img { get; set; }
    }
}