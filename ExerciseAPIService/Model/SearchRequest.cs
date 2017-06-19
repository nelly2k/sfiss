namespace ExerciseAPIService.Model
{
    public class SearchRequest
    {
        public string Title { get; set; }

        public int Page { get; set; }

        public int OnPage { get; set; }
    }
}