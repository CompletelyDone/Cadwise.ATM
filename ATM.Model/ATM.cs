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
        public List<Banknote> DispenseBanknotes(int sum)
        {
            if (sum > GetBalance()) return [];
            int ostatok = sum;
            List<Banknote> dispensedBanknotes = new();

            var sortedNominals = GetSortedNominals(false);
            int maxNominalIndex = 0;
            while (ostatok != 0 && sortedNominals.Count > maxNominalIndex)
            {
                if (sortedNominals[maxNominalIndex] > ostatok)
                {
                    maxNominalIndex++;
                    continue;
                }
                if (storage[sortedNominals[maxNominalIndex]].Count == 0)
                {
                    maxNominalIndex++;
                    continue;
                }
                Banknote banknote = storage[sortedNominals[maxNominalIndex]][0];
                storage[sortedNominals[maxNominalIndex]].RemoveAt(0);
                dispensedBanknotes.Add(banknote);
                ostatok -= banknote.Denomination;
            }

            return dispensedBanknotes;
        } //Жадный алгоритм
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
