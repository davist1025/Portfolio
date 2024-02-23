using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GithubAPI
{
    /// <summary>
    /// Defines a command by its name and description.
    /// </summary>
    internal class CommandAttribute : Attribute
    {
        public string Name { get; init; }
        public string Description { get; init; }

        public CommandAttribute(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
