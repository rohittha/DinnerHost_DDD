using Realtor.Domain.Menu.ValueObjects;
using Realtor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realtor.Domain.Menu.Entities
{
    public sealed class MenuSection : Entity<MenuSectionId>
    {
        public readonly List<MenuItem> _items = new();

        public string Name { get; }
        public string Description { get; }
        public float AverageRating { get; }
        public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();


        private MenuSection(MenuSectionId menuSectionId, string name, string desc) : base(menuSectionId)
        {
            Name = name;
            Description = desc;
        }
        public static MenuSection Create(string name, string desc)
        {
            return new(MenuSectionId.CreateUnique(), name, desc);
        }

    }
}
