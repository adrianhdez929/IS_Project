﻿namespace APIAeropuerto.Application.DTOs.UserLogin;

public class UserLoginDTO
{ 
    public Guid Id { get; set; }
    public Guid IdClient { get; set; }
    public string Token { get; set; }
}