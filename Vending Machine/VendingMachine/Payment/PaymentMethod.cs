namespace iQuest.VendingMachine.Payment
{
    public class PaymentMethod
    {
        public int Id { get; }
        public string Name { get; }

        public PaymentMethod(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
