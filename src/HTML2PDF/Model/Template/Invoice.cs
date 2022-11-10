using HTML2PDF.RazorEngine.Templates;

namespace HTML2PDF.Model.Template
{
    public class Invoice
    {
        public Contact Entrepreneur { get; set; }
        public Contact Recipient { get; set; }
        public string InvoiceNo { get; set; }
        public string InvoiceDate { get; set; }
        public InvoiceEntry[] InvoiceEntries { get; set; }
    }

    public class Contact
    {
        public string Fullname { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
    }

    public class InvoiceEntry
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
    }
}
