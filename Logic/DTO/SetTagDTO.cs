namespace Logic.DTO
{
    public class SetTagDTO
    {
        public SetTagDTO(long id, string text)
        {
            Id   = id;
            Text = text;
        }
        public SetTagDTO(string text)
        {
            Text = text;
        }
        public SetTagDTO(Data.Maps.SetTag setTag)
        {
            Id   = setTag.ID_TagSet;
            Text = setTag.Text;
        }
        
        
        public long   Id   {get; set;}
        public string Text {get; set;}

        public override string ToString()
        {
            return Text;
        }
    }
}