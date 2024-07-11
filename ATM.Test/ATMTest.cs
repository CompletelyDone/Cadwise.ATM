namespace ATM.Test
{
    public class ATMTest
    {
        [Fact]
        public void AddBanknote()
        {
            ATM.Model.ATM atm = new(Guid.NewGuid(), 2500);

            atm.AddBanknote(100, new(Guid.NewGuid(), 100));
            atm.AddBanknote(100, new(Guid.NewGuid(), 100));
            atm.AddBanknote(100, new(Guid.NewGuid(), 100));

            Assert.True(atm.GetBalance() == 300);
        }
        [Fact]
        public void GetTotalBanknote()
        {
            ATM.Model.ATM atm = new(Guid.NewGuid(), 2500);

            atm.AddBanknote(100, new(Guid.NewGuid(), 100));
            atm.AddBanknote(100, new(Guid.NewGuid(), 100));
            atm.AddBanknote(500, new(Guid.NewGuid(), 500));

            var total = atm.GetTotalBanknotes();
            Console.WriteLine(total[0].count);

            Assert.True(total[0].count == 2);
            Assert.True(total[1].count == 1);
        }
        [Fact]
        public void Dispense()
        {
            ATM.Model.ATM atm = new(Guid.NewGuid(), 2500);

            atm.AddBanknote(100, new(Guid.NewGuid(), 100));
            atm.AddBanknote(100, new(Guid.NewGuid(), 100));
            atm.AddBanknote(100, new(Guid.NewGuid(), 100));
            atm.AddBanknote(500, new(Guid.NewGuid(), 500));
            atm.AddBanknote(500, new(Guid.NewGuid(), 500));
            atm.AddBanknote(500, new(Guid.NewGuid(), 500));
            atm.AddBanknote(1000, new(Guid.NewGuid(), 1000));
            atm.AddBanknote(1000, new(Guid.NewGuid(), 1000));
            atm.AddBanknote(1000, new(Guid.NewGuid(), 1000));

            atm.DispenseBanknotes(2700);

            Assert.True(atm.GetBalance() == 2100);
        }
    }
}