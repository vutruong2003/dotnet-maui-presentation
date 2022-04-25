﻿namespace MAUI_Demo_01.Shared.Models;

public class UserModel
{
    public string Email { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string NickName { get; set; }

    public string Mobile { get; set; }

    public string Address { get; set; }
}

public class UserSignInModel
{
    public string Email { get; set; }

    public string Password { get; set; }
}

public class ResetPasswordModel
{
    public string Code { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}