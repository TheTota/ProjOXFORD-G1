//-----------------------------------------------------------------------
// <copyright file="PersonneDejaInscriteException.cs" company="SIO">
//     Copyright (c) SIO. All rights reserved.
// </copyright>
// <author>Thomas Cianfarani</author>
//-----------------------------------------------------------------------

using System;

/// <summary> Exception for signalling personne deja inscrite errors. </summary>
/// <remarks> Thomas CIANFARANI, 04/12/2017. </remarks>
public class PersonneDejaInscriteException : Exception
{
    /// <summary> Initialise une nouvelle instance de la classe <see cref="PersonneDejaInscriteException"/>. </summary>
    /// <remarks> Thomas CIANFARANI, 04/12/2017. </remarks>
    public PersonneDejaInscriteException()
    {
    }

    /// <summary> Initialise une nouvelle instance de la classe <see cref="PersonneDejaInscriteException"/>. </summary>
    /// <remarks> Thomas CIANFARANI, 04/12/2017. </remarks>
    /// <param name="message"> The message. </param>
    public PersonneDejaInscriteException(string message)
        : base(message)
    {
    }

    /// <summary> Initialise une nouvelle instance de la classe <see cref="PersonneDejaInscriteException"/>. </summary>
    /// <remarks> Thomas CIANFARANI, 04/12/2017. </remarks>
    /// <param name="message"> The message. </param>
    /// <param name="inner">   The inner. </param>
    public PersonneDejaInscriteException(string message, Exception inner)
        : base(message, inner)
    {
    }
}