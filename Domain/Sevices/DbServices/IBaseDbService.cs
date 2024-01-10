using _2dBurgerMobileApp.Domain.Models;
using _2dBurgerMobileApp.Domain.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dBurgerMobileApp.Domain.Sevices.DbServices
{
    public interface IBaseDbService
    {
        Task<EntityCollectionResponse<T>?> ListAsync<T>(string endpoint) where T : IEntity;
        Task<EntityResponse<T>?> FindAsync<T>(string endpoint) where T : IEntity;
        Task<EntityResponse<T>?> AddAsync<T>(string endpoint, T entity) where T : IEntity;
    }
}
