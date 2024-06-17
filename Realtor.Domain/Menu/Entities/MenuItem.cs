using Realtor.Domain.Menu.ValueObjects;
using Realtor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realtor.Domain.Menu.Entities
{
    public sealed class MenuItem : Entity<MenuItemId>
    {
        public string Name { get; }
        public string Description { get; }
        private MenuItem(MenuItemId menuItemId, string name, string desc) : base(menuItemId)
        {
            Name = name;
            Description = desc;            
        }

        public static MenuItem Create(string name, string desc)
        {
            return new(MenuItemId.CreateUnique(), name, desc);
        }
    }
}
