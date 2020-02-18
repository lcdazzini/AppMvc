﻿using StudyIO.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudyIO.Business.Interfaces
{
	public interface IRepository<TEntity> : IDisposable where TEntity : Entity
	{
		Task Adicionar(TEntity entity);

		Task<Entity> ObterPorId(Guid id);

		Task<List<TEntity>> ObterTodos();

		Task Atualizar(TEntity entity);

		Task Remover(Guid id);

		Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);

		Task<int> SaveChanges();
	}
}
