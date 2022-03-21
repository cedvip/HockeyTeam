using System;
using System.Collections.Generic;
using System.Text;

namespace HockeyTeam.Core.Framework
{
    public interface IUnitOfWork
    {

        int SaveChanges();

    }
}
