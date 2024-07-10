namespace ATM.Model
{
    public class Banknote(Guid id, int denomination)
    {
        public Guid SerialNumber { get; private set; } = id;
        public int Denomination { get; private set; } = denomination;
    }
}
