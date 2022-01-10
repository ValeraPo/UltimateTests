using System;

namespace Logic.DTO
{
    public class FeedbackDTO
    {
        public FeedbackDTO(long id, string text, DateTime dateTime, string userName)
        {
            Id       = id;
            Text     = text;
            DateTime = dateTime;
            UserName = userName;
        }
        public FeedbackDTO(string text, DateTime dateTime, string userName)
        {
            Text     = text;
            DateTime = dateTime;
            UserName = userName;
        }
        public FeedbackDTO(Data.Maps.Feedback feedback)
        {
            Id       = feedback.ID_Feedback;
            Text     = feedback.Text;
            DateTime = feedback.DateTime;
            UserName = feedback.User.FullName;
        }
        
        
        public long     Id       {get; set;}
        public string   Text     {get; set;}
        public DateTime DateTime {get; set;}
        public string   UserName {get; set;}
    }
}