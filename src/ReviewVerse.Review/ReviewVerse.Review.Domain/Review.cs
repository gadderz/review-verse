using ReviewVerse.Common.Entities;

namespace ReviewVerse.Review.Domain;

public class Review : BaseEntity
{
    public Review(byte rating, string mediaId, string userId, string text)
    {
        Rating = rating;
        MediaId = mediaId;
        UserId = userId;
        Text = text;
        CreatedAt = DateTime.UtcNow;
    }

    public byte Rating { get; private set; }
    public string MediaId { get; private set; }
    public string UserId { get; private set; }
    public string Text { get; private set; }

    public void UpdateRating(byte newRating)
    {
        if (newRating < 1 || newRating > 10)
        {
            throw new ArgumentOutOfRangeException(nameof(newRating), "Rating must be between 1 and 10.");
        }

        Rating = newRating;
        UpdatedAt = DateTime.UtcNow;
    }
}
