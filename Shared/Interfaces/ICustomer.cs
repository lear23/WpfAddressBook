namespace Shared.Interfaces
{
    public interface ICustomer
    {
        string Address { get; set; }
        string Email { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Phone { get; set; }
    }
}