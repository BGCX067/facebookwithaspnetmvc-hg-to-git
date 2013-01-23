namespace Facebook.Business.Domain.Internals
{
    public class FacebookKey : Entity<FacebookKey>
    {
        private string _keyBase;
        private int _count;

        protected FacebookKey()
        {
            
        }

        public FacebookKey(string keyBase)
        {
            _keyBase = keyBase;
            _count = 0;
        }

        public virtual string KeyBase
        {
            get { return _keyBase; }
            set { _keyBase = value; }
        }

        public virtual int Count
        {
            get { return _count; }
            set { _count = value; }
        }
    }
}