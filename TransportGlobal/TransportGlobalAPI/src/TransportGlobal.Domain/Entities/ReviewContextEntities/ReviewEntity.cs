using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TransportGlobal.Domain.Constants;
using TransportGlobal.Domain.Entities.TransportContextEntities;
using TransportGlobal.Domain.Exceptions;
using TransportGlobal.Domain.SeedWorks;

namespace TransportGlobal.Domain.Entities.ReviewContextEntities
{
    public class ReviewEntity : BaseEntity
    {
        [ForeignKey(nameof(TransportContract))]
        public int TransportContractID { get; set; }

        public TransportContractEntity? TransportContract { get; set; }

        public int Score { get; set; }

        [StringLength(255, MinimumLength = 3)]
        public string Comment { get; set; }

        public ReviewEntity(int transportContractID, int score, string comment)
        {
            if (score > 5 || score < 1) throw new ClientSideException(ExceptionConstants.ReviewScoreOutOfRange);

            TransportContractID = transportContractID;
            Score = score;
            Comment = comment;
        }
    }
}
