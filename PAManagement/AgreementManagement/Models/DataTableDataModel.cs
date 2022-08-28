namespace AgreementManagement.Models
{
    public class DataTableDataModel<T>
    {
        public string Draw { get; set; }
        public string Start { get; set; }
        public string Length { get; set; }
        public string SortColumn { get; set; }
        public string SortColumnDir { get; set; }
        public string SearchValue { get; set; }
        public int RecordsTotalCount { get; set; }
        public T Data { get; set; }
    }
}
