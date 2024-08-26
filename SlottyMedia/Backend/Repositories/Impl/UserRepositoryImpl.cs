// using System.Net;
// using SlottyMedia.Database.Daos;
// using Supabase;
//
// namespace SlottyMedia.Backend.Repositories.Impl;
//
//
// /// <inheritdoc cref="IUserRepository"/>
// public class UserRepositoryImpl : SupabaseRepository<UserDao>, IUserRepository
// {
//     /// <summary>
//     /// Instantiates a <see cref="UserRepositoryImpl"/>
//     /// </summary>
//     /// <param name="supabase">An object that exposes the Supabase API</param>
//     public UserRepositoryImpl(Client supabase) : base(supabase)
//     {
//         
//     }
//
//     /// <inheritdoc />
//     public override async Task<UserDao?> GetById(Guid entityId)
//     {
//         var query = await Supabase
//             .From<UserDao>()
//             .Where(user => user.UserId == entityId)
//             .Get();
//         
//         // return null if the entity was not found
//         if (query.ResponseMessage?.StatusCode == HttpStatusCode.NotFound)
//             return null;
//         
//         // throw exception if any other http errors occur
//         query.ResponseMessage?.EnsureSuccessStatusCode();
//         
//         // else: return entity
//         return query.Model;
//     }
//
//     /// <inheritdoc />
//     public async Task<UserDao?> GetUserByUsername(string username)
//     {
//         var query = await Supabase
//             .From<UserDao>()
//             .Where(user => user.UserName == username)
//             .Get();
//         
//         // return null if the entity was not found
//         if (query.ResponseMessage?.StatusCode == HttpStatusCode.NotFound)
//             return null;
//         
//         // throw exception if any other http errors occur
//         query.ResponseMessage?.EnsureSuccessStatusCode();
//         
//         // else: return entity
//         return query.Model;
//     }
// }

