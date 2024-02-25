﻿namespace London.Api.Models.Entities;

public class Book
{
    public int Id { get; set; }
	public string Name { get; set; }
	public string Author { get; set; }
    public User User { get; set; } = null!;
}