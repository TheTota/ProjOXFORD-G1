// <copyright file="PersonneDejaInscriteException.cs" company="SIO">
// Copyright (c) SIO. All rights reserved.
// </copyright>

namespace ProjetOxford
{
    using System;

    /// <summary>
    /// Classe correspondant à une exception de type "Personne déjà inscrite".
    /// </summary>
    public class PersonneDejaInscriteException : Exception
    {
        /// <summary>
        /// Initialise un objet de la classe <see cref="PersonneDejaInscriteException"/>.
        /// </summary>
        public PersonneDejaInscriteException()
        {
        }

        /// <summary>
        /// Initialise un objet de la classe <see cref="PersonneDejaInscriteException"/>.
        /// </summary>
        /// <param name="message">Message d'erreur à lier à l'exception levée.</param>
        public PersonneDejaInscriteException(string message)
            : base(message)
        {
        }
    }
}