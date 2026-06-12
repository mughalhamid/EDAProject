namespace RedisApplication.Models
{
    public class Claim
    {
        public int Id { get; set; }
        public MotorInsurerPaidClaimStatus? MotorInsurerPaidClaimStatus { get; set; }
        public GarageType? GarageType { get; set; }
        public DateTime? EventDate { get; set; }
        public LossType? TypeOfLoss { get; set; }
        public CauseOfLoss? CauseOfLoss { get; set; }
        public LossReporter? LossReporter { get; set; }
        public DateTime? DeclarationDate { get; set; }
        public PreferredChannel? PreferredChannel { get; set; }
        public decimal? ExcessAmount { get; set; }
        public decimal? RepairingCost { get; set; }
        public PayeeType? PayeeType { get; set; }
        public string? ContactAddress { get; set; }
    }

    public enum MotorInsurerPaidClaimStatus
    {
        Paid,
        InProgress,
        Other
    }

    public enum GarageType
    {
        Network,
        OutsideNetwork
    }

    public enum LossType
    {
        Partial,
        Total
    }

    public enum CauseOfLoss
    {
        Theft,
        Accident,
        Vandalism,
        NaturalEvent,
        Unknown
    }

    public enum LossReporter
    {
        Garage,
        Insured,
        Others
    }

    public enum PreferredChannel
    {
        Letter,
        Email
    }

    public enum PayeeType
    {
        Repairer,
        Insured,
        Others
    }
}
