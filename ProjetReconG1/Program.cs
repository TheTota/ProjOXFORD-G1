// <copyright file="Program.cs" company="SIO">
// Copyright (c) SIO. All rights reserved.
// </copyright>

namespace ProjetOxf
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Point d'entrée de l'application.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Saisie());
        }
    }
}
