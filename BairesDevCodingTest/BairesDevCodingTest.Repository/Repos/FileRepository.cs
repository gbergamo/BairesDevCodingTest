using BairesDevCodingTest.Contracts.Entities;
using BairesDevCodingTest.Contracts.Repository;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;

namespace BairesDevCodingTest.Repository.Repos
{
    public class FileRepository<TEntity> : IRepository<TEntity> where TEntity : DomainEntity
    {
        private readonly RepositoryConfiguration repositoryConfiguration;

        public FileRepository(IOptions<RepositoryConfiguration> repositoryConfiguration)
        {
            this.repositoryConfiguration = repositoryConfiguration.Value;
        }

        public IEnumerable<TEntity> All()
        {
            var fileContent = File.ReadAllText(repositoryConfiguration.JsonFilePath);
            var peopleList = JsonConvert.DeserializeObject<List<TEntity>>(fileContent);
            return peopleList;
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression)
        {
            var fileContent = File.ReadAllText(repositoryConfiguration.JsonFilePath);
            var peopleList = JsonConvert.DeserializeObject<List<TEntity>>(fileContent);
            return peopleList.Where(expression.Compile());
        }

        public TEntity Insert(TEntity entity)
        {
            var fileContent = File.ReadAllText(repositoryConfiguration.JsonFilePath);
            var peopleList = JsonConvert.DeserializeObject<List<TEntity>>(fileContent);

            var idExists = peopleList.Any(x => x.Id == entity.Id);
            if (idExists)
            {
                var nextId = peopleList.Max(x => x.Id) + 1;
                entity.Id = nextId;
            }

            peopleList.Add(entity);
            var jsonPeopleList = JsonConvert.SerializeObject(peopleList);
            File.WriteAllText(repositoryConfiguration.JsonFilePath, jsonPeopleList);

            return entity;
        }
    }
}
