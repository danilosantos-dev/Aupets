﻿using Contracts;
using Entities;
using Entities.Models;

namespace Repository;
public class EspecieRepository : RepositoryBase<Especie>, IEspecieRepository
{
    public EspecieRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public IEnumerable<Especie> GetAllEspecies()
    {
        return FindAll()
            .OrderBy(esp => esp.Nome)
            .ToList();
    }
}