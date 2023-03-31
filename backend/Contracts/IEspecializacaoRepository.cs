﻿using Entities.Models;

namespace Contracts;
public interface IEspecializacaoRepository : IRepositoryBase<Especializacao>
{
    IEnumerable<Especializacao> GetAllEspecializacao();
}