using System;

public class PersonneDejaInscriteException : Exception
{
    public PersonneDejaInscriteException()
    {
    }

    public PersonneDejaInscriteException(string message)
        : base(message)
    {
    }

    public PersonneDejaInscriteException(string message, Exception inner)
        : base(message, inner)
    {
    }
}