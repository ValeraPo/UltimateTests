namespace Logic.DTO
{
    public class SetTagDTO : AbstractOnPropertyChanged
    {
        private string _text;
        
        
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


        public long Id {get; set;}
        public string Text
        {
            get => _text;
            set
            { if (_text == value)
                  return;
              _text = value;
              OnPropertyChanged(nameof(Text)); }
        }
    }
}