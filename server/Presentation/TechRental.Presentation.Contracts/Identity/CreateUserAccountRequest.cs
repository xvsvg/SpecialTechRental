﻿namespace TechRental.Presentation.Contracts.Identity;

public record CreateUserAccountRequest(string Username, string Password, string RoleName);