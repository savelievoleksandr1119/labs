using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

public class IdeaService
{
    private readonly ApplicationDbContext _context;

    public IdeaService(ApplicationDbContext context)
    {
        _context = context;
    }

    // Get all Ideas
    public async Task<List<Idea>> GetAllIdeasAsync()
    {
        return await _context.Ideas.Include(p => p.Category).ToListAsync();
    }

    // Get Idea by Id
    public async Task<Idea?> GetIdeaByIdAsync(int id)
    {
        return await _context.Ideas.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
    }

    // Create a new Idea (without saving changes)
    public async Task<Idea> AddIdea(IdeaEditDto model)
    {
        var categoryRef = await _context.Categories.Include(c => c.Ideas).FirstOrDefaultAsync(c => c.Id == model.CategoryId);

        if (categoryRef == null)
        {
            throw new Exception("Category not found");
        }

        var idea = new Idea
        {
            Name = model.Name,
            Description = model.Description,
            CategoryId = model.CategoryId,
        };

        _context.Ideas.Add(idea);
        return idea;
    }

    // Update a Idea (without saving changes)
    public Idea UpdateIdea(IdeaEditDto idea)
    {
        var existingIdea = _context.Ideas.Find(idea.Id);
        if (existingIdea == null)
        {
            throw new Exception("Idea not found");
        }

        existingIdea.Name = idea.Name;
        existingIdea.Description = idea.Description;
        existingIdea.CategoryId = idea.CategoryId;

        return existingIdea;
    }

    // Delete a Idea (without saving changes)
    public bool DeleteIdea(int id)
    {
        var idea = _context.Ideas.Find(id);
        if (idea == null)
        {
            throw new Exception("Idea not found");
        }

        _context.Ideas.Remove(idea);
        return true;
    }
}
