using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;

namespace ESPAPI.Models
{
    public interface IespContext
    {
        DbSet<PrimaryData> primarydata { get; set; }
        DbSet<User> user { get; set; }
        DbSet<SecondaryDesignData> secondarydata { get; set; }
        DbSet<SecondaryOperatingData> secondaryoperatingdata { get; set; }
        // DbSet<UserRole> userrole { get; set; }

        int SaveChanges();
        EntityEntry Entry(Object entity);

        void MarkAsModified(PrimaryData primarydata);
        void MarkAsModified(User user);
        void MarkAsModified(SecondaryDesignData secondarydata);
        void MarkAsModified(SecondaryOperatingData secondaryoperatingdata);
        //void MarkAsModified(UserRole userrole);
    }
}
