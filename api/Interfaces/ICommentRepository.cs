using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comment;
using api.Models;
using Microsoft.AspNetCore.Routing.Constraints;

namespace api.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllAsync();
        Task<Comment?> GetByIdAsync(int id);
        Task<Comment> CreateAsync(int stockId, Comment commentModel);
        Task<Comment> UpdateAsync(int StId, Comment commentModel);
        Task<Comment?> DeleteAsync(int comId);
    }
}