using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace _2dBurgerMobileApp.Domain.Models.Responses
{
    public class EntityCollectionResponse<T> : BaseResponse where T : IEntity
    {
        public IEnumerable<T> Collection { get; private set; }


        [JsonConstructor]
        public EntityCollectionResponse(string message, IEnumerable<T> collection) : base(message) 
        {
            Collection = collection; 
        }

        public EntityCollectionResponse(string message) : base(message) { Collection = default!; }
    }
}
