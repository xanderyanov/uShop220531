using MongoDB.Bson.Serialization.Attributes;

namespace uShop.Domain
{
    public class DomainItem
    {
        /// <summary>
        /// UTC datetime of last save.
        /// </summary>
        public DateTime LastModified { get; set; }

        /// <summary>
        /// If created in user action.
        /// </summary>
        [BsonIgnoreIfDefault]
        public DateTimeOffset CreatedOn { get; set; }

        /// <summary>
        /// If edited in user action.
        /// </summary>
        [BsonIgnoreIfDefault]
        public DateTimeOffset EditedOn { get; set; }

        /// <summary>
        /// If published in user action.
        /// </summary>
        [BsonIgnoreIfDefault]
        public DateTimeOffset PublishedOn { get; set; }

        /// <summary>
        /// If deleted in user action.
        /// </summary>
        [BsonIgnoreIfDefault]
        public DateTimeOffset DeletedOn { get; set; }

        public virtual void UpdateLace()
        {
        }
    }
}
