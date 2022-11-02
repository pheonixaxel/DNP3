﻿using Shared.Models;

namespace Application.DaoInterfaces;

public interface IPostDao
{
    Task<Post> CreateAsync(Post post);
    Task<IEnumerable<Post>> GetAsync(string? subForm);
    Task<Post?> GetByIdAsync(int id);
    Task DeleteAsync(int id);
    Task UpdateAsync(Post updated);
}