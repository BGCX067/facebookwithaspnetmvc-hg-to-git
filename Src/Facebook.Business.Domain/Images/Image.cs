namespace Facebook.Business.Domain.Images
{
    public class Image : Entity<Image>
    {
        #region Fields

        private byte[] _data;
        private string _description;
        private string _format;

        #endregion

        protected Image()
        {
            
        }

        public Image(byte[] data, string format, string description = null)
        {
            _data = data;
            _format = format;
            _description = description;
        }


        public virtual byte[] Data
        {
            get { return _data; }
            protected set { _data = value; }
        }

        public virtual string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public virtual string Format
        {
            get { return _format; }
        }

        public static readonly Image NoImage = new Image(new byte[0], string.Empty, "No Image");
    }
}