using System.ComponentModel.DataAnnotations;

namespace auctionWebApp.Models.CustomValidations;

public class DateNotInPast : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        return value != null && (DateTime)value >= DateTime.Now;
    }
    
    public override string FormatErrorMessage(string name)
    {
        return "Date must be in the future.";
    }
}