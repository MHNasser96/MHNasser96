namespace UMS.Domain.Contracts;

public interface IMustHaveTenant
{
    public string TenantId { get; set; }
}