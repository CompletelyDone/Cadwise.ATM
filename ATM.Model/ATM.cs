namespace ATM.Model
{
    public class ATM(Guid id, int maxSize)
    {
        public Guid Id { get; private set; } = id;
        private int sizeOfCassette = maxSize;
        private Dictionary<int, List<Banknote>> storage = [];
        public List<(int denomination, int count)> GetTotalBanknotes()
        {
            List<int> sortedList = GetSortedNominals(true);

            List<(int, int)> totalBanknotes = new();
            foreach (var item in sortedList)
            {
                totalBanknotes.Add((item, storage[item].Count));
            }
            return totalBanknotes;
        }
        public int GetBalance()
        {
            return storage.Sum(x => x.Key * x.Value.Count);
        }
        public (bool status, string errorMessage) AddBanknote(int denomination, Banknote banknote)
        {
            if (!storage.ContainsKey(denomination))
            {
                storage[denomination] = new List<Banknote>();
            }
            if (storage[denomination].Count >= sizeOfCassette) return (false, "Кассета переполнена");
            storage[denomination].Add(banknote);
            return (true, string.Empty);
        }
        private Banknote? DispenseBanknote(int denomination)
        {
            if (!storage.ContainsKey(denomination) || storage[denomination].Count == 0)
            {
                return null;
            }

            Banknote banknote = storage[denomination][0];
            storage[denomination].RemoveAt(0);
            return banknote;
        }
        public List<Banknote> DispenseBanknotes(int sum, bool withExchange)
        {
            int totalSum = 0;
            List<Banknote> dispensedBanknotes = new();
            if (sum > GetBalance()) return [];

            if (withExchange)
            {
                var sortedNominals = GetSortedNominals(true);
                int minNominalIndex = 0;
                while (totalSum < sum)
                {
                    if (storage[sortedNominals[minNominalIndex]].Count == 0) minNominalIndex++;
                    Banknote banknote = storage[sortedNominals[minNominalIndex]][0];
                    storage[sortedNominals[minNominalIndex]].RemoveAt(0);
                    dispensedBanknotes.Add(banknote);
                    totalSum += banknote.Denomination;
                }
            }

            return dispensedBanknotes;
        }
        private List<int> GetSortedNominals(bool ascending)
        {
            List<int> sortedList = new();
            foreach (var item in storage)
            {
                sortedList.Add(item.Key);
            }
            sortedList.Sort();
            if (!ascending) sortedList.Reverse();
            return sortedList;
        }
    }
}
