using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using MyWebWithEF.BLL.Components.CategoryComponent.Dtos;

[Route("api/[controller]")]
[ApiController]
public class IdeasController : ControllerBase
{
    private readonly IdeaService _ideaService;
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public IdeasController(IdeaService commentService, ApplicationDbContext context, IMapper mapper)
    {
        _ideaService = commentService;
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<IdeaDto>>> GetIdeas()
    {
        var ideas = await _ideaService.GetAllIdeasAsync();
        var ideaDtos = _mapper.Map<List<IdeaDto>>(ideas);
        return Ok(ideaDtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IdeaDto>> GetIdea(int id)
    {
        var idea = await _ideaService.GetIdeaByIdAsync(id);
        if (idea == null)
        {
            return NotFound();
        }

        var ideaDto = _mapper.Map<IdeaDto>(idea);
        return Ok(ideaDto);
    }

    [HttpPost]
    public async Task<ActionResult<IdeaDto>> CreateIdea(IdeaEditDto model)
    {
        var idea = await _ideaService.AddIdea(model);

        await _context.SaveChangesAsync();

        var ideaDto = _mapper.Map<IdeaDto>(idea);
        return Ok(ideaDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateIdea(int id, IdeaEditDto model)
    {
        model.Id = id;

        var idea = _ideaService.UpdateIdea(model);

        await _context.SaveChangesAsync();

        var categoryDto = _mapper.Map<IdeaDto>(idea);
        return Ok(categoryDto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteIdea(int id)
    {
        var deleted = _ideaService.DeleteIdea(id);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}
