using System;

namespace Facebook.Business.Domain
{
    /// <summary>
    /// This class acts as a super layer type for the implementation of the entity pattern.
    /// </summary>
    public class Entity<T> : IEquatable<T> where T : Entity<T>
    {
        public int Id { get; set; }

        #region Implementation of IEquatable<T>

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(T other)
        {
            return !Equals(other, null) && Equals(Id, other.Id);
        }

        #endregion
    }
}