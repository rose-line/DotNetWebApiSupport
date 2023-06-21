namespace DotNetWebApiSupport.EntityLayer
{
  public class Customer
  {
    public Customer()
    {
      FirstName = string.Empty;
      LastName = string.Empty;
    }

    public int CustomerID { get; set; }
    public string? Title { get; set; }
    public string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string LastName { get; set; }
    public string? CompanyName { get; set; }
    public string? EmailAddress { get; set; }
    public string? Phone { get; set; }
    public DateTime ModifiedDate { get; set; }
  }
}