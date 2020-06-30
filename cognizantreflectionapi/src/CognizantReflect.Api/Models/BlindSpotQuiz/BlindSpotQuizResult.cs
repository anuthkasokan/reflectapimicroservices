namespace CognizantReflect.Api.Models.BlindSpotQuiz
{
    public class BlindSpotQuizResult
    {
        public long id { get; set; }
        public long attemptid { get; set; }
        //described about themselves
        public string[] facade { get; set; }
        //themselves and coworker
        public string[] arena { get; set; }
        //others did but not themselves
        public string[] blindspot { get; set; }
        //noone selects
        public string[] unknown { get; set; }

    }
}
