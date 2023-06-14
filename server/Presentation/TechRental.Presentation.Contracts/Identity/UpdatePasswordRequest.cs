namespace TechRental.Presentation.Contracts.Identity;

public record UpdatePasswordRequest(string CurrentPassword, string NewPassword);