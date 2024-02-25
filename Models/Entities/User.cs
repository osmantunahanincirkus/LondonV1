﻿namespace London.Api.Models.Entities;

public class User
{
	public int Id { get; set; }
	public string Username { get; set; }
	public string Password { get; set; }
	public string Name { get; set; }
	public string Surname { get; set; }
    public ICollection<Book> Books { get; } = new List<Book>();
}
