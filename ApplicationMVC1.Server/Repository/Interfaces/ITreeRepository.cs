﻿using ApplicationMVC1.Server.Models;

namespace ApplicationMVC1.Server.Repository.Interfaces
{
    public interface ITreeRepository
    {
        Tgroup GetRootGroup();
        List<Tgroup> GetChildGroups(int parentId);
        List<Tproperty> GetProperties(int groupId);
    }
}
