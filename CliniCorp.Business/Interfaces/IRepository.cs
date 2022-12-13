﻿using CliniCorp.Business.Models;
using ProjetoDemo;

namespace CliniCorp.Business.Interfaces
{
    public interface IRepository
    {
        Task<IEnumerable<consultaLista>> ListarTodos();
        Consulta AtualizarStatus(int id);
        Consulta Detalhes(int id);
        Consulta Adicionar(Consulta consulta);
        Consulta AtualizarStatus(Consulta consulta);
        Consulta AtualizarDataConsulta(Consulta consulta);

    }
}
