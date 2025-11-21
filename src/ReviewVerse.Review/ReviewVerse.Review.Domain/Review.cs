namespace ReviewVerse.Review.Domain;

public class Review
{
    public Review(byte rating, string mediaId, string userId, string comment)
    {
        Rating = rating;
        MediaId = mediaId;
        UserId = userId;
        Comment = comment;
    }

    public byte Rating { get; private set; }
    public string MediaId { get; private set; }
    public string UserId { get; private set; }
    public string Comment { get; private set; }

    public void UpdateRating(byte newRating)
    {
        if (newRating < 1 || newRating > 10)
        {
            throw new ArgumentOutOfRangeException(nameof(newRating), "Rating must be between 1 and 10.");
        }

        Rating = newRating;
    }
}
