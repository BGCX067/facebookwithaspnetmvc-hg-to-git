namespace Facebook.Business.Domain.Internals
{
    public interface IFacebookKeyRepository
    {
        /// <summary>
        /// Retrieve a facebook key representation given the keyword.
        /// </summary>
        /// <param name="key">The keyword to find about.</param>
        /// <returns>The facebook key representation if exist, null otherwise.</returns>
        FacebookKey Find(string key);

        void Add(string key);
    }
}