using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace _2dBurgerMobileApp.Domain.Models.Responses
{
    public class EntityResponse<T> : BaseResponse where T : IEntity
    {
        public T Data { get; private set; }

        [JsonConstructor]
        public EntityResponse(string message, T data) : base(message) { Data = data; }
        [JsonConstructor]
        public EntityResponse(string message) : base(message) { Data = default!; }
    }
}
