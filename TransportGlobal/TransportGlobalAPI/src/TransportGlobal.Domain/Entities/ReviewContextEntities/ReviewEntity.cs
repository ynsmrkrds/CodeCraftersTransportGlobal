using System.ComponentModel.DataAnnotations;
using TransportGlobal.Domain.SeedWorks;

namespace TransportGlobal.Domain.Entities.ReviewContextEntities
{
    // TODO: TransportEntity model eklenecek ve ilişki kurulacak

    public class ReviewEntity : BaseEntity
    {
        public int TransportID { get; set; }

        public int Score { get; set; }

        [StringLength(255, MinimumLength = 3)]
        public string Comment { get; set; }

        public ReviewEntity(int transportID, int score, string comment)
        {
            TransportID = transportID;
            Score = score;
            Comment = comment;
        }
    }
}
