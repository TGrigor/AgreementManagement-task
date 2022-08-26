namespace AgreementManagement.Models
{
    public class KeyValueModel<TValue>
    {
        public int Id { get; set; }
        public TValue Value { get; set; }
    }
}
