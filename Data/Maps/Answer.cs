using System.ComponentModel.DataAnnotations;

namespace Data.Maps
{
    public class Answer
    {
        [Key] public                          long     ID_Answ   {get; set;}
        public                                long     ID_Quest  {get; set;}
        [Required] [StringLength(280)] public string   Text      {get; set;}
        public                                bool     IsCorrect {get; set;}
        public                                bool     IsDel     {get; set;}
        public virtual                        Question Question  {get; set;}
    }
}