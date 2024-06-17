using Realtor.Domain.Host.ValueObjects;
using Realtor.Domain.Menu.Entities;
using Realtor.Domain.Menu.ValueObjects;
using Realtor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Realtor.Domain.Menu
{
    public sealed class Menu: AggregateRoot<MenuId>
    {
        private readonly List<MenuSection> _sections = new();
        private readonly List<DinnerId> _dinnerIds = new();
        private readonly List<MenuReviewId> _menuReviewIds = new();

        private Menu(MenuId menuId, string name, string desc, HostId hostId, DateTime createdDateTime, DateTime updatedDateTime) : base(menuId)
        {
            Name = name;
            Description = desc;
            HostId = hostId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }
        public static Menu Create(string name, string desc,HostId hostId)
        {
            return new(MenuId.CreateUnique(), name, desc, hostId, DateTime.UtcNow, DateTime.UtcNow);
        }

        public string Name { get; }
        public string Description { get; }
        public float AverageRating { get; }

        public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
        public HostId HostId { get; }
        public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
        public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get;  }

    }
}
